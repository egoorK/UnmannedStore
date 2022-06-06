using System;
using System.Collections.Generic;

namespace BasketFormation.Domain.Entities
{
    public class ShoppingCart
    {
        public Guid ShoppingCart_ID { get; set; }
        public DateTime Fill_start_time { get; set; }
        public DateTime Fill_end_time { get; set; }
        public decimal Total_without_discount { get; set; }
        public decimal Total_with_discount { get; set; }
        public Guid AccountID { get; set; } // вторичный ключ
        public Account Account { get; set; } // связь один к одному с учетными записями
        public List<CartContents> CartContents { get; set; } = new List<CartContents>();
    }
}
