using System;
using System.IO;

namespace _Exception
{
    public class Program
    {
        static void Main()
        {
            int a = 5;
            int b = 1;
            try // 1. use try cath to handle error, the program will continue run
            {
                var c = a / b;
                Console.WriteLine(c);

                int[] i = { 1, 2 };
                var x = i[5];
            }
            catch (DivideByZeroException e) // Can declare special Exception (DivideByZeroException) for only catch DivideByZero.
            {
                Console.WriteLine(e.Message); // Get message - Attempted to divide by zero.
                Console.WriteLine(e.StackTrace); // Get file & line error - at _Exception.Program.Main() in F:\Csharp\LearnCsharp2\CS002\Exception.cs:line 13
                Console.WriteLine(e.GetType().Name); // Get class of error - DivideByZeroException
            }
            catch (IndexOutOfRangeException e) // Can declare special Exception (IndexOutOfRangeException) for only catch IndexOutOfRange.
            {
                Console.WriteLine(e.Message); // Get message - Index was outside the bounds of the array.
                Console.WriteLine(e.StackTrace); // Get file & line error - at _Exception.Program.Main() in F:\Csharp\LearnCsharp2\CS002\Exception.cs:line 17
                Console.WriteLine(e.GetType().Name); // Get class of error - IndexOutOfRangeException
            }
            catch (Exception e) // if not two above exceptions (children class), catch general Exception (base class)
            {
                Console.WriteLine(e.Message); // Get message - Index was outside the bounds of the array.
                Console.WriteLine(e.StackTrace); // Get file & line error - at _Exception.Program.Main() in F:\Csharp\LearnCsharp2\CS002\Exception.cs:line 17
                Console.WriteLine(e.GetType().Name);
            }

            Console.WriteLine("=======================");
            // Read a file
            string path = "1.txt";
            try
            {
                string s = File.ReadAllText(path); // 2. Hover on ReadAllText to see its Exceptions
                Console.WriteLine(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType().Name);
            }

            Console.WriteLine("====================");

            try
            {
                Register("Tuong", 17);
            }
            catch (NameEmptyException e) // 4.3 catch NameEmptyException
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType().Name);
            }
            catch (AgeException e) // 5.3 catch AgeException
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType().Name);
                e.Detail(); // 5.4 Can call Detail method in class AgeException
            }
            catch (Exception e) // 3.2 Catch new Exception
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.GetType().Name);
            }

            Console.WriteLine("End program");
        }

        static void Register(string name, int age)
        {
            if (string.IsNullOrEmpty(name))
            {
                // throw new Exception("Name must not empty"); // 3.1 new Exception
                NameEmptyException exception = new NameEmptyException("Name must not empty"); // 4.2 new NameEmptyException
                throw exception;
            }
            if (age < 18 || age > 100)
            {
                throw new AgeException(age); // 5.2 use AgeException
            }
            Console.WriteLine($"Hello {name} ({age})");
        }
    }

    class NameEmptyException : Exception // 4.1 create class Exception
    {
        public NameEmptyException(string message) : base(message)
        {

        }
    }
    class AgeException : Exception // 5.1 create class AgeException
    {
        public int Age { get; set; }
        public AgeException(int age) : base("Age is invalid")
        {
            Age = age;
        }
        public void Detail()
        {
            Console.WriteLine($"Age = {Age} is not between 18 and 100");
        }
    }
}