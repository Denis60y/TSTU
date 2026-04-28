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

        private Bitmap backgroundBmp; 
        private bool shapeIsDrawn = false; 

        private string lastShapeType;
        private Color lastPenColor;
        private float lastPenThickness;
        private Color lastFillColor;
        private bool lastDoFill;
        private bool lastDrawOutline;

        public Form1()
        {

            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox1.Items.Add("Отсутствует");
            comboBox1.Items.Add(Color.Yellow);
            comboBox1.Items.Add(Color.Red);
            comboBox1.Items.Add(Color.Green);
            comboBox1.Items.Add(Color.Blue);
            comboBox1.Items.Add(Color.Black);
            comboBox1.Items.Add(Color.Purple);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(new string[] {"Прямая", "Окружность", "Прямоугольник"});
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Add("Отсутствует");
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

                backgroundBmp = new Bitmap(bmp);
                shapeIsDrawn = false; 

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

            backgroundBmp = new Bitmap(bmp); 

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

            backgroundBmp = new Bitmap(bmp); 

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

        private void UpdateDrawing()
        {
            if (backgroundBmp == null || !shapeIsDrawn) return;

            Bitmap tempBmp = new Bitmap(backgroundBmp);

            using (Graphics g = Graphics.FromImage(tempBmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.TranslateTransform(tempBmp.Width / 2 + trackBar1.Value, tempBmp.Height / 2 + trackBar2.Value);
                g.RotateTransform(trackBar5.Value);

                float sX = trackBar3.Value / 100f;
                float sY = trackBar4.Value / 100f;
                g.ScaleTransform(sX <= 0 ? 0.01f : sX, sY <= 0 ? 0.01f : sY);

                using (Pen pen = new Pen(lastPenColor, lastPenThickness))
                using (Brush brush = new SolidBrush(lastFillColor))
                {
                    int size = 100;
                    int r = -size / 2;

                    if (lastShapeType == "Прямоугольник")
                    {
                        if (lastDoFill) g.FillRectangle(brush, r, r, size, size);
                        if (lastDrawOutline) g.DrawRectangle(pen, r, r, size, size);
                    }
                    else if (lastShapeType == "Окружность")
                    {
                        if (lastDoFill) g.FillEllipse(brush, r, r, size, size);
                        if (lastDrawOutline) g.DrawEllipse(pen, r, r, size, size);
                    }
                    else if (lastShapeType == "Прямая")
                    {
                        if (lastDrawOutline) g.DrawLine(pen, r, 0, r + size, 0);
                    }
                }
            }

            if (pictureBox1.Image != null && pictureBox1.Image != backgroundBmp)
                pictureBox1.Image.Dispose();

            bmp = tempBmp;
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (backgroundBmp == null)
            {
                if (bmp != null) backgroundBmp = new Bitmap(bmp);
                else { MessageBox.Show("Загрузите изображение!"); return; }
            }

            lastShapeType = comboBox2.SelectedItem.ToString();

            lastDrawOutline = comboBox1.SelectedIndex > 0; 
            if (lastDrawOutline)
                lastPenColor = (Color)comboBox1.SelectedItem;
            else
                lastPenColor = Color.Transparent;

            lastDoFill = comboBox3.SelectedIndex > 0; 
            if (lastDoFill)
                lastFillColor = (Color)comboBox3.SelectedItem;
            else
                lastFillColor = Color.Transparent;

            if (!float.TryParse(textBox1.Text, out lastPenThickness))
                lastPenThickness = 2f;

            shapeIsDrawn = true;
            UpdateDrawing();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bmp == null || !shapeIsDrawn) return;

            backgroundBmp = new Bitmap(bmp);

            shapeIsDrawn = false;

            ResetTrackBars();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            UpdateDrawing();
        }

        private void ResetTrackBars()
        {
            trackBar1.Value = 0;   
            trackBar2.Value = 0;   
            trackBar3.Value = 100; 
            trackBar4.Value = 100; 
            trackBar5.Value = 0;   
        }
    }
}
