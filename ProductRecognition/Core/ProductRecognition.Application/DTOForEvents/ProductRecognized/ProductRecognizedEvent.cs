using System;

namespace ProductRecognition.Application.DTOForEvents.ProductRecognized
{
    public class ProductRecognizedEvent
    {
        public Guid Product_ID { get; set; }
        public ProductFrameRecognizedEvent Product_frame { get; set; }
        public double Probability_recognition { get; set; }
    }
}
