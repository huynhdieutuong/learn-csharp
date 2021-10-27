namespace Partial
{
    public partial class Product
    {
        public string Description { get; set; }

        // Can write class in class
        public Manufactory Manu { get; set; }
        public class Manufactory
        {
            public string Name { get; set; }
            public string Address { get; set; }

            public void ShowManu()
            {
                System.Console.WriteLine($"Manufactory's name: {Name}\nAddress: {Address}");
            }
        }
    }
}