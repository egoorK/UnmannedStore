using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;
using ProductRecognition.Persistence.ContextsDB.Contracts;

namespace ProductRecognition.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IImageContext _dbContext;

        public ImageRepository(IImageContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> SaveAsync(Image entity)
        {
            await _dbContext.Images.InsertOneAsync(entity);
            return entity.Image_ID;
        }

        public async Task UpdateAsync(Image entity)
        {
            await _dbContext.Images.ReplaceOneAsync(filter: g => g.Image_ID == entity.Image_ID, replacement: entity);
        }

        public async Task DeleteAsync(Guid entityId)
        {
            FilterDefinition<Image> filter = Builders<Image>.Filter.Eq(p => p.Image_ID, entityId);

            await _dbContext.Images.DeleteOneAsync(filter);
        }

        public async Task<Image> GetImageByIdAsync(Guid entityId)
        {
            return await _dbContext.Images.Find(p => p.Image_ID == entityId).FirstOrDefaultAsync();
        }
    }
}
