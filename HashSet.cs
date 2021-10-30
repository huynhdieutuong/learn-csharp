using System;
using System.Collections.Generic;

namespace HashSet
{
    public class Program
    {
        static void PrintSet(HashSet<int> set)
        {
            System.Console.WriteLine("======");
            foreach (var item in set)
            {
                System.Console.Write(item + " ");
            }
            System.Console.WriteLine();
        }
        static void Mainx()
        {
            HashSet<int> set1 = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7 };
            HashSet<int> set2 = new HashSet<int>() { 9, 10, 1, 2, 3, 14 };
            PrintSet(set1);
            PrintSet(set2);

            // Add, Remove
            set1.Add(8);
            set2.Remove(14);
            PrintSet(set1);
            PrintSet(set2);

            // Concat
            // set1.UnionWith(set2);
            // PrintSet(set1);

            // Get ele duplicate
            set1.IntersectWith(set2);
            PrintSet(set1);
        }
    }
}