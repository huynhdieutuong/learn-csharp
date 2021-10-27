using Partial;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();
            product1.Name = "ABC";
            product1.Price = 5.5;
            product1.Description = "This is description";
            product1.GetInfo();
            System.Console.WriteLine("============");

            // New Class in Class
            product1.Manu = new Product.Manufactory();
            product1.Manu.Name = "Manufactor 1";
            product1.Manu.Address = "Ho Chi Minh";
            product1.Manu.ShowManu();
        }
    }
}
