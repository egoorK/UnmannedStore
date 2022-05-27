using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Application.MediatRBackgroundServices.BackgroundServices;

namespace ProductRecognition.Application.MediatRBackgroundServices
{
    public static class MediatorBackgroundConfiguration
    {
        public static IServiceCollection ConfigureBackgroundServices(this IServiceCollection services)
        {

            services.AddHostedService<QueueHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddSingleton<IMediatorBackground, MediatorBackground>();
            return services;
        }
    }
}
