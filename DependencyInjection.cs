namespace DependencyInjection
{
    // Inverse of Control (Dependency Inverse)
    // -- Dependency injection
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
            System.Console.WriteLine("Class B1 is created");
        }
        public void ActionB()
        {
            System.Console.WriteLine("Action in Class B1");
            c_dependency.ActionC();
        }
    }
    class ClassC1 : IClassC
    {
        public ClassC1() => System.Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            System.Console.WriteLine("Action in Class C1");
        }
    }
    public class Program
    {
        static void Mainx()
        {
            IClassC objectC = new ClassC1(); // new ClassC();
            IClassB objectB = new ClassB1(objectC); // new ClassB(objectC);
            ClassA objectA = new ClassA(objectB);
            objectA.ActionA();
        }
    }
}