using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int panelX = 0, panelY = 0, i = 0, j = 0;
        int textBoxX = 0, textBoxY = 0;
        int textBoxCount = 0;


        Panel[] panels = new Panel[16];
        TextBox[] textBoxes = new TextBox[64];


        private void button1_Click(object sender, EventArgs e)
        {
            if (i < panels.Length)
            {
                panels[i] = new Panel();
                panels[i].Parent = this;
                panels[i].Size = new Size(150, 100);
                panels[i].BackColor = Color.Gray;
                panels[i].Location = new Point(170 + panelX * 170, 10 + panelY * 110);

                i++;
                panelY++;

                if (panelY == 4)
                {
                    panelY = 0;
                    panelX++;
                }
            }
            else
            {
                MessageBox.Show("Достигнут максимум панелей");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxCount < 4)
            {
                for (int i = 0; i < panels.Length; i++)
                {
                    textBoxes[j] = new TextBox();
                    textBoxes[j].Size = new Size(70, 45);
                    textBoxes[j].Parent = panels[i];
                    textBoxes[j].Location = new Point(textBoxX * 80, textBoxY * 50);
                    textBoxes[j].BackColor = Color.LightBlue;
                    j++;
                }

                textBoxCount++;
                textBoxY++;

                if (textBoxY == 2)
                {
                    textBoxY = 0;
                    textBoxX++;
                }
            }
            else
            {
                MessageBox.Show("Места на панелях больше нет");
            }
        }
    }
}
