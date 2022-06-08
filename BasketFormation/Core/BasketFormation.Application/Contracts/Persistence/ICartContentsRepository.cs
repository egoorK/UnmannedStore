using System;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;

namespace BasketFormation.Application.Contracts.Persistence
{
    public interface ICartContentsRepository
    {
        Task AddAsync(CartContents entity);
        Task UpdateAsync(CartContents entity);
        Task<CartContents> GetCartContents(Guid productId, Guid shoppingCartId);
        Task<int> GetItemNumber(Guid shoppingCartId);
        Task<decimal> GetTotalCost(Guid shoppingCartId);
    }
}
