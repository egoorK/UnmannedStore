using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Clients.Application;
using Clients.Persistence.ContextsDB;
using Clients.Persistence;
using Clients.Application.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Confluent.Kafka;
using System;
using Clients.Infrastructure.Publishers;

namespace Clients.API
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
            services.AddDbContext<AccountContext>(p => p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(x => 
            {
                var bootstrapperServer = Configuration.GetValue<string>("BootstrapperServer");
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = bootstrapperServer,
                    EnableIdempotence = true,
                    Acks = Acks.All,
                    LingerMs = 50 // Задержка в мс для ожидания накопления сообщения в очереди
                };
                return new ProducerBuilder<int, string>(producerConfig).Build();
            });
            services.AddScoped(typeof(IAccountPublisher), typeof(AccountPublisher));
            //services.AddScoped<IAccountPublisher, AccountPublisher>();
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
