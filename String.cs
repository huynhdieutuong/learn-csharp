using System.Text;

namespace CS002
{
    public class String
    {
        static void Main()
        {
            string hello = "Hi\r! \\How\t are\n \"you\"?";
            string breakLine = @"M: Hello, How are ""you""?
Y: I'm fine. Thank you, and ""you""?
M: Fine. Thanks.";
            string combineString = $@"{hello}
{breakLine}";
            // System.Console.WriteLine(combineString);

            int year = 2021;
            string addSpaceLeft = $"Add space 10 chars on left {year,10}. Next year is {year + 1}";
            string addSpaceRight = $"Add space 10 chars on right {year,-10}. Next year is {year + 1}";

            // System.Console.WriteLine($"{addSpaceLeft}\n{addSpaceRight}");

            string name = "Huynh Dieu Tuong";
            int lengthName = name.Length;
            // System.Console.WriteLine("Length of string: " + lengthName);
            // System.Console.WriteLine($"Print char 5: {name[4]}");

            string trimString = "       Hello    ";
            string trimChar = "********Hello*****";
            string trimStart = "********Hello*****";
            string trimEnd = "********Hello*****";
            // System.Console.WriteLine(trimString.Trim());
            // System.Console.WriteLine(trimChar.Trim('*'));
            // System.Console.WriteLine(trimStart.TrimStart('*'));
            // System.Console.WriteLine(trimEnd.TrimEnd('*'));
            // System.Console.WriteLine(trimString.ToLower());
            // System.Console.WriteLine(trimString.ToUpper());
            // System.Console.WriteLine(trimString.Replace("Hello", "hi"));
            // System.Console.WriteLine(trimString.Insert(2, "Hi")); // not in JS, like splice (but only apply for array). 0: insert. 1: replace
            // System.Console.WriteLine(trimChar.Substring(5, 10));
            // System.Console.WriteLine(trimChar.Remove(5, 10)); // not in JS, use slice instead

            string splitString = "Huynh Dieu Tuong";
            string[] arrString = splitString.Split(' ');
            // foreach (var x in arrString)
            // {
            //     System.Console.WriteLine(x);
            // }
            string joinString = string.Join('*', arrString);
            // System.Console.WriteLine(joinString);

            // String Builder, it optimize memory when handle a huge text
            StringBuilder newString = new StringBuilder();
            newString.Append("Hello");
            newString.Append(" World");
            newString.Replace("Hello", "Hi");
            System.Console.WriteLine(newString);
        }
    }
}