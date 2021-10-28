using Interface;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            // IShape shape = new IShape(); // 1. Interface is similar Abstract, can't new IShape()
            Rectangle rectA = new Rectangle(5.5, 8);
            System.Console.WriteLine($"Perimeter A: {rectA.Perimeter()}");
            System.Console.WriteLine($"Area A: {rectA.Area()}");

            IShape rectB = new Rectangle(6, 10); // 2. Still declare IShape type, but must new Rectangle()
            System.Console.WriteLine($"Perimeter B: {rectB.Perimeter()}");
            System.Console.WriteLine($"Area B: {rectB.Area()}");

            // 3. Use "interface", code below is similar (only change Rectangle to Circle), because Children must declare Methods of Interface
            IShape circle = new Circle(5);
            System.Console.WriteLine($"Perimeter Circle: {circle.Perimeter()}");
            System.Console.WriteLine($"Area Circle: {circle.Area()}");
        }
    }
}
