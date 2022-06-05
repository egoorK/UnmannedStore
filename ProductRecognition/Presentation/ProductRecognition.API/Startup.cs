using System;
using MassTransit;
using Confluent.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProductRecognition.Application;
using ProductRecognition.Persistence;
using ProductRecognition.API.Consumers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Infrastructure.Publishers;
using ProductRecognition.Infrastructure.DTOForEvents;
using ProductRecognition.Application.Contracts.Infrastructure;
using ProductRecognition.Application.Features.ProductsInImages.Commands.CreateProductInImage;

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

            services.AddScoped(x =>
            {
                var bootstrapperServer = Configuration.GetValue<string>("BootstrapperServer");
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = bootstrapperServer,
                    EnableIdempotence = true,
                    Acks = Acks.All,
                    LingerMs = 50, // Задержка в мс для ожидания накопления сообщения в очереди
                    MessageMaxBytes = 10485760,
                    BatchNumMessages = 1,
                    BatchSize = 10485761
                };
                // producerConfig.BatchNumMessages
                return new ProducerBuilder<int, string>(producerConfig).Build();
            });

            services.AddScoped<IImagePublisher, ImagePublisher>();
            services.AddScoped<IProductsToCartPublisher, ProductsToCartPublisher>();


            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) => cfg.ConfigureEndpoints(ctx));

                config.AddRider(rider =>
                {
                    rider.AddConsumer<ProductRecognizedConsumer>();
                    rider.AddConsumer<AccountConsumer>();
                    rider.AddConsumer<ProductConsumer>();

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

                        k.TopicEndpoint<CreateProductInImageCommand>("productRecognizedEvents", "productRecognizedEvents-consumer-group-1", e =>
                        {
                            e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<ProductRecognizedConsumer>(context);

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
            services.AddScoped<ProductRecognizedConsumer>();
        }

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
        }
    }
}
