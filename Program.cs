using System;
using static System.Console; // "using static" to use static method WriteLine
using MyNameSpace;
using ChangeNameSpace = MyNameSpace.ChildrenNameSpace; // Since duplicate Class1, changed namespace to ChangeNameSpace

namespace CS002
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1.Hello();
            ChangeNameSpace.Class1.Hello();
            WriteLine("WriteLine without Console");
        }
    }
}
