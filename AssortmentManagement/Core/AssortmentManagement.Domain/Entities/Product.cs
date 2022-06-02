using System;

namespace AssortmentManagement.Domain.Entities
{
    public class Product
    {
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
        public decimal Unit_price { get; set; } // В БД в строке
        public string Image_Base64 { get; set; }
    }
}
