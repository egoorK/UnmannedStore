using Microsoft.Extensions.DependencyInjection;
using Clients.Application.Contracts.Persistence;
using Clients.Persistence.Repositories;

namespace Clients.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IAccountRepository), typeof(AccountRepository));
            services.AddScoped<IAccountRepository, AccountRepository>(); // Scoped - тип cервисов, создаваемых механизмом Depedency Injection (для каждого запроса создается свой объект сервиса)
            return services;
        }
    }
}
