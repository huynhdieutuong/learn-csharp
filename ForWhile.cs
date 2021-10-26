namespace CS002
{
    public class ForWhile
    {
        static void Mainx()
        {
            int i;
            for (i = 0, System.Console.WriteLine("Start"); i < 5; i++, System.Console.WriteLine("Update i"))
            {
                System.Console.WriteLine(i);
            }
            // Start
            // 0
            // Update i
            // 1
            // Update i
            // 2
            // Update i
            // 3
            // Update i
            // 4
            // Update i

            int n = 0;
            while (n < 10)
            {
                n++;
                // if (n == 5) break; // 1 2 3 4
                if (n == 5) continue; // 1 2 3 4 6 7 8 9 10
                System.Console.WriteLine(n);
            }
        }
    }
}