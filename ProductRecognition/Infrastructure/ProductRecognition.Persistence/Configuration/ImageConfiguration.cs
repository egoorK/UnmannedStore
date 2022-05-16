using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ProductRecognition.Domain.Entities;


namespace ProductRecognition.Persistence.Configuration
{
    public class ImageConfiguration : ConfigurationDB<Image>
    {
        public override void Map(BsonClassMap<Image> cm)
        {
            cm.AutoMap();
            cm.MapMember(p => p.Image_ID).SetElementName("Image_ID").SetSerializer(new GuidSerializer(BsonType.String));
            cm.MapMember(p => p.Image_Base64).SetElementName("Image_Base64");
            cm.MapMember(p => p.Term_of_Receipt).SetElementName("Term_of_Receipt");
            cm.MapMember(p => p.Frames_Coordinates).SetElementName("Frames_Coordinates");
            cm.MapMember(p => p.AccountID).SetElementName("AccountID").SetSerializer(new GuidSerializer(BsonType.String));
        }
    }
}
