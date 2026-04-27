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

namespace Task2
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;

        public Form1()
        {

            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Add(Color.Yellow);
            comboBox1.Items.Add(Color.Red);
            comboBox1.Items.Add(Color.Green);
            comboBox1.Items.Add(Color.Blue);
            comboBox1.Items.Add(Color.Black);
            comboBox1.Items.Add(Color.Purple);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(new string[] {"Прямая", "Окружность", "Прямоугольник"});
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add(Color.Yellow);
            comboBox3.Items.Add(Color.Red);
            comboBox3.Items.Add(Color.Green);
            comboBox3.Items.Add(Color.Blue);
            comboBox3.Items.Add(Color.Black);
            comboBox3.Items.Add(Color.Purple);
            comboBox3.SelectedIndex = 0;


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
            for (int i = 0; i < bmp.Width / 2; i++)
                for (int j = 0; j < bmp.Height / 2; j++)
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

            for (int i = 0; i < bmp.Width / 2; i++)
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

                    Color p = Color.FromArgb(255, Gray, Gray, Gray);
                    bmp.SetPixel(i, j, p);
                }

            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp|GIF Image|*.gif";
            saveDialog.FileName = "processed_image";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Imaging.ImageFormat format;
                string ext = Path.GetExtension(saveDialog.FileName).ToLower();

                switch (ext)
                {
                    case ".jpg":
                    case ".jpeg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ".gif":
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    default:
                        format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                }

                bmp.Save(saveDialog.FileName, format);

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red, 2);
            

        }
    }
}
