using System;

namespace Indexer
{
    class Vector
    {
        double x, y;
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Info()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }

        // Indexer
        public double this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new Exception("Invalid index");
                }
            }
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new Exception("Invalid index");
                }
            }
        }
    }
    public class Program
    {
        static void Mainx()
        {
            Vector v = new Vector(5, 8);
            Console.WriteLine($"x = {v[0]}, y = {v[1]}");

            v[0] = 1;
            v[1] = 1;
            v.Info();
            Console.WriteLine(v[3]);
        }
    }
}