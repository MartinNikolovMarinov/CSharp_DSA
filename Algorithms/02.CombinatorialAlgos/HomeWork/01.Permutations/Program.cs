namespace _01.Permutations
{
    using System;
    using System.Linq;

    class Program
    {
        static int countOfPermutations = 0;
        
        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = Enumerable.Range(1, n).ToArray();
            Permute(arr);

            Console.WriteLine();
            Console.WriteLine("Total permutations: " + countOfPermutations);
        }

        static void Permute(int[] array, int startIndex = 0) 
        {
            if (startIndex >= array.Length - 1)
            {
                Console.WriteLine(string.Join(", ", array));
                countOfPermutations++;
            }
            else 
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    Permute(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
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
