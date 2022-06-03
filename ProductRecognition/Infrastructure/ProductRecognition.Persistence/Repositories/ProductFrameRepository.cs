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
    public class ProductFrameRepository : IProductFrameRepository
    {
        private readonly IRepositoryContext _dbContext;

        public ProductFrameRepository(IRepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddManyAsync(List<ProductFrame> entities)
        {
            var entitiesToDatabase = new List<ProductFrameConfiguration>(entities.Count);

            foreach (var entity in entities)
            {
                entitiesToDatabase.Add(new ProductFrameConfiguration()
                {
                    Top_Left_Corner_Coord_X = entity.Top_Left_Corner_Coord_X,
                    Top_Left_Corner_Coord_Y = entity.Top_Left_Corner_Coord_Y,
                    Frame_Height = entity.Frame_Height,
                    Frame_Width = entity.Frame_Width,
                    ProductInImageID = entity.ProductInImageID
                });
            }

            await _dbContext.ProductsFrames.InsertManyAsync(entitiesToDatabase);
        }
    }
}
