using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task1
{
    public partial class Form1 : Form
    {
        public struct Triangle
        {
            public PointF A, B, C; 
            public PointF AT, BT, CT;
        }

        Bitmap bmp;
        Shape shape;

        List<Triangle> poligons = new List<Triangle>();

        List<PointF> uvCoords;

        MyImage loadedImage = null;

        const int TRACKBAR_X = 100;
        const int TRACKBAR_Y = 100;
        const int TRACKBAR_SIZE_X = 1;
        const int TRACKBAR_SIZE_Y = 1;
        const int TRACKBAR_ALPHA = 0;

        public Form1()
        {
            InitializeComponent();

            uvCoords = new List<PointF>
            {
                new PointF((float)Math.Round(trackBarX1.Value / 100.0, 2), (float)Math.Round(trackBarY1.Value / 100.0, 2)),
                new PointF((float)Math.Round(trackBar2X.Value / 100.0, 2), (float)Math.Round(trackBarY2.Value / 100.0, 2)),
                new PointF((float)Math.Round(trackBarX3.Value / 100.0, 2), (float)Math.Round(trackBarY3.Value / 100.0, 2)),
                new PointF((float)Math.Round(trackBarX4.Value / 100.0, 2), (float)Math.Round(trackBarY4.Value / 100.0, 2))
            };

            textBoxX1.Text = "" + Math.Round(trackBarX1.Value / 100.0, 2);
            textBoxY1.Text = "" + Math.Round(trackBarY1.Value / 100.0, 2);
            textBoxX2.Text = "" + Math.Round(trackBar2X.Value / 100.0, 2);
            textBoxY2.Text = "" + Math.Round(trackBarY2.Value / 100.0, 2);
            textBoxX3.Text = "" + Math.Round(trackBarX3.Value / 100.0, 2);
            textBoxY3.Text = "" + Math.Round(trackBarY3.Value / 100.0, 2);
            textBoxX4.Text = "" + Math.Round(trackBarX4.Value / 100.0, 2);
            textBoxY4.Text = "" + Math.Round(trackBarY4.Value / 100.0, 2);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = bmp;

            shape = new Shape();

            shape.BasePoints.Add(new PointF(-50, -50));
            shape.BasePoints.Add(new PointF(50, -50));
            shape.BasePoints.Add(new PointF(50, 50));
            shape.BasePoints.Add(new PointF(-50, 50));

            for (int i = 0; i < shape.BasePoints.Count - 2; i++)
            {
                Triangle tri = new Triangle();
                tri.A = shape.BasePoints[0];
                tri.B = shape.BasePoints[i + 1];
                tri.C = shape.BasePoints[i + 2];

                poligons.Add(tri);
            }

            UpdateShapePosition();
        }

        private void ApplyTexture()
        {
            if (loadedImage == null || bmp == null || loadedImage.LoadedImage == null) return;

            Bitmap tex = loadedImage.LoadedImage;

            foreach (Triangle poly in poligons)
            {
                var p = new[] { (poly.A, poly.AT), (poly.B, poly.BT), (poly.C, poly.CT) }
                        .OrderBy(v => v.Item1.Y).ToArray();

                int ay = (int)p[0].Item1.Y, cy = (int)p[2].Item1.Y;
                if (ay == cy) continue;

                int ax = (int)p[0].Item1.X;
                int bx = (int)p[1].Item1.X, by = (int)p[1].Item1.Y;
                int cx = (int)p[2].Item1.X;

                float au = p[0].Item2.X, av = p[0].Item2.Y;
                float bu = p[1].Item2.X, bv = p[1].Item2.Y;
                float cu = p[2].Item2.X, cv = p[2].Item2.Y;

                for (int y = ay; y <= cy; y++)
                {
                    if (y < 0 || y >= bmp.Height) continue;

                    float x1 = ax + (float)(cx - ax) * (y - ay) / (cy - ay);
                    float u1 = au + (float)(cu - au) * (y - ay) / (cy - ay);
                    float v1 = av + (float)(cv - av) * (y - ay) / (cy - ay);

                    bool topHalf = y < by;
                    int s = topHalf ? 0 : 1;
                    int e = topHalf ? 1 : 2;

                    float denom = p[e].Item1.Y - p[s].Item1.Y;
                    float tShort = (denom == 0) ? 0 : (float)(y - p[s].Item1.Y) / denom;

                    float x2 = p[s].Item1.X + (p[e].Item1.X - p[s].Item1.X) * tShort;
                    float u2 = p[s].Item2.X + (p[e].Item2.X - p[s].Item2.X) * tShort;
                    float v2 = p[s].Item2.Y + (p[e].Item2.Y - p[s].Item2.Y) * tShort;

                    if (x1 > x2) { (x1, x2) = (x2, x1); (u1, u2) = (u2, u1); (v1, v2) = (v2, v1); }

                    int startX = (int)x1, endX = (int)x2;
                    for (int x = startX; x <= endX; x++)
                    {
                        if (x < 0 || x >= bmp.Width) continue;

                        float tX = (x2 - x1 == 0) ? 0 : (x - x1) / (x2 - x1);
                        float u = u1 + (u2 - u1) * tX;
                        float v = v1 + (v2 - v1) * tX;

                        int txX = (int)(u * (tex.Width - 1));
                        int txY = (int)(v * (tex.Height - 1));

                        if (txX < 0) txX = 0; else if (txX >= tex.Width) txX = tex.Width - 1;
                        if (txY < 0) txY = 0; else if (txY >= tex.Height) txY = tex.Height - 1;

                        bmp.SetPixel(x, y, tex.GetPixel(txX, txY));
                    }
                }
            }
        }

        private void UpdateShapePosition()
        {
            if (shape == null || bmp == null) return;

            double dx = trackBarX.Value;
            double dy = trackBarY.Value;
            double sx = trackBarSizeX.Value;
            double sy = trackBarSizeY.Value;
            double angleDegrees = trackBarAlpha.Value;

            Matrix translationMat = new Matrix();
            translationMat.MakeTranslation(dx, dy);

            Matrix scalingMat = new Matrix();
            scalingMat.MakeScaling(sx, sy);

            Matrix rotationMat = new Matrix();
            rotationMat.MakeRotation(angleDegrees);

            Matrix finalMatrix = Matrix.Multiply(scalingMat, rotationMat);
            finalMatrix = Matrix.Multiply(finalMatrix, translationMat);

            shape.Transform = finalMatrix;
            shape.ApplyTransform();

            for (int i = 0; i < poligons.Count; i++)
            {
                Triangle tri = poligons[i];

                tri.A = shape.TransformedPoints[0];
                tri.B = shape.TransformedPoints[i + 1];
                tri.C = shape.TransformedPoints[i + 2];

                tri.AT = uvCoords[0];
                tri.BT = uvCoords[i + 1];
                tri.CT = uvCoords[i + 2];

                poligons[i] = tri;
            }

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                ApplyTexture();
            }

            pictureBox1.Refresh();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            trackBarX.Value = TRACKBAR_X;
            trackBarY.Value = TRACKBAR_Y;
            trackBarSizeX.Value = TRACKBAR_SIZE_X;
            trackBarSizeY.Value = TRACKBAR_SIZE_Y;
            trackBarAlpha.Value = TRACKBAR_ALPHA;

            trackBarX1.Value = 0; trackBarY1.Value = 0;   
            trackBar2X.Value = 100; trackBarY2.Value = 0;   
            trackBarX3.Value = 100; trackBarY3.Value = 100; 
            trackBarX4.Value = 0; trackBarY4.Value = 100;

            UpdateShapePosition();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения|*.bmp;*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedImage?.Dispose();

                    byte[] fileBytes = File.ReadAllBytes(openFileDialog.FileName);

                    using (MemoryStream ms = new MemoryStream(fileBytes))
                    {
                        Bitmap bmp = new Bitmap(ms);
                        loadedImage = new MyImage(bmp);
                    }
                }
            }

            UpdateShapePosition();
        }

        private void UpdateImageEffects()
        {
            if (loadedImage == null) return;

            double c = trackBarContrast.Value / 10.0;
            int b = trackBarBrightness.Value;
            double s = trackBarSaturation.Value / 10.0;

            loadedImage.ApplyEffects(c, b, s);
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

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarSaturation_Scroll(object sender, EventArgs e)
        {
            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarX1_Scroll(object sender, EventArgs e)
        {
            uvCoords[0] = new PointF((float)Math.Round(trackBarX1.Value / 100.0, 2), (float)Math.Round(trackBarY1.Value / 100.0, 2));

            textBoxX1.Text = "" + Math.Round(trackBarX1.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarY1_Scroll(object sender, EventArgs e)
        {
            uvCoords[0] = new PointF((float)Math.Round(trackBarX1.Value / 100.0, 2), (float)Math.Round(trackBarY1.Value / 100.0, 2));

            textBoxY1.Text = "" + Math.Round(trackBarY1.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBar2X_Scroll(object sender, EventArgs e)
        {
            uvCoords[1] = new PointF((float)Math.Round(trackBar2X.Value / 100.0, 2), (float)Math.Round(trackBarY2.Value / 100.0, 2));

            textBoxX2.Text = "" + Math.Round(trackBar2X.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarY2_Scroll(object sender, EventArgs e)
        {
            uvCoords[1] = new PointF((float)Math.Round(trackBar2X.Value / 100.0, 2), (float)Math.Round(trackBarY2.Value / 100.0, 2));

            textBoxY2.Text = "" + Math.Round(trackBarY2.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarX3_Scroll(object sender, EventArgs e)
        {
            uvCoords[2] = new PointF((float)Math.Round(trackBarX3.Value / 100.0, 2), (float)Math.Round(trackBarY3.Value / 100.0, 2));

            textBoxX3.Text = "" + Math.Round(trackBarX3.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarY3_Scroll(object sender, EventArgs e)
        {
            uvCoords[2] = new PointF((float)Math.Round(trackBarX3.Value / 100.0, 2), (float)Math.Round(trackBarY3.Value / 100.0, 2));

            textBoxY3.Text = "" + Math.Round(trackBarY3.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarX4_Scroll(object sender, EventArgs e)
        {
            uvCoords[3] = new PointF((float)Math.Round(trackBarX4.Value / 100.0, 2), (float)Math.Round(trackBarY4.Value / 100.0, 2));

            textBoxX4.Text = "" + Math.Round(trackBarX4.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }

        private void trackBarY4_Scroll(object sender, EventArgs e)
        {
            uvCoords[3] = new PointF((float)Math.Round(trackBarX4.Value / 100.0, 2), (float)Math.Round(trackBarY4.Value / 100.0, 2));

            textBoxY4.Text = "" + Math.Round(trackBarY4.Value / 100.0, 2);

            UpdateImageEffects();
            UpdateShapePosition();
        }
    }
}