using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using ProductRecognition.Domain.Entities;


namespace ProductRecognition.Persistence.Configuration
{
    public class ImageConfiguration
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<Image>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(p => p.Image_ID).SetIdGenerator(CombGuidGenerator.Instance);
                cm.MapMember(p => p.Image_Base64).SetElementName("Image_Base64");
                cm.MapMember(p => p.Term_of_Receipt).SetElementName("Term_of_Receipt");
                cm.MapMember(p => p.Frames_Coordinates).SetElementName("Frames_Coordinates");
                cm.MapIdMember(p => p.AccountID).SetElementName("AccountID");
            });
        }
    }
}
