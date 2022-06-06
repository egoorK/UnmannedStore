using System;
using System.Collections.Generic;

namespace BasketFormation.Domain.Entities
{
    public class CartContents
    {
        public Guid CartContents_ID { get; set; }
        public decimal Discount_price { get; set; }
        public int Quantity { get; set; }
        public decimal Price_incl_quantity { get; set; }
        public int Item_number_in_cart { get; set; }
        public List<Product> Products { get; set; } = new List<Product>(); // Связь один ко многим (много)
        public List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>(); // Связь один ко многим (много)
    }
}
