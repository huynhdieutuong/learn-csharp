namespace VirtualMethod
{
    public class Cellphone
    {
        protected double Price { get; set; }

        public virtual void ProductInfo() // use "virtual"
        {
            System.Console.WriteLine($"Price: {Price}");
        }

        public void Test() => ProductInfo();
    }

    public class Iphone : Cellphone
    {
        public Iphone() => Price = 1000;

        // public void ProductInfo() // Can't override ProductInfo from base
        // {
        //     System.Console.WriteLine("New Iphone");
        // }

        // Want to override Method from base, use "virtual" (base), "override" (children)
        public override void ProductInfo() // use "override"
        {
            System.Console.WriteLine("New Iphone");
            base.ProductInfo(); // use "base" to call ProductInfo of base
        }
    }
}