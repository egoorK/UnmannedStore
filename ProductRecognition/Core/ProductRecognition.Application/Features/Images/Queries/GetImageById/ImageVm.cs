using System;
using System.Collections.Generic;
using ProductRecognition.Domain.Entities;

namespace ProductRecognition.Application.Features.Images.Queries.GetImageById
{
    public class ImageVm
    {
        public Guid Image_ID { get; set; }
        public string Image_Base64 { get; set; }
        public DateTime Term_of_Receipt { get; set; } // Срок получения (Дата и время)
        public Guid AccountID { get; set; } // Вторичный ключ. Возможно потребуется изменить тип на GUID
    }
}
