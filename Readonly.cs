namespace Readonly
{
    class Student
    {
        public readonly string name = "ABC"; // 1. Only set name at here
        public Student() { }
        public Student(string _name) // 2. Also set name at here
        {
            name = _name;
        }
    }
    public class Program
    {
        static void Main()
        {
            Student s1 = new Student();
            // s.name = "ABC"; // 1. Can not set name, since name is readonly
            System.Console.WriteLine(s1.name); // 1. Only read name

            Student s2 = new Student("AAA");
            System.Console.WriteLine(s2.name); // 2. AAA
        }
    }
}