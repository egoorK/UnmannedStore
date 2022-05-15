using System;
using System.Threading.Tasks;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Application.Contracts.Persistence;

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
        
        Task<Image> GetImageByIdAsync(Guid entityId);
    }
}
