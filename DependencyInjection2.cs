using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection2
{
    // Dependency Injecttion Library
    // 1. DI Container : ServiceCollection
    // 2. Register services (class)
    // 3. ServiceProvider -> Get Services

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
    class ClassC1 : IClassC
    {
        public void ActionC()
        {
            System.Console.WriteLine("Action in Class C1");
        }
    }
    public class Program
    {
        static void Mainx()
        {
            // I. Basic
            // 1. DI Container : ServiceCollection
            // var services = new ServiceCollection();

            // 2. Register services (class)
            // services.AddName<Name, Class>();
            // services.AddSingleton<IClassC, ClassC>(); // (*)
            // services.AddTransient<IClassC, ClassC>(); // (**)
            // services.AddScoped<IClassC, ClassC>(); // (***)

            // 3. ServiceProvider -> Get Services
            // var provider = services.BuildServiceProvider();
            // for (int i = 0; i < 4; i++)
            // {
            //     IClassC classC = provider.GetService<IClassC>(); // (*) Singleton has the same HashCode
            //     System.Console.WriteLine(classC.GetHashCode()); // (**) Transient has different HashCode
            // }

            // using (var scope = provider.CreateScope())
            // {
            //     var provider1 = scope.ServiceProvider;
            //     for (int i = 0; i < 4; i++)
            //     {
            //         IClassC classC = provider1.GetService<IClassC>(); // (***) Scoped has the same HashCode inside Scope, but outside scope is different
            //         System.Console.WriteLine(classC.GetHashCode());
            //     }
            // }

            System.Console.WriteLine("=====================");
            // IClassC objectC = new ClassC1(); // new ClassC();
            // IClassB objectB = new ClassB1(objectC); // new classB(objectC);
            // ClassA objectA = new ClassA(objectB);
            // objectA.ActionA();

            // II. Use library for above code
            // Automaticly create objectA, objectB, objectC and inject.
            var services = new ServiceCollection();
            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<IClassB, ClassB1>();
            services.AddSingleton<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();
            ClassA a = provider.GetService<ClassA>();
            a.ActionA();
        }
    }
}