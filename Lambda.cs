using System;
using System.Linq;

namespace Lambda
{
    // Lambda - Anonymous method
    // Use with Delegate
    public class Program
    {
        static void Main()
        {
            // 1) (int a, int b) => a + b;
            Action<string> log;
            // log = (string s) => Console.WriteLine(s); // Use lambda method
            // log = (s) => Console.WriteLine(s); // Don't need declare string for s
            log = s => Console.WriteLine(s); // Also don't need () if only have one variable
            log?.Invoke("Hello");

            System.Console.WriteLine("==========");

            /*
            2) (int a, int b) => {
                int sum = a + b;
                return sum;
            }
            */
            Action<string, int> product;
            product = (name, price) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Name: {name}. Price: {price}");
                Console.ResetColor();
            };
            product?.Invoke("Iphone", 1000);

            System.Console.WriteLine("==========");

            Func<int, int, double> div;
            div = (a, b) =>
            {
                double result = a / b;
                return result;
            };
            System.Console.WriteLine("Result: " + div?.Invoke(20, 10));

            System.Console.WriteLine("===========");
            int[] numbers = { 2, 4, 6, 7, 43, 78, 75, 54 };
            // Since Select receive Delegate, can use Lambda
            var result = numbers.Select(x => Math.Sqrt(x)); // ****** Select(Delegate) = ~ Select(Lambda) ******
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}