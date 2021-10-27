namespace CS002
{
    public class Animal // change public to sealed to prevent inherit
    {
        protected int Legs { get; set; } = 4;
        protected float Weight { get; set; } = 0;

        public Animal()
        { // Animal's Contructor is called before Cat's Contructor
            System.Console.WriteLine("Constructor Animal");
        }

        protected Animal(float _weight)
        {
            Weight = _weight;
            System.Console.WriteLine("Constructor Animal has Weight");
        }

        protected void ShowLegs()
        {
            System.Console.WriteLine($"Legs: {Legs}");
        }
        protected void ShowWeight()
        {
            System.Console.WriteLine($"Weight: {Weight}");
        }
    }

    public class Cat : Animal
    {
        public string Food { get; set; } = "Mouse";

        public Cat(float _weight) : base(_weight)
        { // use ": base" to choose Animal Constructor Weight
            System.Console.WriteLine("Constructor Cat");
        }

        public void Eat()
        {
            System.Console.WriteLine($"Cat eat: {Food}");
        }

        public new void ShowLegs() // use "new" to rewrite ShowLegs
        {
            System.Console.WriteLine($"Cat's legs: {Legs}");
        }

        public void ShowInfo()
        {
            base.ShowLegs(); // use "base" to call ShowLegs of Animal
            ShowWeight();
        }
    }
}