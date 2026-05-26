using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
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

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            int[,] zBuffer = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    zBuffer[x, y] = int.MaxValue;
                }
            }

            Bitmap nextBmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(nextBmp))
            {
                g.Clear(Color.White);
            }

            foreach (var square in squares)
            {
                Rectangle r = square.Rect;

                for (int x = r.Left; x < r.Right; x++)
                {
                    for (int y = r.Top; y < r.Bottom; y++)
                    {
                        if (x >= 0 && x < width && y >= 0 && y < height)
                        {
                            if (square.ZIndex < zBuffer[x, y])
                            {
                                nextBmp.SetPixel(x, y, square.SquareColor);

                                zBuffer[x, y] = square.ZIndex;
                            }
                        }
                    }
                }
            }

            squares.Clear();

            Image oldImage = pictureBox1.Image;
            pictureBox1.Image = nextBmp;
            oldImage?.Dispose();
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
