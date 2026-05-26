using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        private void button1_Click(object sender, EventArgs e)
        {
            shape = new Shape();

            string selected = comboBox1.SelectedItem?.ToString();

            switch (selected)
            {
                case "Куб":
                    shape.BasePoints.Add(new Point3D(-50, -50, 50));
                    shape.BasePoints.Add(new Point3D(50, -50, 50));
                    shape.BasePoints.Add(new Point3D(50, 50, 50));
                    shape.BasePoints.Add(new Point3D(-50, 50, 50));
                    shape.BasePoints.Add(new Point3D(-50, -50, -50));
                    shape.BasePoints.Add(new Point3D(50, -50, -50));
                    shape.BasePoints.Add(new Point3D(50, 50, -50));
                    shape.BasePoints.Add(new Point3D(-50, 50, -50));

                    shape.Edges.Add(new Edge(0, 1)); shape.Edges.Add(new Edge(1, 2));
                    shape.Edges.Add(new Edge(2, 3)); shape.Edges.Add(new Edge(3, 0));

                    shape.Edges.Add(new Edge(4, 5)); shape.Edges.Add(new Edge(5, 6));
                    shape.Edges.Add(new Edge(6, 7)); shape.Edges.Add(new Edge(7, 4));

                    shape.Edges.Add(new Edge(0, 4)); shape.Edges.Add(new Edge(1, 5));
                    shape.Edges.Add(new Edge(2, 6)); shape.Edges.Add(new Edge(3, 7));
                    break;
                case "Параллелепипед":
                    shape.BasePoints.Add(new Point3D(-30, -50, 50));
                    shape.BasePoints.Add(new Point3D(100, -50, 50));
                    shape.BasePoints.Add(new Point3D(30, 50, 50));
                    shape.BasePoints.Add(new Point3D(-100, 50, 50));
                    shape.BasePoints.Add(new Point3D(-30, -50, -50));
                    shape.BasePoints.Add(new Point3D(100, -50, -50));
                    shape.BasePoints.Add(new Point3D(30, 50, -50));
                    shape.BasePoints.Add(new Point3D(-100, 50, -50));

                    shape.Edges.Add(new Edge(0, 1)); shape.Edges.Add(new Edge(1, 2));
                    shape.Edges.Add(new Edge(2, 3)); shape.Edges.Add(new Edge(3, 0));

                    shape.Edges.Add(new Edge(4, 5)); shape.Edges.Add(new Edge(5, 6));
                    shape.Edges.Add(new Edge(6, 7)); shape.Edges.Add(new Edge(7, 4));

                    shape.Edges.Add(new Edge(0, 4)); shape.Edges.Add(new Edge(1, 5));
                    shape.Edges.Add(new Edge(2, 6)); shape.Edges.Add(new Edge(3, 7));
                    break;
                case "Пирамида":
                    shape.BasePoints.Add(new Point3D(-50, 50, -50)); 
                    shape.BasePoints.Add(new Point3D(50, 50, -50));  
                    shape.BasePoints.Add(new Point3D(50, 50, 50));   
                    shape.BasePoints.Add(new Point3D(-50, 50, 50));  
                    shape.BasePoints.Add(new Point3D(0, -50, 0));

                    shape.Edges.Add(new Edge(0, 1));
                    shape.Edges.Add(new Edge(1, 2));
                    shape.Edges.Add(new Edge(2, 3));
                    shape.Edges.Add(new Edge(3, 0));

                    shape.Edges.Add(new Edge(0, 4));
                    shape.Edges.Add(new Edge(1, 4));
                    shape.Edges.Add(new Edge(2, 4));
                    shape.Edges.Add(new Edge(3, 4));
                    break;
                default:
                    MessageBox.Show("Сначала выберите фигуру!");
                    break;
            }

            UpdateShapePosition();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBarX.Value = 100;
            trackBarY.Value = 100;
            trackBarZ.Value = 100;

            trackBarSizeX.Value = 1;
            trackBarSizeY.Value = 1;
            trackBarSizeZ.Value = 1;

            trackBarAlphaX.Value = 0;
            trackBarAlphaY.Value = 0;
            trackBarAlphaZ.Value = 0;

            trackBarD.Value = 400;

            UpdateShapePosition();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
        }

        private void UpdateShapePosition()
        {
            if (shape == null || bmp == null) return;

            double dx = trackBarX.Value;
            double dy = trackBarY.Value;
            double dz = trackBarZ.Value;

            double sx = trackBarSizeX.Value;
            double sy = trackBarSizeY.Value;
            double sz = trackBarSizeZ.Value;

            double angleDegreesX = trackBarAlphaX.Value;
            double angleDegreesY = trackBarAlphaY.Value;
            double angleDegreesZ = trackBarAlphaZ.Value;


            Matrix translationMat = new Matrix();
            translationMat.MakeTranslation(dx, dy, dz);

            Matrix scalingMat = new Matrix();
            scalingMat.MakeScaling(sx, sy, sz);

            Matrix rotationMatX = new Matrix();
            rotationMatX.MakeRotationX(angleDegreesX);
            Matrix rotationMatY = new Matrix();
            rotationMatY.MakeRotationY(angleDegreesY);
            Matrix rotationMatZ = new Matrix();
            rotationMatZ.MakeRotationZ(angleDegreesZ);

            Matrix projectionMat = new Matrix();
            string projSelected = comboBoxProjection.SelectedItem?.ToString();

            switch (projSelected){
                case "Кабине":
                    projectionMat.CabinProjection();
                    break;
                case "Кавалье":
                    projectionMat.CavaleProjection();
                    break;
                case "Центральная":
                    projectionMat.CenterProjection(trackBarD.Value);
                    break;
                default:
                    MessageBox.Show("По умолчанию выбрана проекция Кабине");
                    comboBoxProjection.Text = "Кабине";
                    projectionMat.CabinProjection();
                    break;
            }

            Matrix finalMatrix = Matrix.Multiply(scalingMat, rotationMatX);
            finalMatrix = Matrix.Multiply(finalMatrix, rotationMatY);
            finalMatrix = Matrix.Multiply(finalMatrix, rotationMatZ);
            finalMatrix = Matrix.Multiply(finalMatrix, translationMat);

            finalMatrix = Matrix.Multiply(finalMatrix, projectionMat);

            shape.Transform = finalMatrix;
            shape.ApplyTransform();

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
                        foreach (var edge in shape.Edges)
                        {
                            PointF p1 = shape.TransformedPoints[edge.From];
                            PointF p2 = shape.TransformedPoints[edge.To];
                            g.DrawLine(pen, p1, p2);
                        }
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

        private void trackBarZ_Scroll(object sender, EventArgs e)
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

        private void trackBarSizeZ_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarAlphaX_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarAlphaY_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarAlphaZ_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void trackBarD_Scroll(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }

        private void comboBoxProjection_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateShapePosition();
        }
    }
}
