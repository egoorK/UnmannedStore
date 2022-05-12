using System.Threading.Tasks;

namespace Clients.Application.Contracts.Infrastructure
{
    public interface IAccountPublisher
    {
        Task SendMessageAsync<T>(T entity);
    }
}
