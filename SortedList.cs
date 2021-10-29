using System;
using System.Collections.Generic;

namespace SortedList
{
    public class Program
    {
        static void PrintProducts(SortedList<string, Product> products)
        {
            Console.WriteLine("Print products in list: ");
            foreach (KeyValuePair<string, Product> item in products) // 1.6 KeyValuePair
            {
                var key = item.Key;
                var value = item.Value;
                Console.WriteLine($"Key: {key}. Name: {value.Name}. Price: {value.Price}. Origin: {value.Origin}");
            }
            Console.WriteLine();
        }

        static void Mainx()
        {
            // 1.1 SortedList to optimize accession for List by Keys
            SortedList<string, Product> products = new SortedList<string, Product>();
            products["product1"] = new Product() { Name = "Iphone", Price = 1000, Origin = "China" }; // products[key] = new Product
            products["product2"] = new Product() { Name = "Samsung", Price = 900, Origin = "Korea" };
            products.Add("product3", new Product() { Name = "Sony", Price = 1100, Origin = "Japan" });
            products.Add("product4", new Product() { Name = "Nokia", Price = 500, Origin = "China" });

            // 1.2
            // var p = products["product2"];
            // Console.WriteLine(p.Name);

            // 1.3
            var keys = products.Keys;
            var values = products.Values;

            // 1.4
            // foreach (var key in keys)
            // {
            //     Console.WriteLine(products[key].Name);
            // }
            // 1.5
            // foreach (var item in values)
            // {
            //     Console.WriteLine(item.Name);
            // }

            PrintProducts(products);

            // 2.1 Remove by key
            products.Remove("product1");
            PrintProducts(products);

            // 2.2 Remove by index
            products.RemoveAt(2);
            PrintProducts(products);
        }
    }
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Origin { get; set; }
    }
}