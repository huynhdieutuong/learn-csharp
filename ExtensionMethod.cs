using System;

namespace ExtensionMethod
{
    // ***** Want to add Extension Method (Print) for "string": (1) & (2) ****
    static class Abc // 1. use "static class"
    {
        public static void Print(this string s, ConsoleColor color) // 2. use "this string"
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }
    public class Program
    {
        // public static void Print(string s, ConsoleColor color)
        // {
        //     Console.ForegroundColor = color;
        //     Console.WriteLine(s);
        // }
        static void Main()
        {
            string hello = "Hello";
            // Print(hello, ConsoleColor.DarkGreen);
            hello.Print(ConsoleColor.Cyan); //**** This is Extension Method ****
            hello.Print(ConsoleColor.Blue);
            hello.Print(ConsoleColor.Green);
            hello.Print(ConsoleColor.Yellow);
            hello.Print(ConsoleColor.Red);
        }
    }
}