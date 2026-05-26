using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Task1.MainWindow;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Client
        {
            public string Name { get; set; }
            public int Abonement { get; set; }
            public string Trainer { get; set; }
            public Client (string name, int abonement, string trainer)
            {
                Name = name;
                Abonement = abonement;
                Trainer = trainer;
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Abonement { get; set; }
            public string Programm { get; set; }
            public string Trainer { get; set; }
            public int Price { get; set; }

            public User(int id, string name, int abonement, string programm, string trainer, int price)
            {
                Id = id;
                Name = name;
                Abonement = abonement;
                Programm = programm;
                Trainer = trainer;
                Price = price;
            }
        }

        List<Client> clients = new List<Client>();

        List<User> users = new List<User>();

        int i;
        public MainWindow()
        {
            InitializeComponent();

            MyDataGrid.ItemsSource = users;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            clients.Add(new Client(nameBox.Text, int.Parse(abonementBox.Text), trainerBox.Text));

            users.Clear(); 
            i = 0;

            foreach (Client client in clients) {
                switch (programmBox.Text)
                {
                    case "База":
                        users.Add(new User(++i, client.Name, client.Abonement, programmBox.Text, trainerBox.Text, 3000 * client.Abonement));
                        break;
                    case "Кардио":
                        users.Add(new User(++i, client.Name, client.Abonement, programmBox.Text, trainerBox.Text, 1500 * client.Abonement));
                        break;
                    case "База+Кардио":
                        users.Add(new User(++i, client.Name, client.Abonement, programmBox.Text, trainerBox.Text, 1500 * client.Abonement));
                        break;
                    default:
                        break;
                }
            }

            MyDataGrid.ItemsSource = null;
            MyDataGrid.ItemsSource = users;
        }
    }
}
