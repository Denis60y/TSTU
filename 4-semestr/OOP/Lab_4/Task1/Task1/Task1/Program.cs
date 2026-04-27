using System;
using System.Net.Mail;

namespace Task1
{
    public class NumberVector {
        public int[] Values { get; set; }

        public NumberVector(params int[] values)
        {
            Values = values;
        }

        public static NumberVector operator +(NumberVector v1, NumberVector v2)
        {
            try
            {
                if (v1.Values.Length != v2.Values.Length)
                {
                    throw new ArgumentException("Длина векторов не совпадает!");
                }

                int[] result = new int[v1.Values.Length];
                for (int i = 0; i < v1.Values.Length; i++)
                {
                    result[i] = v1.Values[i] + v2.Values[i];
                }

                return new NumberVector(result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return new NumberVector();
            }            
        }

        public static NumberVector operator ++(NumberVector vector)
        {
            for (int i = 0; i < vector.Values.Length; i++)
            {
                vector.Values[i]++;
            }

            return vector;
        }

        public void GetInfo()
        {
            if ( Values.Length == 0)
            {
                Console.WriteLine("Вектор пуст");
            }
            else
            {
                Console.Write("Вектор: ");
                for (int i = 0; i < Values.Length; i++)
                {
                    Console.Write(Values[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Program{
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NumberVector v1 = new NumberVector(1, 2, 3);
            NumberVector v2 = new NumberVector(4, 5, 6);
            NumberVector v3 = new NumberVector(7, 8);

            Console.WriteLine("Вектор номер 1:");
            v1.GetInfo();
            Console.WriteLine("Вектор номер 2:");
            v2.GetInfo();
            Console.WriteLine("Вектор номер 3:");
            v3.GetInfo();

            Console.WriteLine("\nРезультат сложения вектора 1 и 2:");
            NumberVector v4 = v1 + v2;
            v4.GetInfo();

            Console.WriteLine("\nРезультат сложения вектора 1 и 3:");
            NumberVector v5 = v1 + v3;
            v5.GetInfo();

            v1++;
            Console.WriteLine("\nВектор 1 после оператора ++");
            v1.GetInfo();
        }
    }
}