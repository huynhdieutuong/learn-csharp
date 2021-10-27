using System;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat c = new Cat(5.3f)
            {
                Food = "Fish"
            };
            // c.ShowLegs();
            c.Eat();
            c.ShowInfo();

            // ******* Animal can new Cat, but Cat can't new Animal *******
            // Animal a = new Cat(3.5f);
            // Cat d = new Animal(); // Can't
        }
    }
}
