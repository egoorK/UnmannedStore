using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Persistence.Configuration;
using ProductRecognition.Persistence.ContextsDB.Contracts;
using ProductRecognition.Application.Contracts.Persistence;

namespace ProductRecognition.Persistence.Repositories
{
    public class ProductInImageRepository : IProductInImageRepository
    {
        private readonly IRepositoryContext _dbContext;

        public ProductInImageRepository(IRepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IReadOnlyList<Guid>> AddManyAsync(List<ProductInImage> entities)
        {
            var entitiesToDatabase = new List<ProductInImageConfiguration>(entities.Count);
            var result = new List<Guid>(entities.Count);

            foreach (var entity in entities)
            {
                entitiesToDatabase.Add(new ProductInImageConfiguration()
                {
                    ImageID = entity.ImageID,
                    ProductID = entity.ProductID,
                    Probability_recognition = entity.Probability_recognition
                });
            }

            await _dbContext.ProductsInImages.InsertManyAsync(entitiesToDatabase);

            foreach (var entity in entitiesToDatabase)
            {
                result.Add(entity.ProductInImage_ID);
            }

            return result;
        }
    }
}
