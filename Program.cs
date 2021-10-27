using System;
using static CS002.Enum;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            RATE rating = RATE.Excellent;

            // Convert to number
            int number = (int)rating; // 50
            System.Console.WriteLine(number);

            // Convert to rate
            RATE rating2 = (RATE)(30); // Good
            System.Console.WriteLine(rating2);

            switch (rating)
            {
                case RATE.Poor:
                    System.Console.WriteLine("Poor type");
                    break;
                case RATE.Average:
                    System.Console.WriteLine("Average type");
                    break;
                case RATE.Good:
                    System.Console.WriteLine("Good type");
                    break;
                case RATE.Excellent:
                    System.Console.WriteLine("Excellent type");
                    break;
                default:
                    break;
            }
        }
    }
}
