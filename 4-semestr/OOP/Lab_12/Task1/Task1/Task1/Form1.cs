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

namespace Task1
{
    public partial class Form1 : Form
    { 

        public string Counter(StreamReader file)
        {
            int count = 0, i = 0;
            string s;
            List<string> stroki = new List<string>();

            while ((s = file.ReadLine()) != null){
                stroki.Add(s);
                if (stroki[i][0] == stroki[i][s.Length - 1])
                    count ++;
                i++;
            }

            return count + "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader file = null;

            try
            {
                file = new StreamReader(textBox1.Text);
                label1.Text = "Количество строк с одинаковыми первым и последним символом: " + Counter(file);
            }
            catch (IOException exc) { 
                Console.WriteLine("Ошибка открытия файла:\n" + exc.Message);
            }
            finally {
                if (file != null) { file.Close(); }
            }
        }
    }
}
