using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Persistence.Configuration
{
    public class FrameConfiguration : ConfigurationDB<Frame>
    {
        public override void Map(BsonClassMap<Frame> cm)
        {
            cm.AutoMap();
            cm.MapMember(p => p.Top_Left_Corner_Coord).SetElementName("Top_Left_Corner_Coord").SetSerializer(new GuidSerializer(BsonType.String));
            cm.MapMember(p => p.Frame_Height).SetElementName("Frame_Height");
            cm.MapMember(p => p.Frame_Width).SetElementName("Frame_Width");
        }
    }
}
