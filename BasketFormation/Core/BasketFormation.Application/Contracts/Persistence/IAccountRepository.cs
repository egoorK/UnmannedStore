using System;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;

namespace BasketFormation.Application.Contracts.Persistence
{
    public interface IAccountRepository
    {
        Task AddAsync(Account entity);
        Task UpdateAsync(Account entity);
        Task DeleteAsync(Guid entityId);
    }
}
