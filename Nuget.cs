using System;
using Newtonsoft.Json;

namespace Nuget
{
    class Product
    {
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public string[] Sizes { get; set; }
        override public string ToString() => $"{Name,-10} {Expiry,20} {string.Join(',', Sizes),20}";
    }
    public class Program
    {
        // ***** 1. add & remove package from nuget
        // dotnet add package Name
        // dotnet remove package Name
        // dotnet restore -> to fix error or update package

        // ***** 2. reference package from another project

        // ***** 3. publish & push package to nuget
        static void Mainx()
        {
            // Product product = new Product();
            // product.Name = "Apple";
            // product.Expiry = new DateTime(2008, 12, 28);
            // product.Sizes = new string[] { "Small" };
            // System.Console.WriteLine(product);

            // 1. Convert product to JSON
            // string json = JsonConvert.SerializeObject(product);
            // System.Console.WriteLine(json);

            // 2. Convert JSON to product
            // string json = @"
            //     {
            //         ""Name"":""Apple"",
            //         ""Expiry"":""2008-12-28T00:00:00"",
            //         ""Sizes"":[""Small"", ""Large""]
            //     }
            // ";
            // Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
            // System.Console.WriteLine(deserializedProduct);
        }
    }
}