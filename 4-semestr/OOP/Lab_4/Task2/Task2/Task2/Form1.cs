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
        int[] mas;
        int min;

        public Form1()
        {
            InitializeComponent();

            Random rand = new Random();

            String massiv = "";

            mas = new int[rand.Next(5, 15)];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(-33, 67);
                massiv += mas[i].ToString() + " ";
            }

            label1.Text = massiv;
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            Array.Sort(mas);

            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 != 0)
                {
                    min = mas[i];
                    break;
                }
            }

            label4.Text = min.ToString();

        }
    }
}
