using System;

namespace BasketFormation.Domain.Entities
{
    public class CartContents
    {
        public Guid CartContents_ID { get; set; }
        public decimal Discount_price { get; set; }
        public int Quantity { get; set; }
        public decimal Price_incl_quantity { get; set; }
        public int Item_number_in_cart { get; set; }
        public Guid ProductID { get; set; } // Связь один ко многим (много)
        public Product Product { get; set; }
        public Guid ShoppingCartID { get; set; } // Связь один ко многим (много)
        public ShoppingCart ShoppingCart { get; set; }
    }
}
