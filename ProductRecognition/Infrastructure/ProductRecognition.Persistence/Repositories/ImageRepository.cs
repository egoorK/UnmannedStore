using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Persistence.Configuration;
using ProductRecognition.Application.Contracts.Persistence;
using ProductRecognition.Persistence.ContextsDB.Contracts;

namespace ProductRecognition.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IRepositoryContext _dbContext;

        public ImageRepository(IRepositoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Guid> SaveAsync(Image entity)
        {
            var entityToDatabase = new ImageConfiguration() 
            {
                Image_ID = entity.Image_ID,
                Image_Base64 = entity.Image_Base64,
                Term_of_Receipt = entity.Term_of_Receipt,
                AccountID = entity.AccountID
            };
            await _dbContext.Images.InsertOneAsync(entityToDatabase);
            return entityToDatabase.Image_ID;
        }

        public async Task UpdateAsync(Image entity)
        {
            //var entityToDatabase = new ImageConfiguration()
            //{
            //    Image_ID = entity.Image_ID,
            //    Image_Base64 = entity.Image_Base64,
            //    Term_of_Receipt = entity.Term_of_Receipt,
            //    AccountID = entity.AccountID
            //};

            var update = Builders<ImageConfiguration>.Update
                    .Set(c => c.Image_ID, entity.Image_ID)
                    .Set(c => c.Image_Base64, entity.Image_Base64)
                    .Set(c => c.Term_of_Receipt, entity.Term_of_Receipt);

            await _dbContext.Images.UpdateOneAsync(filter: g => g.Image_ID == entity.Image_ID, update);
        }

        public async Task DeleteAsync(Guid entityId)
        {
            FilterDefinition<ImageConfiguration> filter = Builders<ImageConfiguration>.Filter.Eq(p => p.Image_ID, entityId);

            await _dbContext.Images.DeleteOneAsync(filter);
        }

        public async Task<Image> GetImageByIdAsync(Guid entityId)
        {
            var entityToDatabase = await _dbContext.Images.Find(p => p.Image_ID == entityId).FirstOrDefaultAsync();
            
            var result = new Image() 
            {
                Image_ID = entityToDatabase.Image_ID,
                Image_Base64 = entityToDatabase.Image_Base64,
                Term_of_Receipt = entityToDatabase.Term_of_Receipt,
                AccountID = entityToDatabase.AccountID
            };
            
            return result;
        }
        public async Task<Guid> GetAccountByIdAsync(Guid entityId)
        {
            var entityToDatabase = await _dbContext.Images.Find(p => p.Image_ID == entityId).FirstOrDefaultAsync();

            return entityToDatabase.AccountID;
        }

    }
}
