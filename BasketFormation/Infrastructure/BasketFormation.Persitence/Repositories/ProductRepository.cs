using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BasketFormation.Domain.Entities;
using BasketFormation.Persitence.ContextsDB;
using BasketFormation.Application.Contracts.Persistence;

namespace BasketFormation.Persitence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly RepositoryContext _dbContext;

        public ProductRepository(RepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Product entity)
        {
            _dbContext.Products.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            var productToUpdate = await _dbContext.Products.FindAsync(entity.Product_ID);

            if (productToUpdate == null)
            {
                //  throw new NotFoundException(nameof(Account), request.Account_ID);
            }
            else
            {
                productToUpdate.Product_ID = entity.Product_ID;
                productToUpdate.Name = entity.Name;
                productToUpdate.Unit_price = entity.Unit_price;
                productToUpdate.Article_number = entity.Article_number;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Product entity)
        {
            var productToDelete = await _dbContext.Products.FindAsync(new object[] { entity.Product_ID });

            //if (entitY == null)
            //{
            //    throw new NotFoundException(nameof(Account), entity.Account_ID);
            //}

            _dbContext.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
