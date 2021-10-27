namespace CS002
{
    public class Struct
    {
        public struct Product // Struct is not reference. Class is reference
        {
            // Data
            public string name;
            public double price;

            // Properties
            public string Info
            {
                get
                {
                    return $"{name}, {price}";
                }
            }

            // Constructor
            public Product(string _name, double _price)
            {
                name = _name;
                price = _price;
            }

            // Method
            public void GetInfo()
            {
                System.Console.WriteLine($"Product's name: {name}. Price: {price}");
            }
        }
    }
}