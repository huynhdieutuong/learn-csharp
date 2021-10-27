using System;

namespace MyNameSpace
{
    public class Class1
    {
        public static void Hello()
        {
            Console.WriteLine("Hello");
        }
    }

    namespace ChildrenNameSpace
    {
        public class Class1
        {
            public static void Hello()
            {
                Console.WriteLine("Hello from Children namespace");
            }
        }
    }
}