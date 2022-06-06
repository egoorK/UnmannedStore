using System;

namespace BasketFormation.Domain.Entities
{
    public class Product
    {
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
        public decimal Unit_price { get; set; }
        public string Article_number { get; set; }
        public Guid CartContentsID { get; set; } // Связь один ко многим (один)
        public CartContents CartContents { get; set; } // Связь один ко многим (один)
    }
}
