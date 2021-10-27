using System;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon1 = new Weapon();
            System.Console.Write($"{weapon1.name}\t: ");
            weapon1.SetPoint();
            weapon1.PrintPoint();

            System.Console.WriteLine();

            Weapon weapon2 = new Weapon("Weapon 2");
            System.Console.Write($"{weapon2.name}\t: ");
            weapon2.SetPoint(5);
            weapon2.PrintPoint();
            weapon2.Point++;
            System.Console.WriteLine();
            System.Console.WriteLine("Point 2: " + weapon2.Point);

            // Declare Property Point
            Weapon weapon3 = new Weapon("Weapon 3")
            {
                Point = 3
            };
            System.Console.Write($"{weapon3.name}\t: ");
            weapon3.PrintPoint();
        }
    }
}
