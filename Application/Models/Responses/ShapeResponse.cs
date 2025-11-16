namespace Application.Models.Responses
{
    public class ShapeResponse
    {
        public int ShapeId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public int Rotation { get; set; }
        public int Padding { get; set; }
        public int Opacity { get; set; }
        public string Colour { get; set; } = string.Empty;
    }
}