using System;
using System.Linq;
using System.Reflection;

namespace _Type
{
    public class Program
    {
        static void Main()
        {
            // 1. Get type of a type -> typeof(type)
            // Type t1 = typeof(int);
            // var t2 = typeof(string);
            // var t3 = typeof(Array);

            // 2. Get type of a variable -> a.GetType()
            // int a = 1;
            // var t4 = a.GetType();
            // System.Console.WriteLine(t4.FullName);

            // ================
            // int[] numbers = { 1, 2, 3 };
            // Type t5 = numbers.GetType();
            // System.Console.WriteLine(t5);

            // // 3. Get properties
            // System.Console.WriteLine("=======Properties of t5:");
            // t5.GetProperties().ToList().ForEach((PropertyInfo o) => System.Console.WriteLine(o.Name));

            // // 4. Get fields
            // System.Console.WriteLine("=======Fields of t5:");
            // t5.GetFields().ToList().ForEach((FieldInfo o) => System.Console.WriteLine(o.Name));

            // // 5. Get methods
            // System.Console.WriteLine("=======Methods of t5:");
            // t5.GetMethods().ToList().ForEach((MethodInfo o) => System.Console.WriteLine(o.Name));

            // ================
            User user = new User()
            {
                Name = "Tuong",
                Age = 30,
                PhoneNumber = "543534536",
                Email = "tuong@gmail.com"
            };
            var properties = user.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                string name = property.Name;
                var value = property.GetValue(user);
                System.Console.WriteLine($"{name} : {value}");
            }
            // Name : Tuong
            // Age : 30
            // PhoneNumber : 543534536
            // Email : tuong@gmail.com
        }
    }
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}