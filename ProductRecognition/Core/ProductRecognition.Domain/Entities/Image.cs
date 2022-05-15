using System;
using System.Collections.Generic;

namespace ProductRecognition.Domain.Entities
{
    public class Image
    {
        public Guid Image_ID { get; set; }
        public string Image_Base64 { get; set; }
        public DateTime Term_of_Receipt { get; set; } // Срок получения (Дата и время)
        public IEnumerable<Frame> Frames_Coordinates { get; set; } // Возможно List вместо Enumerable. Или List<IEnumerable<Frame>>
        public Account AccountID { get; set; } // Вторичный ключ. Возможно потребуется изменить тип на GUID
    }
}
