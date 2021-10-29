using System;

namespace Static
{
    class CountNumber
    {
        // Static number is shared in class CountNumber, it's not owned by c1 or c2.
        public static int number = 0;
        public static void Info()
        {
            Console.WriteLine($"Count = {number}");
        }
        public void Counter()
        {
            number++;
        }
    }
    public class Program
    {
        static void Main()
        {
            CountNumber c1 = new CountNumber();
            CountNumber c2 = new CountNumber();
            c1.Counter();
            c2.Counter();
            CountNumber.Info();
        }
    }
}