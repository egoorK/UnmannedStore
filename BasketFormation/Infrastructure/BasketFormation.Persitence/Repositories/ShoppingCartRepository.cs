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

        public async Task<ShoppingCart> FindShoppingCartAsync(Guid entityId)
        {
            return await _dbContext.ShoppingCarts.FirstOrDefaultAsync(p => p.AccountID == entityId);
        }
    }
}
