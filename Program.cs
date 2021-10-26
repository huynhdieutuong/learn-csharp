using System;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Sum: " + Methods.Sum(10, 20));
            // Console.WriteLine("Sum (overload): " + Methods.Sum(10f, 20f));

            // Methods.Calculator();

            // Methods.PrintName("John", "Doe");
            // Methods.PrintName("John");
            // Methods.PrintName(lastName: "Doe");

            // Methods.PrintNumber();

            // Class is reference without ref or out
            Count count = new Count();
            System.Console.WriteLine("Before: " + count.c);
            Methods.Counter(count);
            System.Console.WriteLine("After: " + count.c);
        }
    }
}
