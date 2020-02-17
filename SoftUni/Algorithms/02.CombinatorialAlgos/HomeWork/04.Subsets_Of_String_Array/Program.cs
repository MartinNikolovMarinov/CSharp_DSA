namespace _04.Subsets_Of_String_Array
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static int n, k;
        static string[] set, combinations;

        static void Main(string[] args)
        {
            set = new string[] { "test", "rock", "fun"};
            n = set.Length;
            k = 2;
            combinations = new string[k];

            GenerateSubSets();
        }

        static void GenerateSubSets(int start = 0, int currentIndex = 0)
        {
            if (currentIndex == k)
            {
                Console.WriteLine("(" + string.Join(" ", combinations) + ")");
            }
            else 
            {
                for (int i = start + 1; i <= n; i++)
                {
                    combinations[currentIndex] = set[i - 1];
                    GenerateSubSets(i, currentIndex + 1);
                }
            }
        }
    }
}
