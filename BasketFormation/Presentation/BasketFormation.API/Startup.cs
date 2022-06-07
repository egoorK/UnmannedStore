using System;
using MassTransit;
using BasketFormation.Persitence;
using BasketFormation.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BasketFormation.API.Consumers;
using Microsoft.Extensions.Configuration;
using BasketFormation.Persitence.ContextsDB;
using Microsoft.Extensions.DependencyInjection;
using BasketFormation.Infrastructure.DTOForEvents;
using BasketFormation.Application.Features.ShoppingsCarts.Commands.CreateShoppingCart;

namespace BasketFormation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddPersistenceServices();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddDbContext<RepositoryContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) => cfg.ConfigureEndpoints(ctx));

                config.AddRider(rider =>
                {
                    rider.AddConsumer<ProductsToCartConsumer>();
                    rider.AddConsumer<AccountConsumer>();
                    rider.AddConsumer<ProductConsumer>();

                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("kafka:9092");

                        k.TopicEndpoint<AccountCommandEvent>("accountEvents", "accountEvents-consumer-group-2", e =>
                        {
                            e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<AccountConsumer>(context);

                            e.CreateIfMissing(t =>
                            {
                                t.NumPartitions = 1; // Количество партиций в топике
                                //t.ReplicationFactor = 1; // Количество реплик партиции
                            });
                        });

                        k.TopicEndpoint<ProductCommandEvent>("productEvents", "productEvents-consumer-group-2", e =>
                        {
                            e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<ProductConsumer>(context);

                            e.CreateIfMissing(t =>
                            {
                                t.NumPartitions = 1;
                            });
                        });

                        k.TopicEndpoint<CreateShoppingCartCommand>("productsToCartEvents", "productsToCartEvents-consumer-group-1", e =>
                        {
                            e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<ProductsToCartConsumer>(context);

                            e.CreateIfMissing(t =>
                            {
                                t.NumPartitions = 1;
                            });
                        });

                    });
                });
            });

            services.AddMassTransitHostedService(); //не работает mongo для версии 3.1 (5.0?). использовать БЕЗ true!!!

            services.AddScoped<AccountConsumer>();
            services.AddScoped<ProductConsumer>();
            services.AddScoped<ProductsToCartConsumer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DatabaseManagementService.MigrationInitialisation(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
