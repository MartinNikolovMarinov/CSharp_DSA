namespace ReverseArray
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            ReverseArray(arr, arr.Length, 0);
            Console.WriteLine(string.Join(" ", arr));
        }

        static void ReverseArray(int[] arr, int n, int i)
        {
            if (i >= (n / 2))
                return;

            Swap(ref arr[i], ref arr[n - i - 1]);
            ReverseArray(arr, n, i + 1);
        }

        static void Swap(ref int p1, ref int p2)
        {
            int tmp = p1;
            p1 = p2;
            p2 = tmp;
        }
    }
}
