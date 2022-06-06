using System;

namespace BasketFormation.Domain.Entities
{
    public class Account
    {
        public Guid Account_ID { get; set; }
        public string Username { get; set; }
        public ShoppingCart Basket { get; set; } // связь один к одному с корзинами
    }
}

