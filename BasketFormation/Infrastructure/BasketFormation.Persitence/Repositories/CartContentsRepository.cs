using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BasketFormation.Domain.Entities;
using BasketFormation.Persitence.ContextsDB;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Persitence.Repositories
{
    class CartContentsRepository : ICartContentsRepository
    {
        protected readonly RepositoryContext _dbContext;

        public CartContentsRepository(RepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(CartContents entity)
        {
            _dbContext.CartContents.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartContents entity)
        {
            var cartContentsToUpdate = await _dbContext.CartContents.FindAsync(entity.CartContents_ID);

            // Добавить обработку исключений
            if (cartContentsToUpdate == null)
            {
                //  throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            else
            {
                cartContentsToUpdate.CartContents_ID = entity.CartContents_ID;
                cartContentsToUpdate.Discount_price = entity.Discount_price;
                cartContentsToUpdate.Quantity = entity.Quantity;
                cartContentsToUpdate.Price_incl_quantity = entity.Price_incl_quantity;
                cartContentsToUpdate.Item_number_in_cart = entity.Item_number_in_cart;
                cartContentsToUpdate.ProductID = entity.ProductID;
                cartContentsToUpdate.ShoppingCartID = entity.ShoppingCartID;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<CartContents> GetCartContents(Guid productId, Guid shoppingCartId)
        {
            return await _dbContext.CartContents.FirstOrDefaultAsync(p => p.ProductID == productId && p.ShoppingCartID == shoppingCartId);
        }

        public async Task<int> GetItemNumber(Guid shoppingCartId)
        {
            return await _dbContext.CartContents.Where(p => p.ShoppingCartID == shoppingCartId).MaxAsync(x => x.Item_number_in_cart);
        }

        public async Task<decimal> GetTotalCost(Guid shoppingCartId)
        {
            return await _dbContext.CartContents.Where(p => p.ShoppingCartID == shoppingCartId).SumAsync(x => x.Price_incl_quantity);
        }
    }
}
