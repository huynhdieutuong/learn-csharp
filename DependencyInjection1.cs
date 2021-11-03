namespace DependencyInjection1
{
    // Inject dependency by constructor
    interface IHorn
    {
        public int Level { get; set; }
        public void Beep();
    }
    class Horn1 : IHorn
    {
        public int Level { get; set; } = 1;
        public void Beep()
        {
            System.Console.WriteLine("Beep - Beep - Beep ......");
        }
    }
    class Horn2 : IHorn
    {
        public int Level { get; set; } = 1;
        public void Beep()
        {
            System.Console.WriteLine("Boop - Boop - Boop ......");
        }
    }
    class Car
    {
        IHorn horn_de;
        public Car(IHorn horn) // Inject dependency by constructor
        {
            horn_de = horn;
        }
        public void Beep()
        {
            horn_de.Beep();
            System.Console.WriteLine(horn_de.Level);
        }
    }
    public class Program
    {
        static void Main()
        {
            IHorn horn = new Horn2 { Level = 2 };
            Car car = new Car(horn);
            car.Beep();
        }
    }
}