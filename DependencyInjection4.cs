using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options; // 2. Require Options extension to use IOptions

namespace DependencyInjection4
{
    public class Program
    {
        class MyServiceOptions // 1. Use IOptions to manage and assign value to Data1, Data2
        {
            public string Data1 { get; set; }
            public int Data2 { get; set; }
        }
        class MyService
        {
            public string Data1 { get; set; }
            public int Data2 { get; set; }
            public MyService(IOptions<MyServiceOptions> options) // 2. Inject Options: IOptions (Previous lesson, Inject Dependency: IClass)
            {
                var _options = options.Value;
                Data1 = _options.Data1;
                Data2 = _options.Data2;
            }

            public void PrintData() => System.Console.WriteLine($"{Data1} / {Data2}");
        }
        static void Mainx()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MyService>(); // 0. How to assign value to Data1, Data2 ? use IOptions (create class MyServiceOptions)

            services.Configure<MyServiceOptions>( // 3. Assign value to Data1, Data2 in MyServiceOptions class
                (MyServiceOptions options) =>
                {
                    options.Data1 = "Hello";
                    options.Data2 = 2022;
                }
            );

            ServiceProvider provider = services.BuildServiceProvider();
            MyService myService = provider.GetService<MyService>();
            myService.PrintData();
        }
    }
}