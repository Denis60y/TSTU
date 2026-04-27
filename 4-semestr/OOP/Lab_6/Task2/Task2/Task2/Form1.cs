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

        private Bitmap bmp;

        public Form1()
        {

            InitializeComponent();

        }    

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.PNG) | *.bmp; *.jpg; *.gif; *.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);

                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width; 
                pictureBox1.Height = height;

                bmp = new Bitmap(image, width, height); ;

                pictureBox1.Image = bmp;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;
                    int Gray = (R + G + B) / 3;
                    Color p = Color.FromArgb(255, Gray, Gray,
                        Gray);
                    bmp.SetPixel(i, j, p);
                }
            Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width/2; i++)
                for (int j = 0; j < bmp.Height/2; j++)
                {
                    int R = bmp.GetPixel(i, j).R;

                    Color p = Color.FromArgb(255, R, 0, 0);
                    bmp.SetPixel(i, j, p);
                }

            for (int i = bmp.Width / 2; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height / 2; j++)
                {
                    int G = bmp.GetPixel(i, j).G;

                    Color p = Color.FromArgb(255, 0, G, 0);
                    bmp.SetPixel(i, j, p);
                }

            for (int i = 0; i < bmp.Width/2; i++)
                for (int j = bmp.Height / 2; j < bmp.Height; j++)
                {
                    int B = bmp.GetPixel(i, j).B;

                    Color p = Color.FromArgb(255, 0, 0, B);
                    bmp.SetPixel(i, j, p);
                }

            for (int i = bmp.Width / 2; i < bmp.Width; i++)
                for (int j = bmp.Height / 2; j < bmp.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;

                    int Gray = (R + G + B) / 3;

                    Color p = Color.FromArgb(255, Gray, Gray,Gray);
                    bmp.SetPixel(i, j, p);
                }

            Refresh();
        }
    }
}
