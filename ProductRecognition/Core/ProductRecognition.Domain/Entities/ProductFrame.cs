using System;

namespace ProductRecognition.Domain.Entities
{
    public class ProductFrame
    {
        public Guid ProductFrame_ID { get; set; }
        public int Top_Left_Corner_Coord_X { get; set; } // Координаты верхнего левого угла рамки
        public int Top_Left_Corner_Coord_Y { get; set; }
        public int Frame_Height { get; set; } // Высота рамки
        public int Frame_Width { get; set; } // Ширина рамки
        public Guid ProductInImageID { get; set; }
    }
}
