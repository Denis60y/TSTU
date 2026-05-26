namespace Task1
{
    class Program
    {
        private static int Add1(int x) { return x + 1; }
        private static int Add2(int x) { return x + 2; }
        private static int Add3(int x) { return x + 3; }
        private static int Add4(int x) { return x + 4; }
        private static int Add5(int x) { return x + 5; }
        private static int Multi1(int x) { return x * 1; }
        private static int Multi2(int x) { return x * 2; }
        private static int Multi3(int x) { return x * 3; }
        private static int Multi4(int x) { return x * 4; }
        private static int Multi5(int x) { return x * 5; }

        delegate int Operation(int x);

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Operation znak = Add1;
            znak += Add2;
            znak += Add3;
            znak += Add4;
            znak += Add5;
            znak += Multi1;
            znak += Multi2;
            znak += Multi3;
            znak += Multi4;
            znak += Multi5;

            int num1 = 4;

            Console.WriteLine($"Изначальное число: {num1}");

            foreach (Operation op in znak.GetInvocationList())
            {
                Console.WriteLine($"Результат работы функции {op.Method.Name}: {op(num1)}");
            }

        }
    }
}