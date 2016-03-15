namespace _02.Permutations_Iterative
{
    using System;
    using System.Linq;

    class Program
    {
        static int permutationCount = 0;

        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine();
            PrintPermutations(n);
            Console.WriteLine("Total permutations: " + permutationCount);
        }

        static void PrintPermutations(int n) 
        {
            if (n < 2)
            {
                throw new ArgumentException("Can't permute less than 2 objects.");
            }
           
            int[] objectsToPermute = Enumerable.Range(1, n).ToArray();
            int[] iterationControl = new int[n];
            int i = 1;
            int j = 0;
               
            Console.WriteLine(string.Join(", ", objectsToPermute));
            permutationCount++;
            while (i < n)
            {
                if (iterationControl[i] < i)
                {
                    j = i % 2 * iterationControl[i];
                    Swap(ref objectsToPermute[i], ref objectsToPermute[j]);
                    iterationControl[i]++;
                    i = 1;

                    Console.WriteLine(string.Join(", ", objectsToPermute));
                    permutationCount++;
                }
                else 
                {
                    iterationControl[i] = 0;
                    i++;
                }
            }
        }

        static void Swap(ref int first, ref int second)
        {
            if (first == second)
            {
                return;
            }

            first ^= second;
            second ^= first;
            first ^= second;
        }
    }
}
