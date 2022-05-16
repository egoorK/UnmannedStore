using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Persistence.Configuration
{
    public class ProductConfiguration : ConfigurationDB<Product>
    {
        public override void Map(BsonClassMap<Product> cm)
        {
            cm.AutoMap();
            cm.MapMember(p => p.Product_ID).SetElementName("Product_ID").SetSerializer(new GuidSerializer(BsonType.String));
            cm.MapMember(p => p.Name).SetElementName("Name");
        }
    }
}
