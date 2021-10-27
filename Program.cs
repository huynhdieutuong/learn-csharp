using System.Collections.Generic;
using System.Linq;

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            AnonymousType.PrintInfo();

            System.Console.WriteLine("==========");

            Student stu = new Student();
            DynamicType.PrintInfo(stu);
        }
    }
}
