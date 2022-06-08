using System;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;

namespace BasketFormation.Application.Contracts.Persistence
{
    public interface IShoppingCartRepository
    {
        Task<Guid> AddAsync(ShoppingCart entity);
        Task UpdateAsync(ShoppingCart entity);
        Task<ShoppingCart> FindShoppingCartAsync(Guid entityId);
    }
}
