using System.Drawing;

namespace Task1
{
    internal class Share
    {
        public Rectangle Rect { get; set; }
        public Color SquareColor { get; set; }
        public int ZIndex { get; set; }

        public Share(Rectangle rect, Color color, int zIndex)
        {
            Rect = rect;
            SquareColor = color;
            ZIndex = zIndex;
        }
    }
}
