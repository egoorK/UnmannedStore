using System;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;

namespace BasketFormation.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Guid entityId);
    }
}
