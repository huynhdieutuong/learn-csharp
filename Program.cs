using static CS002.Generic;
namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 20;
            System.Console.WriteLine($"a: {a}. b: {b}");
            Swap<double>(ref a, ref b);
            System.Console.WriteLine($"a: {a}. b: {b}");

            System.Console.WriteLine("===========");
            Product<string> product1 = new Product<string>();
            product1.SetID("ABC");
            product1.PrintInfo();
        }
    }
}
