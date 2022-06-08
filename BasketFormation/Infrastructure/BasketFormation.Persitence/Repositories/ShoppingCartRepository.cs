using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasketFormation.Domain.Entities;
using BasketFormation.Persitence.ContextsDB;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Persitence.Repositories
{
    class ShoppingCartRepository : IShoppingCartRepository
    {
        protected readonly RepositoryContext _dbContext;

        public ShoppingCartRepository(RepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> AddAsync(ShoppingCart entity)
        {
            _dbContext.ShoppingCarts.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.ShoppingCart_ID;
        }

        public async Task UpdateAsync(ShoppingCart entity)
        {
            var shoppingCartToUpdate = await _dbContext.ShoppingCarts.FindAsync(entity.ShoppingCart_ID);

            if (shoppingCartToUpdate == null)
            {
                //  throw new NotFoundException(nameof(ShoppingCart), request.ShoppingCart_ID);
            }
            else
            {
                shoppingCartToUpdate.Total_without_discount = entity.Total_without_discount;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ShoppingCart> FindShoppingCartAsync(Guid entityId)
        {
            return await _dbContext.ShoppingCarts.FirstOrDefaultAsync(p => p.AccountID == entityId);
        }
    }
}
