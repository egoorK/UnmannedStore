using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Application.Contracts.Persistence;
using ProductRecognition.Persistence.Repositories;

namespace ProductRecognition.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
            services.AddScoped<IImageRepository, ImageRepository>(); // Scoped - тип cервисов, создаваемых механизмом Depedency Injection (для каждого запроса создается свой объект сервиса)
            return services;
        }
    }
}
