using System;

namespace Delegate
{
    // 0. Delegate type is similar Method, but can declare outsite class
    // ***** Delegate is used to declare a variable = Method & can concat Methods *****
    public delegate void ShowLog(string message); // 1. Declare delegate
    public delegate double Div(int a, int b); // 6. Don't need if use "Func"
    class Program
    {
        static void Info(string s)
        { // 1. Info() return void like "delegate"
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static double Divide(int a, int b)
        {
            return a / b;
        }

        // 7. Can apply delegate in Method to color string
        static void Sum(int a, int b, Action<string> log)
        {
            int sum = a + b;
            log?.Invoke($"Sum: {sum}");
        }
        static void Mainx()
        {
            ShowLog log = null; // 0. Delete is reference type, can declare null
            log = Info; // 2. (1) the same "void", so can log = Info
            // if (log != null)
            // {
            //     log("Test delegate"); // 3. Call Info()
            // }

            // ****** 4. Can concat like this, and print all by one log?.Invoke("Hello world!") *********
            log += Info;
            log += Info;
            log += Info;
            log += Warning;
            log += Warning;
            log += Info;

            log?.Invoke("Hello world!"); // 3. Also call Info() like this

            // 5. "Action" is shorthand "delegate", return void:
            // delegate void ShowLog(string message, int n); = ~ Don't need declare with "Action"
            // ShowLog log;                                  = ~ Action<string, int> log;
            Action<string> action1;
            action1 = Info;
            action1 += Warning;
            action1?.Invoke("This is Action message");

            // 6. "Func" is shorthand "delegate", return int/string/double/...
            // delegate double Div(int a, int b);           = ~ Don't need declare with "Func"
            // Div divide;                                  = ~ Func<int, int, double> divide;

            // Div divide;
            // divide = Divide;

            Func<int, int, double> divide;
            divide = Divide;

            Console.WriteLine("Result: " + divide?.Invoke(20, 10));

            // 7. apply delete in Method to color string
            Sum(10, 20, Warning);
        }
    }
}