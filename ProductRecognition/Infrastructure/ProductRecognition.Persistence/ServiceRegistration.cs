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
            services.AddScoped<IImageContext, ImageContext>();
            services.AddScoped<IImageRepository, ImageRepository>(); // Scoped - тип cервисов, создаваемых механизмом Depedency Injection (для каждого запроса создается свой объект сервиса)
            return services;
        }
    }
}
