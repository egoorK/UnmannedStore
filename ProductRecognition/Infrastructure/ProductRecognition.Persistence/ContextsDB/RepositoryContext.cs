using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using ProductRecognition.Persistence.Configuration;
using ProductRecognition.Persistence.ContextsDB.Contracts;

namespace ProductRecognition.Persistence.ContextsDB
{
    public class RepositoryContext : IRepositoryContext
    {
        public RepositoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Accounts = database.GetCollection<AccountConfiguration>(configuration.GetValue<string>("DatabaseSettings:CollectionNameA"));
            Images = database.GetCollection<ImageConfiguration>(configuration.GetValue<string>("DatabaseSettings:CollectionNameI"));
            ProductsInImages = database.GetCollection<ProductInImageConfiguration>(configuration.GetValue<string>("DatabaseSettings:CollectionNamePII"));
            Products = database.GetCollection<ProductConfiguration>(configuration.GetValue<string>("DatabaseSettings:CollectionNameP"));
            ProductsFrames = database.GetCollection<ProductFrameConfiguration>(configuration.GetValue<string>("DatabaseSettings:CollectionNamePF"));

            RepositoryContextSeed.SeedData(Accounts, Images, ProductsInImages, Products, ProductsFrames);
        }

        public IMongoCollection<AccountConfiguration> Accounts { get; }
        public IMongoCollection<ImageConfiguration> Images { get; }
        public IMongoCollection<ProductInImageConfiguration> ProductsInImages { get; }
        public IMongoCollection<ProductConfiguration> Products { get; }
        public IMongoCollection<ProductFrameConfiguration> ProductsFrames { get; }
    }
}
