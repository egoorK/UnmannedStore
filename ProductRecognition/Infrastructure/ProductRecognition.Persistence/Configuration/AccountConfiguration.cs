using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Persistence.Configuration
{
    public class AccountConfiguration : ConfigurationDB<Account>
    {
        public override void Map(BsonClassMap<Account> cm)
        {
            cm.AutoMap();
            cm.MapMember(p => p.Account_ID).SetElementName("Image_ID").SetSerializer(new GuidSerializer(BsonType.String));
        }
    }
}
