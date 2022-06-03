using System;
using System.Collections.Generic;

namespace ProductRecognition.Application.DTOForEvents.ProductRecognized
{
    public class ProductsToCartEvent
    {
        public Guid Account_ID { get; set; }
        public List<Guid> Products { get; set; }
    }
}
