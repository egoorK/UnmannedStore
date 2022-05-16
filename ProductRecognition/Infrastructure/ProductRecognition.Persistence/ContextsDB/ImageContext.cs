using MongoDB.Driver;
using ProductRecognition.Domain.Entities;
using Microsoft.Extensions.Configuration;
using ProductRecognition.Persistence.ContextsDB.Contracts;

namespace ProductRecognition.Persistence.ContextsDB
{
    public class ImageContext : IImageContext
    {
        public ImageContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Images = database.GetCollection<Image>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ImageContextSeed.SeedData(Images);
        }

        public IMongoCollection<Image> Images { get; }
    }
}
