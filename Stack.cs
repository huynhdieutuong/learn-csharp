using System;
using System.Collections.Generic;

// Stack: LIFO (Last In First Out)
// Queue: FIFO (First In First Out)
namespace Stack
{
    public class Program
    {
        static void PrintProducts(Stack<string> products)
        {
            Console.WriteLine("Print products: ");
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
        static void Mainx()
        {
            Stack<string> products = new Stack<string>();
            products.Push("Product 1"); // Add
            products.Push("Product 2");
            products.Push("Product 3");
            PrintProducts(products);

            Console.WriteLine("==============");

            string product3 = products.Pop(); // Remove
            Console.WriteLine(product3);
            PrintProducts(products);
        }
    }
}