namespace TreeIndexing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AvlTreeLab;

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree<int>();
            Array.ForEach(Console.ReadLine().Split()
                .Select(x => int.Parse(x))
                .ToArray(), x => tree.Add(x));

            int currIndex;
            string currLine;
            while (!String.IsNullOrWhiteSpace(currLine = Console.ReadLine()))
            {
                currIndex = int.Parse(currLine);
                try
                {
                    Console.WriteLine("[{0}] = {1}", currIndex, tree[currIndex]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid index");
                }
            }
        }
    }
}
