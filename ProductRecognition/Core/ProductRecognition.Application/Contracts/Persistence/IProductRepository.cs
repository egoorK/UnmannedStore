using System;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Guid entityId);
    }
}
