using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Persistence.Configuration;
using ProductRecognition.Persistence.ContextsDB.Contracts;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepositoryContext _dbContext;

        public ProductRepository(IRepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Product entity)
        {
            var entityToDatabase = new ProductConfiguration()
            {
                Product_ID = entity.Product_ID,
                Name = entity.Name
            };

            await _dbContext.Products.InsertOneAsync(entityToDatabase);
        }

        public async Task UpdateAsync(Product entity)
        {
            var update = Builders<ProductConfiguration>.Update
                    .Set(c => c.Product_ID, entity.Product_ID)
                    .Set(c => c.Name, entity.Name);

            await _dbContext.Products.UpdateOneAsync(filter: g => g.Product_ID == entity.Product_ID, update);
        }

        public async Task DeleteAsync(Guid entityId)
        {
            FilterDefinition<ProductConfiguration> filter = Builders<ProductConfiguration>.Filter.Eq(p => p.Product_ID, entityId);

            await _dbContext.Products.DeleteOneAsync(filter);
        }
    }
}
