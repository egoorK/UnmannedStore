using System;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProductRecognition.Application;
using ProductRecognition.Persistence;
using ProductRecognition.API.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Infrastructure.DTOForEvents;

namespace ProductRecognition.API
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

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) => cfg.ConfigureEndpoints(ctx));

                config.AddRider(rider =>
                {
                    rider.AddConsumer<AccountConsumer>();

                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("kafka:9092");

                        k.TopicEndpoint<AccountCommandEvent>("accountEvents", "accountEvents-consumer-group-1", e =>
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
                    });
                });
            });

            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) => cfg.ConfigureEndpoints(ctx));

                config.AddRider(rider =>
                {
                    rider.AddConsumer<ProductConsumer>();

                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("kafka:9092");

                        k.TopicEndpoint<ProductCommandEvent>("productEvents", "productEvents-consumer-group-1", e =>
                        {
                            e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<ProductConsumer>(context);

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
        }

        //private static string GetUniqueName(string eventName)
        //{
        //    string hostName = Dns.GetHostName();
        //    string callingAssembly = Assembly.GetCallingAssembly().GetName().Name;
        //    return $"{hostName}.{callingAssembly}.{eventName}";
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            //var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            //lifetime.ApplicationStopping.Register(() =>
            //{
            //    Console.WriteLine("ApplicationStopping");
            //});
        }
    }
}
