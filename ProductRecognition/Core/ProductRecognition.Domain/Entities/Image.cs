using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ProductRecognition.Domain.Entities
{
    public class Image
    {
        [BsonId]
        [BsonElement("Image_ID")]
        public Guid Image_ID { get; set; }
        [BsonElement("Image_Base64")]
        public string Image_Base64 { get; set; }
        [BsonElement("Term_of_Receipt")]
        public DateTime Term_of_Receipt { get; set; } // Срок получения (Дата и время)
        [BsonElement("Frames_Coordinates")]
        public List<Frame> Frames_Coordinates { get; set; } // Возможно List вместо Enumerable. Или List<IEnumerable<Frame>>
        [BsonElement("AccountID")]
        public Guid AccountID { get; set; } // Вторичный ключ. Возможно потребуется изменить тип на GUID
    }
}
