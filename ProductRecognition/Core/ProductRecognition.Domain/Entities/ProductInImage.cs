using System;

namespace ProductRecognition.Domain.Entities
{
    public class ProductInImage
    {
        public Guid ProductInImage_ID { get; set; }
        public Guid ImageID { get; set; }
        public Guid ProductID { get; set; }
    }
}
