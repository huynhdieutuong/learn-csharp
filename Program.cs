using System;

namespace CS002
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Please enter number a: ");
      int a = int.Parse(Console.ReadLine());

      Console.Write("Please enter number b: ");
      int b = int.Parse(Console.ReadLine());

      Console.WriteLine("Please select a calculation: ");
      Console.WriteLine("1. Sum");
      Console.WriteLine("2. Sub");
      Console.WriteLine("3. Mul");
      Console.WriteLine("4. Div");

    L1:
      char c = Console.ReadKey().KeyChar;
      Console.WriteLine();

      switch (c)
      {
        case '1':
          Console.WriteLine($"Sum: {a + b}");
          break;
        case '2':
          Console.WriteLine($"Sub: {a - b}");
          break;
        case '3':
          Console.WriteLine($"Mul: {a * b}");
          break;
        case '4':
          Console.WriteLine($"Div: {(float)a / b}");
          break;
        default:
          System.Console.WriteLine("Please select another calculation:");
          goto L1;
          break;
      }
    }
  }
}
