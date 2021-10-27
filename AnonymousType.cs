namespace CS002
{
    public class AnonymousType
    {
        // Object - Only read
        // new { }
        public static void PrintInfo()
        {
            var product = new
            {
                Name = "Iphone",
                Price = 1000,
                MfgDate = 2018
            };

            // product.Name = "XXX"; // Can't change value

            System.Console.WriteLine(product.Name);
            System.Console.WriteLine(product.Price);
            System.Console.WriteLine(product.MfgDate);
        }
    }

    public class DynamicType
    {
        public static void PrintInfo(dynamic obj)
        { // Dynamic type doesn't give an error until dotnet run.
            obj.Name = "ABC";
            obj.Hello();
        }
    }

    public class Student // If haven't Name and Hello(), still don't give error until dotnet run.
    {
        // public string Name { get; set; }
        // public void Hello()
        // {
        //     System.Console.WriteLine("Student's name: " + Name);
        // }
    }
}