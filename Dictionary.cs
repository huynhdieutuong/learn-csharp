using System;
using System.Collections.Generic;

// Dictonary like SortedList to optimize access for big data by key.
namespace Dictionary
{
    public class Program
    {
        static void Mainx()
        {
            // 1. Init 2 numbers
            Dictionary<string, int> numbers = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2
            };

            // 2. Add number
            numbers["three"] = 3;
            numbers.Add("four", 4);

            // 3. Print numbers by key
            var keys = numbers.Keys;
            foreach (var k in keys)
            {
                Console.WriteLine(numbers[k]);
            }

            // 4. Or print by KeyValuePair
            foreach (KeyValuePair<string, int> item in numbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}