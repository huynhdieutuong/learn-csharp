namespace Partial
{
    public partial class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public void GetInfo()
        {
            System.Console.WriteLine($"Name: {Name}\nPrice: {Price}\nDescription: {Description}");
        }
    }
}