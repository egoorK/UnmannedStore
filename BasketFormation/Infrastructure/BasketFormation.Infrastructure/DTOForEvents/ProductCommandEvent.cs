using System;

namespace BasketFormation.Infrastructure.DTOForEvents
{
    public class ProductCommandEvent
    {
        public string Event_Type { get; set; }
        public Guid Product_ID { get; set; }
        public string Name { get; set; }
        public decimal Unit_price { get; set; }
        public string Article_number { get; set; }
    }
}
