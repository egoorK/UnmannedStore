using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductRecognition.Persistence.Configuration
{
    public class AccountConfiguration
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Account_ID { get; set; }
        [BsonIgnoreIfDefault]
        [BsonElement("Username")]
        public string Username { get; set; }
    }
}
