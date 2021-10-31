using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Asynchronous1
{
    public class Program
    {
        static void DoSomeThing(int second, string msg, ConsoleColor color)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                System.Console.WriteLine(msg + "... Start");
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
                Thread.Sleep(500);
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                System.Console.WriteLine(msg + "... End");
                Console.ResetColor();
            }
        }
        static async Task<string> Task4()
        {
            // 1.1 Task<string> t4 = new Task<string>(Func<string>)
            Task<string> t4 = new Task<string>(
                () =>
                {
                    DoSomeThing(10, "T4", ConsoleColor.Yellow);
                    return "Return from T4"; // *********
                }
            );
            t4.Start();
            string res4 = await t4; // ********

            System.Console.WriteLine("T4 finished");

            return res4; // **** Task<string> need return
        }
        static async Task<string> Task5()
        {
            // 1.2 Task<string> t5 = new Task<string>(Func<Object, string>, Object)
            Task<string> t5 = new Task<string>(
                (object ob) =>
                {
                    string t = (string)ob;
                    DoSomeThing(4, t, ConsoleColor.DarkRed);
                    return $"Return from {t}"; // *********
                },
                "T5"
            );
            t5.Start();
            string res5 = await t5; // ******

            System.Console.WriteLine("T5 finished");

            return res5; // **** Task<string> need return
        }
        static async Task<string> GetWeb(string url) // 2.1 *************
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync(url);
            string content = await res.Content.ReadAsStringAsync();
            return content;
        }
        static async Task Mainx()
        {
            // Task<T> want have return value (type T)

            Task<string> t4 = Task4();
            Task<string> t5 = Task5();
            DoSomeThing(6, "T1", ConsoleColor.DarkBlue);

            string res4 = await t4; // **** Return from T4
            string res5 = await t5; // **** Return from T5

            System.Console.WriteLine(res4);
            System.Console.WriteLine(res5);
            System.Console.WriteLine("Press any key");

            // 2.2 *************
            var content = await GetWeb("https://github.com/huynhdieutuong");
            System.Console.WriteLine(content);

            Console.ReadKey();
        }
    }
}