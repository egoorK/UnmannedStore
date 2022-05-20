using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;


namespace ProductRecognition.Persistence.Configuration
{
    public class ImageConfiguration
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRepresentation(BsonType.String)]
        public Guid Image_ID { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("Image_Base64")]
        public string Image_Base64 { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("Term_of_Receipt")]
        public DateTime Term_of_Receipt { get; set; }    // Срок получения (Дата и время)
        [BsonRepresentation(BsonType.String)]
        [BsonElement("AccountID")]
        public Guid AccountID { get; set; }
    }
}
