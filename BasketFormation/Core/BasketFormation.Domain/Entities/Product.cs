using System;
using System.Collections.Generic;

namespace BasketFormation.Domain.Entities
{
    public class Product
    {
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
        public decimal Unit_price { get; set; }
        public string Article_number { get; set; }
        public List<CartContents> CartContents { get; set; } = new List<CartContents>(); // Связь один ко многим (один)

    }
}
