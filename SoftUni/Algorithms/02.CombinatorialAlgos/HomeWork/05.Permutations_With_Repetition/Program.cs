namespace _05.Permutations_With_Repetition
{
    using System;

    class Program
    {
        static int countOfPermutations = 0;

        public static void PermutePrint(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Main(string[] args)
        {
            var array = new int[] { 1, 3, 5, 5 };
            int count = PermuteWithRep(array, PermutePrint);
            Console.WriteLine("Total permutations : {0}", count);
        }

        /// <summary>
        /// Finds all permutations with repetition of the input array.
        /// </summary>
        /// <param name="array">Array of integers.</param>
        /// <param name="action">The action taken on each permutation.</param>
        /// <returns>Count of permutations</returns>
        public static int PermuteWithRep(int[] array, Action<int[]> action)
        {
            countOfPermutations = 0;
            PermuteWithRep(array, 0, array.Length, action);
            return countOfPermutations;
        }

        public static void PermuteWithRep(int[] array, int start, int n, Action<int[]> action)
        {
            countOfPermutations++;
            action(array);

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (array[i] != array[j])
                        {
                            Swap(ref array[i], ref array[j]);
                            PermuteWithRep(array, i + 1, n, action);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping.
                    int tmp = array[i];
                    for (int j = i; j < n - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }

                    array[n - 1] = tmp;
                }
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
                return;

            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}
