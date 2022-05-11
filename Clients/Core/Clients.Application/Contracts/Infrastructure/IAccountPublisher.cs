using System.Threading.Tasks;
using Clients.Application.DTOForEvents;

namespace Clients.Application.Contracts.Infrastructure
{
    public interface IAccountPublisher
    {
        Task AccountAddedEventAsync(AccountCreatedEvent entity);
      //  Task AccountUpdatedEventAsync(AccountUpdatedEvent entity);
      //  Task AccountDeletedEventAsync(AccountDeletedEvent entityId);
    }
}
