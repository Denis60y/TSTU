using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        String result;

        public Form1()
        {
            Random rand = new Random();

            int[,] mas = new int[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas[i, j] = rand.Next(-50, 51);
                }
            }

            int count = 0;

            for (int i = 0; i < 5; i++) { 
                if (mas[i, 4] > 0)
                {
                    count++;
                }
            }


            if (count < 3)
            {
                String res = "";

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (mas[i, j] > 0) {
                            res += mas[i, j] + "  ";
                        }
                    }
                }

                result = res;

            }
            else
            {
                int res = 0;

                for (int i = 0; i < 5; i++) { res += mas[i, i]; }

                result = res.ToString();

            }

            String vod = " ";

            for (int i = 0; i < 5; i++)
            {

                vod += "\r\n";

                for (int j = 0; j < 5; j++)
                {
                    vod += mas[i, j] + "  ";
                }
            }


            InitializeComponent();

            textBox1.Text = vod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = $"Результат:\n{result}";
        }
    }
}
