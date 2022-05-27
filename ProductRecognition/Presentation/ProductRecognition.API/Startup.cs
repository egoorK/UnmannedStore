using System;
using System.Net;
using MassTransit;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProductRecognition.Application;
using ProductRecognition.Persistence;
using ProductRecognition.API.EventBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Application.Features.Accounts.Commands.CreateAccount;

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

                        k.TopicEndpoint<CreateAccountCommand>("accountEvents", "accountEvents-consumer-group", e =>
                        {
                            e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<AccountConsumer>(context);

                            e.CreateIfMissing(t =>
                            {
                                t.NumPartitions = 1; //number of partitions
                                //t.ReplicationFactor = 1; //number of replicas
                            });
                        });
                    });
                });
            });

            services.AddMassTransitHostedService(); //не работает mongo для версии 3.1 (5.0?). использовать БЕЗ true!!!
            services.AddScoped<AccountConsumer>();
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
