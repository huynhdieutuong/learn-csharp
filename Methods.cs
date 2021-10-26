using System;

namespace CS002
{
    public class Count
    {
        public int c = 1;
    }

    public class Methods
    {
        public static void Counter(Count count)
        {
            count.c++;
        }

        // Default
        public static void PrintName(string firstName = "John", string lastName = "James")
        {
            System.Console.WriteLine(ConcatName(firstName, lastName));
        }
        static string ConcatName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        // Ref, Out (reference)
        public static void PrintNumber()
        {
            int n = 1;
            IncreaseNumber(out n);
            System.Console.WriteLine(n);
        }
        static void IncreaseNumber(out int n)
        {
            n = 2;
        }

        // Over load
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static float Sum(float a, float b)
        {
            return a + b;
        }

        // Void
        public static void Calculator()
        {
            Console.Write("Please enter number a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Please enter number b: ");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Please select a calculation: ");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Sub");
            Console.WriteLine("3. Mul");
            Console.WriteLine("4. Div");

        L1:
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (c)
            {
                case '1':
                    Console.WriteLine($"Sum: {a + b}");
                    break;
                case '2':
                    Console.WriteLine($"Sub: {a - b}");
                    break;
                case '3':
                    Console.WriteLine($"Mul: {a * b}");
                    break;
                case '4':
                    Console.WriteLine($"Div: {(float)a / b}");
                    break;
                default:
                    System.Console.WriteLine("Please select another calculation:");
                    goto L1;
                    break;
            }
        }
    }
}