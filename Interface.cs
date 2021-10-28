namespace Interface
{
    interface IShape // 1. Interface only declare Method, not handle Method
    {
        double Perimeter();
        double Area();
    }

    public class Rectangle : IShape // 1. Children must handle Method
    {
        public double EdgeA { get; set; }
        public double EdgeB { get; set; }
        public Rectangle(double edgeA, double edgeB)
        {
            EdgeA = edgeA;
            EdgeB = edgeB;
        }

        public double Perimeter()
        {
            return (EdgeA + EdgeB) * 2;
        }
        public double Area()
        {
            return EdgeA * EdgeB;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double r)
        {
            Radius = r;
        }

        public double Area()
        {
            return Radius * Radius * System.Math.PI;
        }

        public double Perimeter()
        {
            return 2 * Radius * System.Math.PI;
        }
    }

    // 4. Also inherit multi Interface
    // class Square : IShape, IShape1, IShape2 {}
}