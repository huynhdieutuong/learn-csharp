namespace CS002
{
    public class Weapon
    {
        public string name = "Weapon Default";
        // int point = 1;
        // Sorthand Properties for private. Set default Point = 1
        public int Point { get; set; } = 1;

        public Weapon()
        {
        }
        public Weapon(string name)
        {
            this.name = name;
        }

        // Properties for private
        // public int Point
        // {
        //     get => point;
        //     set
        //     {
        //         point = value;
        //     }
        // }

        public void SetPoint(int point = 1)
        {
            Point = point;
        }
        public void PrintPoint()
        {
            for (int i = 0; i < Point; i++)
            {
                System.Console.Write("* ");
            }
        }
    }
}