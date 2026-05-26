using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Shape
    {
        public List<PointF> BasePoints { get; set; } = new List<PointF>();

        public List<PointF> TransformedPoints { get; set; } = new List<PointF>();

        public Matrix Transform { get; set; } = new Matrix();

        public void ApplyTransform()
        {
            TransformedPoints.Clear();
            foreach (PointF p in BasePoints)
            {
                double newX = p.X * Transform.Data[0, 0] + p.Y * Transform.Data[1, 0] + 1 * Transform.Data[2, 0];
                double newY = p.X * Transform.Data[0, 1] + p.Y * Transform.Data[1, 1] + 1 * Transform.Data[2, 1];

                TransformedPoints.Add(new PointF((float)newX, (float)newY));
            }
        }
    }
}
