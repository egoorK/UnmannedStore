using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Persistence.Configuration
{
    public class QuantityOfGoodsConfiguration : ConfigurationDB<QuantityOfGoods>
    {
        public override void Map(BsonClassMap<QuantityOfGoods> cm)
        {
            cm.AutoMap();
            cm.MapMember(p => p.ImageID).SetElementName("Image_ID").SetSerializer(new GuidSerializer(BsonType.String));
            cm.MapMember(p => p.ProductID).SetElementName("ProductID").SetSerializer(new GuidSerializer(BsonType.String));
            cm.MapMember(p => p.Quantity).SetElementName("Quantity");
        }
    }
}
