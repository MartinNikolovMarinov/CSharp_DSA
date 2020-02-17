namespace RangeInTree
{
    using System;
    using System.Linq;
    using AvlTreeLab;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int[] range = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            AvlTree<int> tree = new AvlTree<int>();
            foreach (var item in input)
            {
                tree.Add(item);
            }

            var result = tree.Range(range[0], range[1]);
            foreach (var item in result)
            {
                Console.Write("{0} ", item);
            }

            if (result.Count == 0)
                Console.WriteLine("(empty)");
            else
                Console.WriteLine();
        }
    }
}
