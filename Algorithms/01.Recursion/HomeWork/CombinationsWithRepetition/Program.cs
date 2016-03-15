namespace CombinationsWithRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static int n, k, stepCount;
        static int[] range;

        static void Main(string[] args)
        {
            Console.Write("N = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("\nK = ");
            k = int.Parse(Console.ReadLine());
            range = new int[k];
            
            Console.WriteLine();
            Combination();
        }

        static void Combination(int counter = 0, int currentIndex = 0)
        {
            stepCount++;
            if (currentIndex == k)
            {
                PrintArr(range, k);
                return;
            }

            for (int i = counter; i < n; i++)
            {
                range[currentIndex] = i + 1;
                Combination(i, currentIndex + 1);
            }
        }

        static void PrintArr(int[] range, int to)
        {
            for (int i = 0; i < to; i++)
            {
                Console.Write("{0} ", range[i]);
            }

            Console.WriteLine();
        }
    }
}
