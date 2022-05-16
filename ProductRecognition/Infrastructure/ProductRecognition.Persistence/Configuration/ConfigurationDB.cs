using MongoDB.Bson.Serialization;

namespace ProductRecognition.Persistence.Configuration
{
    public abstract class ConfigurationDB<T>
    {
        protected ConfigurationDB()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
                BsonClassMap.RegisterClassMap<T>(Map);
        }

        public abstract void Map(BsonClassMap<T> cm);
    }
}
