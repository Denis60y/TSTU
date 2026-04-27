using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Task1
{
    public partial class Form1 : Form
    {
        class Flight
        {
            public string CityA { get; set; }
            public string CityB { get; set; }
            public string Date1 { get; set; }
            public string Date2 { get; set; }
            public string Voyage { get; set; }
            public string Airline { get; set; }
            public string Status { get; set; }

            public Flight(string cityA, string cityB, string date1, string date2, string voyage, string airline, string status)
            {
                CityA = cityA;
                CityB = cityB;
                Date1 = date1;
                Date2 = date2;
                Voyage = voyage;
                Airline = airline;
                Status = status;
            }

        }

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("CityA", "Откуда");
            dataGridView1.Columns.Add("CityB", "Направление");
            dataGridView1.Columns.Add("Date1", "Дата и время отпраки");
            dataGridView1.Columns.Add("Date2", "Дата и время прибытия");
            dataGridView1.Columns.Add("Voyage", "Рейс");
            dataGridView1.Columns.Add("Airline", "Авиакомпания");
            dataGridView1.Columns.Add("Status", "Статус");

            comboBox1.Items.AddRange(new string[] { "Ожидает отправки", "В пути", "Прилетел" });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        List<Flight> flightsList = new List<Flight>();

        private void button1_Click(object sender, EventArgs e)
        {
            flightsList.Add(new Flight(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox1.Text));

            dataGridView1.Rows.Clear();

            foreach (Flight f in flightsList) {
                dataGridView1.Rows.Add(f.CityA, f.CityB, f.Date1, f.Date2, f.Voyage, f.Airline, f.Status);
            }
        }
    }
}
