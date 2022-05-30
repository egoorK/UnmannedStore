using System;

namespace ProductRecognition.Application.DTOForEvents
{
    public class ImageRecognizeEvent
    {
        public Guid Image_ID { get; set; }
        public string Image_Base64 { get; set; }
    }
}
