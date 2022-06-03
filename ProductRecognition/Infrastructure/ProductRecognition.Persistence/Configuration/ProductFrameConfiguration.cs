using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ProductRecognition.Persistence.Configuration
{
    public class ProductFrameConfiguration
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRepresentation(BsonType.String)]
        public Guid ProductFrame_ID { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("Top_Left_Corner_Coord_X")]
        public int Top_Left_Corner_Coord_X { get; set; } 
        [BsonIgnoreIfDefault]
        [BsonElement("Top_Left_Corner_Coord_Y")]
        public int Top_Left_Corner_Coord_Y { get; set; } 
        [BsonIgnoreIfDefault]
        [BsonElement("Frame_Height")]
        public int Frame_Height { get; set; } // Высота рамки
        [BsonIgnoreIfDefault]
        [BsonElement("Frame_Width")]
        public int Frame_Width { get; set; } // Ширина рамки
        [BsonRepresentation(BsonType.String)]
        [BsonElement("ProductInImageID")]
        public Guid ProductInImageID { get; set; }
    }
}
