using System;

namespace OperatorOverloading
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

        // NewVector = Vector 1 + Vector 2
        public static Vector operator +(Vector v1, Vector v2) // 1. +
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }
    }
    public class Program
    {
        static void Mainx()
        {
            Vector v1 = new Vector(5, 8);
            Vector v2 = new Vector(1, 1);

            // v1 + v2 = (x1 + x2, y1 + y2)
            var v3 = v1 + v2; // 1. +
            v1.Info();
            v2.Info();
            v3.Info();
        }
    }
}