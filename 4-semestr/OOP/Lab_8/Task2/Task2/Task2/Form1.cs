using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Task2
{
    public partial class Form1 : Form
    {
        string connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = D:\TSTU\4-semestr\OOP\Lab_8\Task2\Task2\Task2\HotelBase.mdf; Integrated Security = True";
        string table = "Rooms";

        private void LoadRooms()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    string query;

                    if (table == "RegistrationJournal")
                    {
                        query = @"
                    SELECT 
                        RJ.Id AS [ID Записи], 
                        G.FullName AS [ФИО Гостя], 
                        R.RoomNumber AS [Номер комнаты], 
                        RJ.CheckInDate AS [Дата заселения], 
                        E.FullName AS [Сотрудник]
                    FROM RegistrationJournal RJ
                    INNER JOIN Guests G ON RJ.GuestId = G.Id
                    INNER JOIN Rooms R ON RJ.RoomId = R.Id
                    INNER JOIN Employees E ON RJ.EmployeeId = E.Id";
                    }
                    else
                    {
                        query = $"SELECT * FROM {table}";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Номер комнаты:";
            label2.Text = "Тип номера:";
            label3.Text = "Цена за день:";
            label4.Text = "";
            LoadRooms();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString()) {
                case "Номера":
                    label1.Text = "Номер комнаты:";
                    label2.Text = "Тип номера:";
                    label3.Text = "Цена за день:";
                    label4.Text = "";
                    table = "Rooms";
                    break;
                case "Сотрудники":
                    label1.Text = "ФИО сотрудника:";
                    label2.Text = "Должность:";
                    label3.Text = "";
                    label4.Text = "";
                    table = "Employees";
                    break;
                case "Проживающие":
                    label1.Text = "ФИО гостя:";
                    label2.Text = "Паспортные данные:";
                    label3.Text = "";
                    label4.Text = "";
                    table = "Guests";
                    break;
                case "Журнал регистрации":
                    label1.Text = "ID гостя:";
                    label2.Text = "ID комнаты:";
                    label3.Text = "Дата заселения:";
                    label4.Text = "Сотрудник";
                    table = "RegistrationJournal";
                    break;
                default:
                    break;
            }

            LoadRooms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    try
                    {
                        switch (table)
                        {
                            case "Rooms":
                                query = "INSERT INTO Rooms (RoomNumber, Type, Price) VALUES (@param1, @param2, @param3)";
                                command.Parameters.AddWithValue("@param1", Convert.ToInt32(textBox1.Text));
                                command.Parameters.AddWithValue("@param2", string.IsNullOrWhiteSpace(textBox2.Text) ? (object)DBNull.Value : textBox2.Text);
                                command.Parameters.AddWithValue("@param3", Convert.ToDecimal(textBox3.Text));
                                break;

                            case "Employees":
                                query = "INSERT INTO Employees (FullName, Position) VALUES (@param1, @param2)";
                                command.Parameters.AddWithValue("@param1", textBox1.Text);
                                command.Parameters.AddWithValue("@param2", textBox2.Text);
                                break;

                            case "Guests":
                                query = "INSERT INTO Guests (FullName, Passport) VALUES (@param1, @param2)";
                                command.Parameters.AddWithValue("@param1", textBox1.Text);
                                command.Parameters.AddWithValue("@param2", textBox2.Text);
                                break;

                            case "RegistrationJournal":
                                query = "INSERT INTO RegistrationJournal (GuestId, RoomId, CheckInDate, EmployeeId) VALUES (@param1, @param2, @param3, @param4)";
                                command.Parameters.AddWithValue("@param1", Convert.ToInt32(textBox1.Text));
                                command.Parameters.AddWithValue("@param2", Convert.ToInt32(textBox2.Text));

                                command.Parameters.AddWithValue("@param3", Convert.ToDateTime(textBox3.Text));
                                command.Parameters.AddWithValue("@param4", Convert.ToInt32(textBox4.Text));
                                break;
                        }

                        command.CommandText = query;
                        connection.Open();
                        command.ExecuteNonQuery(); 

                        MessageBox.Show("Данные успешно добавлены!");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();

                        LoadRooms();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                    }
                }
            }
        }
    }
}
