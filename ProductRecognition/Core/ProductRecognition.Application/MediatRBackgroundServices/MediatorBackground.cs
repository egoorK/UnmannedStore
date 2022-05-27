﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProductRecognition.Application.MediatRBackgroundServices.BackgroundServices;

namespace ProductRecognition.Application.MediatRBackgroundServices
{
    internal class MediatorBackground : IMediatorBackground
    {
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MediatorBackground(IBackgroundTaskQueue backgroundTaskQueue,
            IServiceScopeFactory serviceScopeFactory)
        {
            _backgroundTaskQueue = backgroundTaskQueue;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async ValueTask Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            await _backgroundTaskQueue.QueueBackgroundWorkItemAsync(async (stoppingToken) =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    await mediator.Send(request, cancellationToken);
                }
            });
        }
    }
}
