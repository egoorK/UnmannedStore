using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Application.Contracts.Persistence;
using ProductRecognition.Persistence.Repositories;
using ProductRecognition.Persistence.ContextsDB;
using ProductRecognition.Persistence.ContextsDB.Contracts;

namespace ProductRecognition.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryContext, RepositoryContext>();
            services.AddScoped<IImageRepository, ImageRepository>(); // Scoped - тип cервисов, создаваемых механизмом Depedency Injection (для каждого запроса создается свой объект сервиса)
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductInImageRepository, ProductInImageRepository>();
            services.AddScoped<IProductFrameRepository, ProductFrameRepository>();
            return services;
        }
    }
}
