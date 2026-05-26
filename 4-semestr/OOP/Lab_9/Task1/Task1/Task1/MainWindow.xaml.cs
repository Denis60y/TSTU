using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        abstract class Software
        {
            public string Title { get; set; }
            public string Manufacturer { get; set; }

            public Software(string title, string manufacturer)
            {
                Title = title;
                Manufacturer = manufacturer;
            }

            public abstract string GetInfo();
            public abstract bool IsUse();
        }

        class FreeSoftware : Software
        {
            public FreeSoftware(string title, string manufacturer) : base(title, manufacturer) { }

            public override string GetInfo()
            {
                return $"Название программного обеспечения: {Title}\nПроизводитель программного обеспечения: {Manufacturer}\n";
            }

            public override bool IsUse()
            {
                return true;
            }
        }

        class Shareware : Software
        {
            public DateTime Data { get; set; }
            public int TrialDays { get; set; }

            public Shareware(string title, string manufacturer, DateTime data, int trialDays) : base(title, manufacturer)
            {
                Data = data;
                TrialDays = trialDays;
            }

            public override string GetInfo()
            {
                return $"Название программного обеспечения: {Title}\nПроизводитель программного обеспечения: {Manufacturer}\nДата установки программного обеспечения: {Data.ToString("yyyy-MM-dd")}\nСрок использования программного обеспечения: {TrialDays}\n";
            }

            public override bool IsUse()
            {
                return DateTime.Now < Data.AddDays(TrialDays);
            }
        }

        class CommercialSoftware : Software
        {
            public int Price { get; set; }
            public DateTime Data { get; set; }
            public int TrialDays { get; set; }

            public CommercialSoftware(string title, string manufacturer, int price, DateTime data, int trialDays) : base(title, manufacturer)
            {
                Price = price;
                Data = data;
                TrialDays = trialDays;
            }

            public override string GetInfo()
            {
                return $"Название программного обеспечения: {Title}\nПроизводитель программного обеспечения: {Manufacturer}\nЦена программного обеспечения: {Price}\nДата установки программного обеспечения: {Data.ToString("yyyy-MM-dd")}\nСрок использования программного обеспечения: {TrialDays}\n";
            }

            public override bool IsUse()
            {
                return DateTime.Now < Data.AddDays(TrialDays);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        List<Software> softwareList = new List<Software>();
        string text;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox.Text == "Свободное")
            {
                softwareList.Add(new FreeSoftware(title.Text, manufacturer.Text));
                label.Content = string.Empty;

                text = string.Empty;
                text += "Список программного обеспечения:\n";

                foreach (Software software in softwareList) 
                {
                    text += software.GetInfo() + "\n";
                }

                text += "\nПрограммное обеспечение, которое допустимо использовать на текущую дату:\n";

                foreach (Software software in softwareList)
                {
                    if (software.IsUse())
                    {
                        text += software.Title + "\n";
                    }
                }

                label.Content = text;
            }
            else if(comboBox.Text == "Условно-бесплатное")
            {
                softwareList.Add(new Shareware(title.Text, manufacturer.Text, Convert.ToDateTime(data.Text), Convert.ToInt32(trialDays.Text)));
                label.Content = string.Empty;

                text = string.Empty;
                text += "Список программного обеспечения:\n";

                foreach (Software software in softwareList)
                {
                    text += software.GetInfo() + "\n";
                }

                text += "\nПрограммное обеспечение, которое допустимо использовать на текущую дату:\n";

                foreach (Software software in softwareList)
                {
                    if (software.IsUse())
                    {
                        text += software.Title + "\n";
                    }
                }

                label.Content = text;
            }
            else if (comboBox.Text == "Коммерческое")
            {
                softwareList.Add(new CommercialSoftware(title.Text, manufacturer.Text, Convert.ToInt32(price.Text), Convert.ToDateTime(data.Text), Convert.ToInt32(trialDays.Text)));
                label.Content = string.Empty;

                text = string.Empty;
                text += "Список программного обеспечения:\n";

                foreach (Software software in softwareList)
                {
                    text += software.GetInfo() + "\n";
                }

                text += "\nПрограммное обеспечение, которое допустимо использовать на текущую дату:\n";

                foreach (Software software in softwareList)
                {
                    if (software.IsUse())
                    {
                        text += software.Title + "\n";
                    }
                }

                label.Content = text;
            }
            else
            {
                MessageBox.Show("Выберите тип программного обеспечения");
            }
        }
    }
}
