namespace CS002
{
    class Abc
    {
        public void Hello() => System.Console.WriteLine("Hello World!");
    }
    public class Null
    {
        static void Mainx()
        {
            // Null - use for Reference Variable (object, dynamic, string)
            Abc a = null; // Throw error: Object reference not set to an instance of an object
            // a = new Abc();

            // if (a != null) a.Hello();
            a?.Hello(); // Shorthand check a != null

            System.Console.WriteLine("============");

            // Nullable - use for Value Variable (int, float, double, char)
            // int age = null; // By default, can't set null for age
            int? age = null; // int? to Nullable for age
            // age = 10;

            if (age.HasValue) // Check null for age, equal (age != null)
            {
                // Cannot implicitly convert type 'int?' to 'int'
                int _age = age.Value; // Get age value, equal (int)age
                System.Console.WriteLine(_age);
            }
        }
    }
}