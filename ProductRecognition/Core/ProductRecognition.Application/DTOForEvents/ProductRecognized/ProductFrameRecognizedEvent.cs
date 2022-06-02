namespace ProductRecognition.Application.DTOForEvents.ProductRecognized
{
    public class ProductFrameRecognizedEvent
    {
        public int Top_Left_Corner_Coord_X { get; set; }
        public int Top_Left_Corner_Coord_Y { get; set; }
        public int Frame_Height { get; set; } // Высота рамки
        public int Frame_Width { get; set; } // Ширина рамки
    }
}
