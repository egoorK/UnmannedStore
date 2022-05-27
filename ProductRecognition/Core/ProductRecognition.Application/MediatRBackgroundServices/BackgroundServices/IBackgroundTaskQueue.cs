using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductRecognition.Application.MediatRBackgroundServices.BackgroundServices
{
    internal interface IBackgroundTaskQueue
    {
        ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem);

        ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(
            CancellationToken cancellationToken);
    }
}
