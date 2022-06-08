using BasketFormation.Persitence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Persitence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<ICartContentsRepository, CartContentsRepository>();
            return services;
        }
    }
}
