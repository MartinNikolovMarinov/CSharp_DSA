namespace _01.RecArrSum
{
    using System;

    class Program
    {
        static int FindSum(int[] arr, int len)
        {
            if (len == 0)
                return 0;

            int sumToTheLeft = FindSum(arr, len - 1);
            return sumToTheLeft + arr[len - 1];
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4 };
            int sum = FindSum(arr, arr.Length);
            Console.WriteLine(sum);
        }
    }
}
