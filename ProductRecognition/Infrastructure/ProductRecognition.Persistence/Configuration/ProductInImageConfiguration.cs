using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ProductRecognition.Persistence.Configuration
{
    public class ProductInImageConfiguration
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonRepresentation(BsonType.String)]
        public Guid ProductInImage_ID { get; set; }
        [BsonRepresentation(BsonType.String)]
        [BsonElement("ImageID")]
        public Guid ImageID { get; set; }
        [BsonRepresentation(BsonType.String)]
        [BsonElement("ProductID")]
        public Guid ProductID { get; set; }
    }
}
