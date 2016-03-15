namespace _03.Combinations_Iteratively
{
    using System;
    using System.Linq;

    class Program
    {
        static int combinationsCount = 0;

        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine();
            GenerateCombinations(n, k);
            Console.WriteLine("Total Combinations: " + combinationsCount);
        }

        static void GenerateCombinations(int n, int k)
        {
            int[] combinations = Enumerable.Range(1, k).ToArray();

            while (combinations[k - 1] <= n)
            {
                Console.WriteLine(string.Join(", ", combinations));
                combinationsCount++;

                int firstSlotIndex = k - 1;
                while (firstSlotIndex != 0 && 
                    combinations[firstSlotIndex] == n - k + firstSlotIndex + 1)
                {
                    firstSlotIndex--;
                }

                combinations[firstSlotIndex]++;
                for (int i = firstSlotIndex + 1; i < k; i++)
                {
                    combinations[i] = combinations[i - 1] + 1;
                }
            }
        }
    }
}
