using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public struct WuPoint
        {
            public int X { get; set; }
            public int Y { get; set; }
            public double Intensity { get; set; } 

            public WuPoint(int x, int y, double intensity)
            {
                X = x;
                Y = y;
                Intensity = intensity;
            }
        }

        List<Point> points = new List<Point>();
        List<WuPoint> wuPoints = new List<WuPoint>();
        List<Point> circlepoints = new List<Point>();

        public int x1, y1, x2, y2;

        Bitmap bmp;
        int scale = 10;

        //-------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bresenham(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Point point in points)
                {
                    int screenX = point.X * scale;
                    int screenY = pictureBox1.Height - (point.Y * scale) - scale;

                    if (screenX >= 0 && screenX < bmp.Width && screenY >= 0 && screenY < bmp.Height)
                    {
                        g.FillRectangle(Brushes.Black, screenX, screenY, scale, scale);
                    }
                }
            }

            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Wu(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (WuPoint wuPoint in wuPoints)
                {
                    int screenX = wuPoint.X * scale;
                    int screenY = pictureBox1.Height - (wuPoint.Y * scale) - scale;

                    if (screenX >= 0 && screenX < bmp.Width && screenY >= 0 && screenY < bmp.Height)
                    {
                        int rgbVal = (int)((1.0 - wuPoint.Intensity) * 255);

                        if (rgbVal > 255) rgbVal = 255;
                        if (rgbVal < 0) rgbVal = 0;

                        using (Brush brush = new SolidBrush(Color.FromArgb(rgbVal, rgbVal, rgbVal)))
                        {
                            g.FillRectangle(brush, screenX, screenY, scale, scale);
                        }
                    }
                }
            }

            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BresenhamCircle(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text));

            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Point cpoint in circlepoints)
                {
                    int screenX = cpoint.X * scale;
                    int screenY = pictureBox1.Height - (cpoint.Y * scale) - scale;

                    if (screenX >= 0 && screenX < bmp.Width && screenY >= 0 && screenY < bmp.Height)
                    {
                        g.FillRectangle(Brushes.Black, screenX, screenY, scale, scale);
                    }
                }
            }

            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            pictureBox1.Image = bmp;
        }

        //---------------------------------------------------------------------------

        public void Bresenham(int x1, int y1, int x2, int y2)
        {
            points.Clear();

            points.Add(new Point(x1, y1));

            double dx = Math.Abs(x2 - x1);
            double dy = Math.Abs(y2 - y1);

            double di;

            int signX, signY;

            if (x1 < x2){ signX = 1; }
            else{ signX = -1; }

            if (y1 < y2){ signY = 1; }
            else{ signY = -1; }

            int x = x1;
            int y = y1;

            if (dx > dy)
            {
                di = 2 * dy - dx;

                for (int i = 0; i < dx; i++)
                {
                    if (di >= 0)
                    {
                        y += signY;
                        di += 2 * (dy - dx);
                    }
                    else
                    {
                        di += 2 * dy;
                    }
                    x += signX; 

                    points.Add(new Point(x, y));
                }
            }
            else
            {
                di = 2 * dx - dy;

                for (int i = 0; i < dy; i++)
                {
                    if (di >= 0)
                    {
                        x += signX;
                        di += 2 * (dx - dy);
                    }
                    else
                    {
                        di += 2 * dx;
                    }
                    y += signY; 

                    points.Add(new Point(x, y));
                }
            }
        }

        public void Wu(int x1, int y1, int x2, int y2) {
            wuPoints.Clear();

            bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            if (steep)
            {
                int temp;
                temp = x1; x1 = y1; y1 = temp;
                temp = x2; x2 = y2; y2 = temp;
            }

            if (x1 > x2)
            {
                int temp;
                temp = x1; x1 = x2; x2 = temp;
                temp = y1; y1 = y2; y2 = temp;
            }

            double dx = x2 - x1;
            double dy = y2 - y1;

            double K, Ye, F;
            Ye = y1;
            K = dy / dx;

            int yBase;

            for (int x = x1; x <= x2; x++)
            {
                F = Ye - Math.Floor(Ye);
                yBase = (int)Math.Floor(Ye);

                if (steep)
                {
                    wuPoints.Add(new WuPoint(yBase, x, 1 - F));
                    wuPoints.Add(new WuPoint(yBase + 1, x, F));
                }
                else
                {
                    wuPoints.Add(new WuPoint(x, yBase, 1 - F));
                    wuPoints.Add(new WuPoint(x, yBase + 1, F));
                }

                Ye += K;
            }
        }

        public void BresenhamCircle(int x1, int y1, int r)
        {
            circlepoints.Clear();

            int S, T, di, Di;
            int x = 0;
            int y = r;

            int d = 3 - 2 * r;

            while (x <= y)
            {
                circlepoints.Add(new Point(x1 + x, y1 + y));
                circlepoints.Add(new Point(x1 + x, y1 - y));
                circlepoints.Add(new Point(x1 - x, y1 + y));
                circlepoints.Add(new Point(x1 - x, y1 - y));
                circlepoints.Add(new Point(x1 + y, y1 + x));
                circlepoints.Add(new Point(x1 + y, y1 - x));
                circlepoints.Add(new Point(x1 - y, y1 + x));
                circlepoints.Add(new Point(x1 - y, y1 - x));

                x++;

                if (d >= 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }
            }
        }

    }
}
