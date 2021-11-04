using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DependencyInjection5
{
    public class Program
    {
        class MyServiceOptions
        {
            public string Data1 { get; set; }
            public int Data2 { get; set; }
        }
        class MyService
        {
            public string Data1 { get; set; }
            public int Data2 { get; set; }
            public MyService(IOptions<MyServiceOptions> options)
            {
                var _options = options.Value;
                Data1 = _options.Data1;
                Data2 = _options.Data2;
            }

            public void PrintData() => System.Console.WriteLine($"{Data1} / {Data2}");
        }
        static void Mainx()
        {
            // 1. Get config in json file
            IConfigurationRoot configurationRoot;

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("config.json");

            configurationRoot = configurationBuilder.Build();
            var sectionMyServiceOptions = configurationRoot.GetSection("MyServiceOptions"); // (*) Get all values in MyServiceOptions json

            // Can get one value in config file 
            // var Data1 = configurationRoot.GetSection("section1").GetSection("key1").Value;
            // System.Console.WriteLine(Data1);

            // 2. Register services
            var services = new ServiceCollection();
            services.AddSingleton<MyService>();

            // 3. Add values of config file (sectionMyServiceOptions)
            services.Configure<MyServiceOptions>(sectionMyServiceOptions); // (**) Add all values to MyServiceOptions class (keys = Properties)

            // 4. Get services
            ServiceProvider provider = services.BuildServiceProvider();
            MyService myService = provider.GetService<MyService>();
            myService.PrintData();
        }
    }
}