using System;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args) {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random rnd = new Random();

            int n1 = 30, n2 = 32, n3 = 28;

            double[] a = new double[n1];
            double[] b = new double[n2];
            double[] c = new double[n3];

            int j = 0;
            double v;
            double l;

            for (double i = -2; i <= 4; i = i + 0.3)
            {
                try
                {
                    l = 1 / (i - 1);
                    if (l <= 0)
                    {
                        throw new ArgumentException("Логарифм отрицательного числа или деление на 0!");
                    }

                    a[j] = Math.Log10(l);

                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Ошибка: Выход за границу диапазона!");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    a[j] = 0;
                }

                j++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                b[i] = rnd.NextDouble() * (10 - (-10)) + (-10);
            }

            Console.WriteLine("\n");

            for (int i = 0; i < c.Length; i++)
            {
                try
                {
                    v = a[i] - b[i - 1];

                    if (v < 0)
                    {
                        throw new ArgumentException("Невозможно извлечь корень из отрицательного числа");
                    }
                    else
                    {
                        c[i] = Math.Sqrt(v);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Ошибка: Выход за границу диапазона");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }


            Console.WriteLine("\n\nСодержимое массива а:\n");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(Math.Round(a[i], 2) + "  ");
            }

            Console.WriteLine("\n\nСодержимое массива b:\n");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(Math.Round(b[i], 2) + "  ");
            }

            Console.WriteLine("\n\nСодержимое массива с:\n");
            for (int i = 0; i < c.Length; i++)
            {
                Console.Write(Math.Round(c[i], 2) + "  ");
            }

            Console.WriteLine("\n");
        }
    }
}