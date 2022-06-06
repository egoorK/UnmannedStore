using Microsoft.Extensions.DependencyInjection;
using BasketFormation.Application.Contracts.Persistence;
using BasketFormation.Persistence.Repositories;

namespace BasketFormation.Persitence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
