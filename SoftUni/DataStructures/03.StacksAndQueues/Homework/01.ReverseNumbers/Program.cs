namespace _01.ReverseNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static public int[] ReverseNumbers(string[] numberStr)
        {
            int i = 0;
            Stack<int> stack = new Stack<int>();
            int[] ret = new int[numberStr.Length];
            for (i = 0; i < numberStr.Length; i++)
            {
                stack.Push(int.Parse(numberStr[i]));
            }

            for (i = 0; i < numberStr.Length; i++)
			{
			    ret[i] = stack.Pop();
			}

            return ret;
        }

        static void Main(string[] args)
        {
            string rawInput = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(rawInput))
                Console.WriteLine("(empty)");

            string[] input = rawInput.Split();
            int[] result = ReverseNumbers(input);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }

            Console.WriteLine();
        }
    }
}
