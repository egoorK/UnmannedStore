using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clients.Domain.Entities;

namespace Clients.Application.Contracts.Persistence
{
    public interface IAccountRepository // Изменить возвращаемые значения
    {
        Task<Guid> AddAsync(Account entity);
        Task UpdateAsync(Account entity);
        Task DeleteAsync(Account entity);
        Task<Account> GetAccountByIdAsync(Guid entityId);
        Task<IReadOnlyList<Account>> GetAccountsAllAsync();
    }
}
