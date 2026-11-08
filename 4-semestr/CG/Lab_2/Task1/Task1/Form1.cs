using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Shape shape;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shape = new Shape();

            string selected = comboBox1.SelectedItem?.ToString();

            switch (selected) {
                case "Треугольник":
                    shape.BasePoints.Add(new PointF(0, -50));
                    shape.BasePoints.Add(new PointF(50, 50));
                    shape.BasePoints.Add(new PointF(-50, 50));
                    break;
                case "Квадрат":
                    shape.BasePoints.Add(new PointF(-50, -50));
                    shape.BasePoints.Add(new PointF(50, -50));
                    shape.BasePoints.Add(new PointF(50, 50));
                    shape.BasePoints.Add(new PointF(-50, 50));
                    break;
                case "Пятиугольник":
                    for (int i = 0; i < 5; i++)
                    {
                        double angle = i * 2 * Math.PI / 5 - Math.PI / 2;
                        shape.BasePoints.Add(new PointF((float)(50 * Math.Cos(angle)), (float)(50 * Math.Sin(angle))));
                    }
                    break;
                default:
                    MessageBox.Show("Сначала выберите фигуру!");
                    break;
            }

            UpdateShapePosition();
        }

        private void UpdateShapePosition()
        {
            if (shape == null || bmp == null) return;

            double dx = trackBarX.Value;
            double dy = trackBarY.Value;

            double sx = trackBarSizeX.Value;
            double sy = trackBarSizeY.Value;

            double angleDegrees = trackBarAlpha.Value;

            double shx = trackBarShX.Value;
            double shy = trackBarShY.Value;


            Matrix translationMat = new Matrix();
            translationMat.MakeTranslation(dx, dy);

            Matrix scalingMat = new Matrix();
            scalingMat.MakeScaling(sx, sy);

            Matrix rotationMat = new Matrix();
            rotationMat.MakeRotation(angleDegrees);

            Matrix shearingXMat = new Matrix();
            shearingXMat.MakeShearingX(shx);

            Matrix shearingYMat = new Matrix();
            shearingYMat.MakeShearingY(shy);

            Matrix finalMatrix = Matrix.Multiply(scalingMat, shearingXMat);
            finalMatrix = Matrix.Multiply(finalMatrix, shearingYMat);
            finalMatrix = Matrix.Multiply(finalMatrix, rotationMat);
            finalMatrix = Matrix.Multiply(finalMatrix, translationMat);

            shape.Transform = finalMatrix;
            shape.ApplyTransform();


            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.Clear(Color.White);

                if (shape.TransformedPoints.Count > 0)
                {
                    using (Pen pen = new Pen(Color.Blue, 2f))
                    {
                        g.DrawPolygon(pen, shape.TransformedPoints.ToArray());
                    }
                }
            }

            pictureBox1.Refresh();
        }

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarSizeX_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarSizeY_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarAlpha_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarShX_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarShY_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }
    }
}
