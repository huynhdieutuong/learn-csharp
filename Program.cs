using System;
using static CS002.Struct;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1;
            product1.name = "Iphone";
            product1.price = 1000;
            // product1.GetInfo();

            Product product2 = new Product("Nokia", 800);
            // product2.GetInfo();
            product2 = product1;
            product2.name = "Iphone X";

            System.Console.WriteLine(product1.Info);
            System.Console.WriteLine(product2.Info);
        }
    }
}
