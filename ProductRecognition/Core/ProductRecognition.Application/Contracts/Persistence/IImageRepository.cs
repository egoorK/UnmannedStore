using System;
using ProductRecognition.Domain.Entities;
using System.Threading.Tasks;

namespace ProductRecognition.Application.Contracts.Persistence
{
    public interface IImageRepository
    {
        Task<Guid> SaveAsync(Image entity);
        Task UpdateAsync(Image entity);
        Task DeleteAsync(Guid entityId);
        Task<Image> GetImageByIdAsync(Guid entityId);
        Task<Guid> GetAccountByIdAsync(Guid entityId);
    }
}
