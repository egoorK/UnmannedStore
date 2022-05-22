using System;

namespace ProductRecognition.Domain.Entities
{
    public class Image
    {
        public Guid Image_ID { get; set; }
        public string Image_Base64 { get; set; }
        public DateTime Term_of_Receipt { get; set; } = DateTime.UtcNow;    // Срок получения (Дата и время)
        public Guid AccountID { get; set; }
    }
}
