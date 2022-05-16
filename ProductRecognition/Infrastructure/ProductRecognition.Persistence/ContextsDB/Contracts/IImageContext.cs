using MongoDB.Driver;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Persistence.ContextsDB.Contracts
{
    public interface IImageContext
    {
        IMongoCollection<Image> Images { get; }
    }
}
