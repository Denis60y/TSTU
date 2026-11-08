using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Task1
{
    class Cylinder
    {
        public double Radius { get; set; } = 0;
        public double Height { get; set; } = 0;

        public double V()
        {
            return Math.Pow(Radius, 2) * Math.PI * Height;
        }

        public double S()
        {
            return Math.Pow(Radius, 2) * Math.PI * 2 + 2 * Math.PI * Radius * Height;
        }

        public void getInfo()
        {
            Console.WriteLine("Информация об объекте \"Цилиндр\"");
            Console.WriteLine($"Радиус основания: {Radius}");
            Console.WriteLine($"Образующая цилиндра: {Height}");
            Console.WriteLine($"Объем фигуры: {V()}");
            Console.WriteLine($"Площадь поверхности фигуры: {S()}");
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            Cylinder c = new Cylinder();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие");
                Console.WriteLine("[1] Поменять значение радиуса основания цилиндра");
                Console.WriteLine("[2] Поменять значение высоты цилиндра");
                Console.WriteLine("[3] Объем фигуры");
                Console.WriteLine("[4] Площадь поверхности фигуры");
                Console.WriteLine("[5] Получить всю информацию о цилиндре");
                Console.WriteLine("[6] Закрыть программу\n\n");
                Console.Write("Ваш выбор: ");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Нынешнее значение радиуса основания: {c.Radius}");
                        Console.Write("Новое значение: ");
                        c.Radius = Convert.ToDouble(Console.ReadLine());
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"Нынешнее значение высоты цилиндра: {c.Height}");
                        Console.Write("Новое значение: ");
                        c.Height = Convert.ToDouble(Console.ReadLine());
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine($"Объем цилиндра: {c.V()}");
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine($"Площадь поверхности цилиндра: {c.S()}");
                        break;
                    case "5":
                        Console.Clear();
                        c.getInfo();
                        break;
                    case "6":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                if (answer == "6")
                {
                    break;
                }

                Console.WriteLine("\n\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey(true);
            }
        }
    }
}