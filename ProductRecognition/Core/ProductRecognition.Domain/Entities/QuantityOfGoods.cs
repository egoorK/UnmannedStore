using System;
using System.Collections.Generic;
using System.Text;

namespace ProductRecognition.Domain.Entities
{
    public class QuantityOfGoods
    {
        public Guid ImageID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
