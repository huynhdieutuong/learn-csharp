using System;
using System.Threading;
using System.Threading.Tasks;

// Multi thread
namespace Asynchronous
{
    public class Program
    {
        static void DoSomeThing(int second, string msg, ConsoleColor color)
        {
            // 1.2 lock Console.Out to make sure this thread complete before run another thread
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                System.Console.WriteLine(msg + "... Start:");
                Console.ResetColor();
            }

            for (int i = 1; i <= second; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    System.Console.WriteLine(msg + " " + i);
                    Console.ResetColor();
                }
                Thread.Sleep(500); // 1.1 Wait 1 second
            }

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                System.Console.WriteLine(msg + "... End:");
                Console.ResetColor();
            }
        }
        static Task Task2()
        {
            // 2.1 Task t2 = new Task(Action)
            Task t2 = new Task(
                () =>
                {
                    DoSomeThing(4, "T2", ConsoleColor.DarkGreen);
                }
            );
            t2.Start(); // Run thread 2

            // 3.1 If use code below to make sure "T2 finished" print when T2 finish,
            // but it will break the asynchronous. The expect is still asynchronous, but "T2 finished" still end.
            t2.Wait();
            System.Console.WriteLine("T2 finished");

            return t2;
        }
        static async Task Task3() // ***** 3.2 use "async/await" to fit the the expect at 3.1
        {
            // 2.2 Task t3 = new Task(Action<Object>, Object)
            Task t3 = new Task(
                (object ob) =>
                {
                    DoSomeThing(10, (string)ob, ConsoleColor.Cyan);
                }
                , "T3"
            );
            t3.Start(); // Run thread 3

            await t3; // ***** 3.2 use "await" = t3.Wait() + return t3

            // t3.Wait();
            System.Console.WriteLine("T3 finished");
            // return t3;
        }
        static async Task Main() // 3.3 change "void" to "async Task"
        // static void Main()
        {
            // Using Task to handle Asyncronous
            Task t2 = Task2();
            Task t3 = Task3();

            DoSomeThing(6, "T1", ConsoleColor.Red); // Run thread 1 (synchronous)

            // t2.Wait(); // 2.4 If no t2.Wait, (*) run before T2 end. It's make sure T2 finish, then run code below
            // t3.Wait(); // It's make sure T3 finish, then run code below

            // 2.5 Also use Task.WaitAll(t2, t3) to make sure T2 T3 finish, then run code below
            // Task.WaitAll(t2, t3); // Wait until t2, t3 finish

            // 3.3 use "await t2 t3" equal "Task.WaitAll(t2, t3)
            await t2;
            await t3;

            System.Console.WriteLine("Press any key"); // (*)
            Console.ReadKey(); // 2.3 If no Console.ReadKey, T2 will end when T1 end (although T2 still not finish)
        }
    }
}