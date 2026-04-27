using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Task2
{
    abstract class Software: IComparable
    {
        public string Title { get; set; }
        public string Manufacturer { get; set; }

        public Software(string title, string manufacturer)
        {
            Title = title;
            Manufacturer = manufacturer;
        }

        public abstract void GetInfo();
        public abstract bool IsUse(); 

        public int CompareTo(object obj)
        {
            Software soft = (Software)obj; 
            return this.Title.CompareTo(soft.Title);
        }
    }

    class FreeSoftware : Software
    {
        public FreeSoftware(string title, string manufacturer) : base(title, manufacturer) { }

        public override void GetInfo()
        {
            Console.WriteLine($"Название программного обеспечения: {Title}");
            Console.WriteLine($"Производитель программного обеспечения: {Manufacturer}");
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

        public override void GetInfo()
        {
            Console.WriteLine($"Название программного обеспечения: {Title}");
            Console.WriteLine($"Производитель программного обеспечения: {Manufacturer}");
            Console.WriteLine($"Дата установки программного обеспечения: {Data.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Срок использования программного обеспечения: {TrialDays}");
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

        public override void GetInfo()
        {
            Console.WriteLine($"Название программного обеспечения: {Title}");
            Console.WriteLine($"Производитель программного обеспечения: {Manufacturer}");
            Console.WriteLine($"Цена программного обеспечения: {Price}");
            Console.WriteLine($"Дата установки программного обеспечения: {Data.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Срок использования программного обеспечения: {TrialDays}");
        }

        public override bool IsUse()
        {
            return DateTime.Now < Data.AddDays(TrialDays);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Software[] soft = new Software[5];

            soft[0] = new FreeSoftware("LibreOffice", "The Document Foundation");
            soft[1] = new FreeSoftware("Mozilla Firefox", "Mozilla Corporation");
            soft[2] = new Shareware("WinRAR", "win.rar GmbH", new DateTime(2026, 4, 10), 5);
            soft[3] = new Shareware("Kaspersky Internet Security", "Лаборатория Касперского", new DateTime(2026, 4, 10), 30);
            soft[4] = new CommercialSoftware("Microsoft Office", "Microsoft", 14900, new DateTime(2026, 4, 10), 365);

            for (int i = 0; i < soft.Length; i++)
            {
                soft[i].GetInfo();
                Console.WriteLine("\n");
            }

            Console.WriteLine("Программное обеспечение, которое допустимо использовать на текущую дату:");

            for (int i = 0; i < soft.Length; i++)
            {
                if (soft[i].IsUse())
                {
                    Console.WriteLine(soft[i].Title);
                }
            }

            Console.WriteLine("\nМассив до сортировки:");
            foreach (Software x in soft)
            {
                Console.WriteLine(x.Title + " ");
            }

            Console.WriteLine("\nМассив после сортировки:");
            Array.Sort(soft);

            foreach(Software x in soft)
            {
                Console.WriteLine(x.Title + " ");
            }
        }
    }
}
