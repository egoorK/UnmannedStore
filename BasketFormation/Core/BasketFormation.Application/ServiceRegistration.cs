using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BasketFormation.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly()); // GetExecutingAssembly() Получает сборку, которая содержит выполняемый в текущий момент код.
            return services;
        }
    }
}
