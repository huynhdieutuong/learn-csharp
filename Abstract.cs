namespace Abstract
{
    abstract public class Cellphone // 1. use "abstrat" to prevent new Cellphone
    {
        protected double Price { get; set; }

        public abstract void ProductInfo(); // 2. use "abstract" for method. Only declare, children class will override

        public void Test() => ProductInfo();
    }

    public class Iphone : Cellphone
    {
        public Iphone() => Price = 800;

        public override void ProductInfo() // 2. children class must override ProductInfo()
        {
            System.Console.WriteLine($"Price: {Price}");
        }
    }
}