using System;
using System.Collections.Generic;

namespace LinkedList
{
    public class Program
    {
        static void PrintList(LinkedList<string> lessons)
        {
            Console.WriteLine("List node: ");
            foreach (var ls in lessons)
            {
                Console.WriteLine(ls);
            }
        }
        static void Mainx()
        {
            LinkedList<string> lessons = new LinkedList<string>();

            var ls3 = lessons.AddFirst("Lesson 3"); // 1.1 Add a node at start list
            LinkedListNode<string> ls1 = lessons.AddFirst("Lesson 1"); // 1.2 Type of node is LinkedListNode
            LinkedListNode<string> ls2 = lessons.AddAfter(ls1, "Lesson 2"); // 1.3 Add a node after ls1
            var ls5 = lessons.AddLast("Lesson 5"); // 1.4 Add a node at end list
            lessons.AddBefore(ls5, "Lesson 4"); // 1.5 Add a node before ls5

            PrintList(lessons);
            Console.WriteLine("==========");
            var node2 = ls2;
            Console.WriteLine(node2.Value); // 2.1 Access node ls2
            Console.WriteLine(node2.Next.Value); // 2.2 Access node after ls2
            Console.WriteLine(node2.Previous.Value); // 2.3 Access node before ls2

            Console.WriteLine("===========");
            var nodeLast = lessons.Last; // 3.3 The last node
            Console.WriteLine("Access from last node to first node: ");
            while (nodeLast != null) // check if first node = null
            {
                Console.WriteLine(nodeLast.Value);
                nodeLast = nodeLast.Previous;
            }
        }
    }
}