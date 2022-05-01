using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clients.Application.Contracts.Persistence
{
    public interface IAccountRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAccountByIdAsync(T entity);
        Task<IReadOnlyList<T>> GetAccountsAllAsync();
    }
}
