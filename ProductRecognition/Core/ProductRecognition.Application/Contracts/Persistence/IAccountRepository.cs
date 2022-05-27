using System;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Application.Contracts.Persistence
{
    public interface IAccountRepository
    {
        Task AddAsync(Account entity);
        Task UpdateAsync(Account entity);
        Task DeleteAsync(Guid entityId);
    }
}
