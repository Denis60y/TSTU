using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        List<Share> squares = null;

        public Form1()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void updatePictureBox()
        {
            if (!int.TryParse(textBox1.Text, out int z1) ||
                !int.TryParse(textBox2.Text, out int z2) ||
                !int.TryParse(textBox3.Text, out int z3))
            {
                MessageBox.Show("Пожалуйста, введите корректные целые числа для Z-индексов.", "Ошибка ввода");
                return;
            }

            squares = new List<Share>
            {
                new Share(new Rectangle(50 + trackBarX1.Value, 50 + trackBarY1.Value, 100 , 100), Color.FromArgb(255, Color.Red), z1),
                new Share(new Rectangle(90 + trackBarX2.Value, 80 + trackBarY2.Value, 100, 100), Color.FromArgb(255, Color.Blue), z2),
                new Share(new Rectangle(130 + trackBarX3.Value, 110 + trackBarY3.Value, 100 , 100 ), Color.FromArgb(255, Color.Green), z3)
            };

            var sortedSquares = squares.OrderBy(s => s.ZIndex).ToList();

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                foreach (var square in sortedSquares)
                {
                    using (Brush brush = new SolidBrush(square.SquareColor))
                    {
                        g.FillRectangle(brush, square.Rect);
                    }
                }
            }

            squares.Clear();

            pictureBox1.Invalidate();
        }

        private void trackBarX1_Scroll(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void trackBarY1_Scroll(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void trackBarX2_Scroll(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void trackBarY2_Scroll(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void trackBarX3_Scroll(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void trackBarY3_Scroll(object sender, EventArgs e)
        {
            updatePictureBox();
        }
    }
}
