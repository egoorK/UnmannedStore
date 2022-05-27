using System.Threading;
using System.Threading.Tasks;

namespace ProductRecognition.Application.Contracts.Infrastructure
{
    public interface IAccountConsumer
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
