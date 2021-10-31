using System.Collections.Generic;
using System.Linq;

namespace Linq // Language Integrated Query
{
    public class Program
    {
        class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string[] Colors { get; set; }
            public int Brand { get; set; }
            public Product(int id, string name, double price, string[] colors, int brand)
            {
                ID = id;
                Name = name;
                Price = price;
                Colors = colors;
                Brand = brand;
            }
            override public string ToString() // 0. It's automaticly call when Console.Write(product);
                => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";
        }
        class Brand
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
        static void Mainx()
        {
            var brands = new List<Brand>() {
                new Brand{ID = 1, Name = "Brand A"},
                new Brand{ID = 2, Name = "Brand B"},
                new Brand{ID = 4, Name = "Brand C"}
            };

            var products = new List<Product>() {
                new Product(1, "Tea desk", 400, new string[] {"Grey", "Green"}, 2),
                new Product(2, "Picture", 400, new string[] {"Yellow", "Green"}, 1),
                new Product(3, "Light", 500, new string[] {"White"}, 3),
                new Product(4, "Student desk", 200, new string[] {"White", "Green"}, 1),
                new Product(5, "Leather bag", 300, new string[] {"Red", "Black", "Yellow"}, 2),
                new Product(6, "Bed", 500, new string[] {"White"}, 2),
                new Product(7, "Closet", 600, new string[] {"White"}, 3)
            };

            // 1.1 Get products with price = 400
            // var query = from p in products
            //             where p.Price == 400
            //             select p;

            // 1.2 Similar 1.1, but use object of IEnumerable, IEnumerable<T> (Array, List, Stack, Queue ...)
            // // ********* Select = map in JS
            // var query = products.Select(
            //     (product) => product.Colors // return array
            // );
            // // ********* Where = filter in JS
            // var query = products.Where( 
            //     (product) => product.Name.Contains("desk")
            // );
            // // ********* SelectMany
            // var query = products.SelectMany(
            //     (product) => product.Colors // return string in array
            // );

            // 1.3 ********* Min, Max, Sum, Average
            // int[] numbers = { 1, 2, 4, 6, 4, 2, 8, 9 };
            // System.Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());
            // System.Console.WriteLine(products.Max(p => p.Price));

            // 1.4 Join 2 lists
            // // ********* Join: to print Brand Name by Brand ID in Product List
            // var query = products.Join(brands,
            //     product => product.Brand,
            //     brand => brand.ID,
            //     (product, brand) => new { Name = product.Name, Brand = brand.Name }
            //     );
            // foreach (var product in query)
            // {
            //     System.Console.WriteLine(product);
            // }
            // // ********* GroupJoin: to print all Products belong Brand ID in Brand List
            // var query = brands.GroupJoin(products,
            //     brand => brand.ID,
            //     product => product.Brand,
            //     (brand, pros) => new { Brand = brand.Name, Products = pros }
            //     );
            // foreach (var group in query)
            // {
            //     System.Console.WriteLine(group.Brand);
            //     foreach (var product in group.Products)
            //     {
            //         System.Console.WriteLine(product);
            //     }
            // }

            // 1.5 Take & Skip
            // products.Take(2).ToList().ForEach(p => System.Console.WriteLine(p));
            // products.Skip(2).ToList().ForEach(p => System.Console.WriteLine(p));

            // 1.6 OrderBy (Ascending) & OrderByDescending & Reverse
            // var sortedProducts = products.OrderBy(p => p.Price);
            // var sortedProducts = products.OrderByDescending(p => p.Price);
            // sortedProducts.Reverse().ToList().ForEach(p => System.Console.WriteLine(p));

            // 1.7 GroupBy
            // var query = products.GroupBy(p => p.Price);
            // foreach (var group in query)
            // {
            //     System.Console.WriteLine(group.Key);
            //     foreach (var product in group)
            //     {
            //         System.Console.WriteLine(product);
            //     }
            // }

            // 1.8 Distinct: remove duplicate
            // products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(color => System.Console.WriteLine(color));

            // 1.9 Single & SingleOrDefault
            // var p = products.Single(p => p.Price == 600); // Only get one element. If have 2 ele or no ele, will throw error
            // var p = products.Single(p => p.Price == 400); // Error: Sequence contains more than one matching element
            // var p = products.SingleOrDefault(p => p.Price == 1000); // Only get one ele. If have 2 ele, throw error. If no ele, return default

            // 1.10 Any & All
            // bool res = products.Any(p => p.Price > 200); // Check all products, if any product have Price > 200 => True
            // bool res = products.All(p => p.Price > 200); // Check all products, if all products have Price > 200 => True

            // 1.11 Count
            // var count = products.Count(); // 7
            // var count = products.Count(p => p.Price > 200); // 6

            // 1.12 Print Name Product, Name Brand, have Price [300 - 400], Descending Price.
            // products
            //     .Where(p => p.Price >= 300 && p.Price <= 400)
            //     .OrderByDescending(p => p.Price)
            //     .Join(brands,
            //     p => p.Brand,
            //     b => b.ID,
            //     (p, b) => new { ProductName = p.Name, BrandName = b.Name, Price = p.Price }
            //     )
            //     .ToList()
            //     .ForEach(info =>
            //     {
            //         System.Console.WriteLine($"{info.ProductName,15} {info.BrandName,15} {info.Price,10}");
            //     });

            // ======================================= 
            // LINQ

            // 2.1 select
            // var query = from product in products
            //             select product.Name;
            // var query = from product in products
            //             select $"{product.Name}: {product.Price}";
            // var query = from product in products
            //             select new
            //             {
            //                 Name = product.Name,
            //                 Price = product.Price
            //             };

            // 2.2 where
            // var query = from product in products
            //             where product.Price == 400
            //             select new
            //             {
            //                 Name = product.Name,
            //                 Price = product.Price
            //             };
            // query.ToList().ForEach(info => System.Console.WriteLine(info));

            // 2.3 from ... in ... from ... in ...
            // 2.4 orderby ... (ascending) | orderby ... descending
            // var query = from product in products
            //             from color in product.Colors
            //             where color == "White" && product.Price <= 500
            //             orderby product.Price
            //             select new
            //             {
            //                 Name = product.Name,
            //                 Price = product.Price,
            //                 Colors = product.Colors
            //             };
            // query.ToList().ForEach(info =>
            // {
            //     System.Console.WriteLine($"{info.Name,15} {info.Price,10} {string.Join(',', info.Colors),15}");
            // });

            // 2.5 group ... by ...
            // Group product by Price
            // var query = from product in products
            //             group product by product.Price;
            // query.ToList().ForEach(group =>
            // {
            //     System.Console.WriteLine(group.Key);
            //     group.ToList().ForEach(product => System.Console.WriteLine(product));
            // });

            // 2.6 save temp group (into gr) to orderby Price ascending
            // var query = from product in products
            //             group product by product.Price into gr
            //             orderby gr.Key
            //             select gr;
            // query.ToList().ForEach(group =>
            // {
            //     System.Console.WriteLine(group.Key);
            //     group.ToList().ForEach(product => System.Console.WriteLine(product));
            // });

            // 2.7 let
            // var query = from product in products
            //             group product by product.Price into gr
            //             orderby gr.Key
            //             let quantity = "Quantity: " + gr.Count()
            //             select new
            //             {
            //                 Price = gr.Key,
            //                 Products = gr.ToList(),
            //                 Quantity = quantity
            //             };
            // query.ToList().ForEach(group =>
            // {
            //     System.Console.WriteLine($"{group.Price} | {group.Quantity}");
            //     group.Products.ToList().ForEach(product => System.Console.WriteLine(product));
            // });

            // 2.8 join
            // var query = from product in products
            //             join brand in brands on product.Brand equals brand.ID
            //             select new
            //             {
            //                 ProductName = product.Name,
            //                 Price = product.Price,
            //                 BrandName = brand.Name
            //             };
            // query.ToList().ForEach(product => System.Console.WriteLine(product));

            // 2.9 If product.Brand doesn't contain in brands, print "No Brand"
            // var query = from product in products
            //             join brand in brands on product.Brand equals brand.ID into temp // save in a temp
            //             from b in temp.DefaultIfEmpty() // still get product.Brand doesn't contain in brands
            //             select new
            //             {
            //                 ProductName = product.Name,
            //                 Price = product.Price,
            //                 BrandName = (b != null) ? b.Name : "No Brand"
            //             };
            // query.ToList().ForEach(product => System.Console.WriteLine(product));

            // 2.10 Convert code 1.12 to LINQ
            var query = from product in products
                        where product.Price >= 300 && product.Price <= 500
                        orderby product.Price descending
                        join brand in brands on product.Brand equals brand.ID into temp
                        from b in temp.DefaultIfEmpty()
                        select new
                        {
                            ProductName = product.Name,
                            Price = product.Price,
                            BrandName = (b != null) ? b.Name : "No Brand"
                        };
            query.ToList().ForEach(product => System.Console.WriteLine(product));
        }
    }
}