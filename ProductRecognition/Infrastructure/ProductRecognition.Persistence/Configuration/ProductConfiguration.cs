using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductRecognition.Persistence.Configuration
{
    public class ProductConfiguration
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Product_ID { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
