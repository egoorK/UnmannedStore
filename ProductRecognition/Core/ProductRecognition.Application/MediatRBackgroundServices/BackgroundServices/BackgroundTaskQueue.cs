using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProductRecognition.Application.MediatRBackgroundServices.BackgroundServices
{
    internal class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<Func<CancellationToken, ValueTask>> _queue;

        public BackgroundTaskQueue()
        {
            var queueCapacity = 10; //refer to docs on setting the capacity
            var options = new BoundedChannelOptions(queueCapacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<Func<CancellationToken, ValueTask>>(options);
        }

        public async ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken)
        {
            var workItem = await _queue.Reader.ReadAsync(cancellationToken);
            return workItem;
        }

        public async ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            await _queue.Writer.WriteAsync(workItem);
        }
    }
}
