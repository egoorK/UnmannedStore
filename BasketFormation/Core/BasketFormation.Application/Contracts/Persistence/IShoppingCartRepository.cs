using System;
using System.Threading.Tasks;
using BasketFormation.Domain.Entities;

namespace BasketFormation.Application.Contracts.Persistence
{
    public interface IShoppingCartRepository
    {
        Task<Guid> AddAsync(ShoppingCart entity);
        Task<ShoppingCart> FindShoppingCartAsync(Guid entityId);
    }
}
