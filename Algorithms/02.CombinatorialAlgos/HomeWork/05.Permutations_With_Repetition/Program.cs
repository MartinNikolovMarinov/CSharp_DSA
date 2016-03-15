namespace _05.Permutations_With_Repetition
{
    using System;

    class Program
    {
        static int[] numberSet;

        static void Main(string[] args)
        {
            numberSet = new int[] { 1, 3, 5, 5 };
            Permute(numberSet.Length);
        }

        private static void Permute(int n, int start = 0, int currIndex = 0)
        {
            if (currIndex == n)
            {
                Console.WriteLine(string.Join(", ", numberSet));       
            }
            else 
            {
                for (int i = start; i < n; i++)
                {
                    numberSet[currIndex] = i;
                    Permute(n, i, currIndex + 1);
                }
            }
        }
    }
}
