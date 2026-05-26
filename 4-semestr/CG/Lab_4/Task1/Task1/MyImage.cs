using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    internal class MyImage
    {
        public Bitmap LoadedImage { get; set; }
        private Bitmap OriginalImage { get; set; }

        public MyImage(Bitmap LoadedImage)
        {
            this.LoadedImage = LoadedImage;
            this.OriginalImage = new Bitmap(LoadedImage);
        }

        public void ApplyEffects(double F, int V, double S)
        {
            if (LoadedImage == null) return;

            int width = LoadedImage.Width;
            int height = LoadedImage.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color oldColor = OriginalImage.GetPixel(x, y);

                    double r = oldColor.R;
                    double g = oldColor.G;
                    double b = oldColor.B;

                    double Y = 0.299 * r + 0.587 * g + 0.114 * b;

                    r += V;
                    g += V;
                    b += V;

                    r = F * (r - 128) + 128;
                    g = F * (g - 128) + 128;
                    b = F * (b - 128) + 128;

                    r = Y + S * (r - Y);
                    g = Y + S * (g - Y);
                    b = Y + S * (b - Y);

                    int finalR = Math.Max(0, Math.Min(255, (int)r));
                    int finalG = Math.Max(0, Math.Min(255, (int)g));
                    int finalB = Math.Max(0, Math.Min(255, (int)b));

                    Color newColor = Color.FromArgb(finalR, finalG, finalB);
                    LoadedImage.SetPixel(x, y, newColor);
                }
            }
        }

        public void Dispose()
        {
            LoadedImage?.Dispose();
            OriginalImage?.Dispose();
        }
    }
}
