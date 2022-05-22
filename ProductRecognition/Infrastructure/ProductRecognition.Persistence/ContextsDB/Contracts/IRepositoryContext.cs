using MongoDB.Driver;
using ProductRecognition.Persistence.Configuration;

namespace ProductRecognition.Persistence.ContextsDB.Contracts
{
    public interface IRepositoryContext
    {
        IMongoCollection<AccountConfiguration> Accounts { get; }
        IMongoCollection<ImageConfiguration> Images { get; }
        IMongoCollection<ProductInImageConfiguration> ProductsInImages { get; }
        IMongoCollection<ProductConfiguration> Products { get; }
        IMongoCollection<ProductFrameConfiguration> ProductsFrames { get; }
    }
}
