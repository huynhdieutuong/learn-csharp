namespace CS002
{
    public class Generic
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    public class Product<A>
    {
        A ID;
        public void SetID(A _id)
        {
            ID = _id;
        }
        public void PrintInfo()
        {
            System.Console.WriteLine($"ID = {ID}");
        }
    }
}