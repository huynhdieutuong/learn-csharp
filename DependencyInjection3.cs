using System;
using Microsoft.Extensions.DependencyInjection;
// Delegate & Factory
namespace DependencyInjection3
{
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }
    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classB)
        {
            b_dependency = classB;
        }
        public void ActionA()
        {
            System.Console.WriteLine("Action in Class A");
            b_dependency.ActionB();
        }
    }
    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classC)
        {
            c_dependency = classC;
        }
        public void ActionB()
        {
            System.Console.WriteLine("Action in Class B");
            c_dependency.ActionC();
        }
    }
    class ClassC : IClassC
    {
        public void ActionC()
        {
            System.Console.WriteLine("Action in Class C");
        }
    }
    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classC)
        {
            c_dependency = classC;
        }
        public void ActionB()
        {
            System.Console.WriteLine("Action in Class B1");
            c_dependency.ActionC();
        }
    }
    class ClassB2 : IClassB // 1. Create ClassB2 with construtor(IClassC, string)
    {
        IClassC c_dependency;
        string message;
        public ClassB2(IClassC classC, string msg)
        {
            c_dependency = classC;
            message = msg;
            System.Console.WriteLine("ClassB2 is created");
        }
        public void ActionB()
        {
            System.Console.WriteLine(message);
            c_dependency.ActionC();
        }

    }
    class ClassC1 : IClassC
    {
        public void ActionC()
        {
            System.Console.WriteLine("Action in Class C1");
        }
    }
    public class Program
    {
        static IClassB CreateB2(IServiceProvider provider) // 3. Declare Factory
        {
            var b2 = new ClassB2(
                provider.GetService<IClassC>(),
                "Action in Class B2"
            );
            return b2;
        }
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ClassA, ClassA>();
            // services.AddSingleton<IClassB, ClassB2>(); // 2. Can inject IClassC, but miss "string msg"
            // services.AddSingleton<IClassB, ClassB2>(
            //     (provider) => // 2. Use delegate to new ClassB2(IClassC, string)
            //     {
            //         var b2 = new ClassB2(
            //             provider.GetService<IClassC>(),
            //             "Action in Class B2"
            //         );
            //         return b2;
            //     }
            // );
            services.AddSingleton<IClassB>(CreateB2); // 3. Also use Factory
            services.AddSingleton<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();
            ClassA a = provider.GetService<ClassA>();
            a.ActionA();
        }
    }
}