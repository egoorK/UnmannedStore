using System;
using ProductRecognition.Domain.Entities;
using System.Threading.Tasks;

namespace ProductRecognition.Application.Contracts.Persistence
{
    public interface IImageRepository
    {
        Task<Guid> SaveAsync(Image entity);
        Task<Image> GetImageByIdAsync(Guid entityId);
    }
}
