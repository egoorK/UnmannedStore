using System;
using System.Collections.Generic;
using System.Text;

namespace ProductRecognition.Domain.Entities
{
    public class Frame
    {
        public int[] Top_Left_Corner_Coord { get; set; } // Координаты верхнего левого угла рамки
        public int Frame_Height { get; set; } // Высота рамки
        public int Frame_Width { get; set; } // Ширина рамки
    }
}
