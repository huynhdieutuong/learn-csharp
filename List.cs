using System;
using System.Collections.Generic;

namespace _List
{
    public class Program
    {
        static void PrintList(List<int> list)
        {
            Console.Write("Print numbers in list: "); // 2.3 Like array
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("Print products in list: ");
            foreach (var item in products)
            {
                Console.WriteLine($"ID: {item.ID}. Name: {item.Name}. Price: {item.Price}. Origin: {item.Origin}");
            }
            Console.WriteLine();
        }
        static void Main()
        {
            List<int> list1 = new List<int>();
            list1.Add(1); // 1.1 Add 1 to list
            list1.Add(2);
            list1.AddRange(new int[] { 3, 4, 5 }); // 1.2 Add array to list

            Console.WriteLine(list1.Count); // 1.3 Count numbers in list = 5
            Console.WriteLine(list1[1]); // 1.4 Get number at index 1

            Console.WriteLine("=====================");

            List<int> list2 = new List<int>() { 7, 8, 9, 7 }; // 2.1 Can init number at here
            list2.Insert(1, 10); // 2.2 Insert 10 at index 1
            PrintList(list2);

            list2.RemoveAt(2); // 2.4 Remove number at index 2
            list2.Remove(7); // 2.5 Remove number 7 (first) in list
            list2.RemoveAll(x => x < 9); // 2.6 Remove all numbers < 9
            list2.Clear(); // 2.7 Remove all list
            int result = list2.Find(x => x >= 9); // 2.8 Find one number (fist) >= 9
            List<int> newList = list2.FindAll(x => x >= 9); // 2.9 Find all numbers >= 9

            Console.WriteLine("=====================");

            List<Product> products = new List<Product>() {
                new Product() { Name = "Iphone X", Price = 1000, ID = 1, Origin = "China" },
                new Product() { Name = "Samsung", Price = 800, ID = 2, Origin = "Korea" },
                new Product() { Name = "Sony", Price = 1100, ID = 3, Origin = "Japan" },
                new Product() { Name = "Nokia", Price = 500, ID = 4, Origin = "China" },
            };
            PrintProducts(products);

            // List<Product> foundProducts = products.FindAll(x => x.Name.StartsWith("S"));
            // PrintProducts(foundProducts);

            products.Sort((p1, p2) => // 3. Sort Price
            {
                if (p1.Price > p2.Price) return 1;
                if (p1.Price < p2.Price) return -1;
                return 0;
            });
            PrintProducts(products);
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }
        public string Origin { get; set; }
    }
}