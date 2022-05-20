using MongoDB.Driver;
using ProductRecognition.Domain.Entities;
using ProductRecognition.Persistence.Configuration;

namespace ProductRecognition.Persistence.ContextsDB.Contracts
{
    public interface IImageContext
    {
        //IMongoCollection<Image> Images { get; }
        IMongoCollection<ImageConfiguration> Images { get; }
    }
}
