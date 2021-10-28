using Abstract;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cellphone c = new Cellphone(); // Can't new Cellphone, since has "abstract"
            Iphone i = new Iphone();
            i.Test();
        }
    }
}
