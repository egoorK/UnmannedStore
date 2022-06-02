using System;
using System.Collections.Generic;

namespace ProductRecognition.Infrastructure.DTOForEvents
{
    public class ImageRecognizedEvent
    {
        public Guid Image_ID { get; set; }
        public List<ProductRecognizedEvent> Products { get; set; }
    }
}
