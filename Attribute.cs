using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

// Attribute like validate, such as: RequiredAttribute, StringLengthAttribute, DataTypeAttribute, RangeAttribute, PhoneAttribute, EmailAddressAttribute
// When use attribute, remove "Attribute" word: [Required()], [StringLength()], [DataType()], [Range()], [Phone()], [EmailAddress()]
namespace _Attribute
{
    public class Program
    {
        static void Mainx()
        {
            User user = new User()
            {
                Name = "Tuong",
                Age = 30,
                PhoneNumber = "43543565",
                Email = "tuong@gmail.com"
            };
            // user.PrintInfo(); // Warning: 'User.PrintInfo()' is obsolete: 'This method is outdated, need change to ShowInfo' 

            // 2.2 Print attributes of user
            var properties = user.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    DescriptionAttribute description = attribute as DescriptionAttribute;
                    if (description != null)
                    {
                        var value = property.GetValue(user);
                        var name = property.Name;
                        System.Console.WriteLine($"({name}) - {description.DetailInfo}: {value}");
                    }
                }
            }

            System.Console.WriteLine("====================");

            // 3.1 Validate attributes
            User2 user2 = new User2()
            {
                Name = "Tu",
                Age = 17,
                PhoneNumber = "4354356fd5",
                Email = "tuong$gmail.com"
            };

            ValidationContext context = new ValidationContext(user2);
            var result = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(user2, context, result, true);

            if (!isValid)
            {
                result.ToList().ForEach(e =>
                {
                    string name = e.MemberNames.First();
                    string message = e.ErrorMessage;
                    System.Console.WriteLine($"{name}: {message}");
                });
            }
            else
            {
                System.Console.WriteLine("No errors");
            }
        }
    }

    // 1. Attribute used before class, property, method,...
    [Description("This class contain User")] // 2.1 use DescriptionAttribute at class
    class User
    {
        [Description("Name of user")] // 2.1 use DescriptionAttribute at Property
        public string Name { get; set; }

        [Description("Age of user")]
        public int Age { get; set; }

        [Description("PhoneNumber of user")]
        public string PhoneNumber { get; set; }

        [Description("Email of user")]
        public string Email { get; set; }

        // ObsoleteAttribute, this is an Attribute of System
        [Obsolete("This method is outdated, need change to ShowInfo")] // It shows warning when user use PrintInfo()
        public void PrintInfo() => System.Console.WriteLine(Name);
    }

    // 2. Create new Attribute: Description
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // use for class, method, property
    class DescriptionAttribute : Attribute
    {
        public string DetailInfo { get; set; }
        public DescriptionAttribute(string detailInfo)
        {
            DetailInfo = detailInfo;
        }
    }

    // 3. Use some attributes
    class User2
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must between 3 - 50 chars")]
        public string Name { get; set; }

        [Range(18, 80, ErrorMessage = "Age must between 18 - 80")]
        public int Age { get; set; }

        [Phone(ErrorMessage = "Phone is invalid")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
    }
}