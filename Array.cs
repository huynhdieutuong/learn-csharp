namespace CS002
{
    public class Array
    {
        static void Mainx()
        {
            /*
                    0 1 2

                0   2 3 4.5
                1   1 9 8

            */

            double[,] numbers = new double[2, 3] { { 2, 3, 4.5 }, { 1, 9, 8 } };

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    System.Console.Write(numbers[i, j] + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }
    }
}