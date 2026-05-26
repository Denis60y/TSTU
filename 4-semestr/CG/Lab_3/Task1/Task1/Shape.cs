using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Task1
{
    public class Shape
    {
        public List<Point3D> BasePoints { get; set; } = new List<Point3D>();

        public List<PointF> TransformedPoints { get; set; } = new List<PointF>();

        public List<Edge> Edges { get; set; } = new List<Edge>();

        public Matrix Transform { get; set; } = new Matrix();

        public void ApplyTransform()
        {
            TransformedPoints.Clear();
            foreach (Point3D p in BasePoints)
            {

                double newX = p.X * Transform.Data[0, 0] + p.Y * Transform.Data[1, 0] + p.Z * Transform.Data[2, 0] + 1.0 * Transform.Data[3, 0];
                double newY = p.X * Transform.Data[0, 1] + p.Y * Transform.Data[1, 1] + p.Z * Transform.Data[2, 1] + 1.0 * Transform.Data[3, 1];
                double newZ = p.X * Transform.Data[0, 2] + p.Y * Transform.Data[1, 2] + p.Z * Transform.Data[2, 2] + 1.0 * Transform.Data[3, 2];

                double newH = p.X * Transform.Data[0, 3] + p.Y * Transform.Data[1, 3] + p.Z * Transform.Data[2, 3] + 1.0 * Transform.Data[3, 3];

                if (Math.Abs(newH) > 0.0001)
                {
                    newX /= newH;
                    newY /= newH;
                }

                TransformedPoints.Add(new PointF((float)newX, (float)newY));
            }
        }
    }
}
