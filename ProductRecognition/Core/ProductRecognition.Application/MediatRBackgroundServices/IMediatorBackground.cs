using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ProductRecognition.Application.MediatRBackgroundServices
{
    public interface IMediatorBackground
    {
        ValueTask Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
