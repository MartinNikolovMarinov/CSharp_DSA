namespace NestedLoops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static int numberOfLoops;
        static int[] loops;

        static void Main(string[] args)
        {
            Console.Write("N = ");
            numberOfLoops = int.Parse(Console.ReadLine());
            loops = new int[numberOfLoops];
            NestedLoops(0);
        }

        static void NestedLoops(int current)
        {
            if (current == numberOfLoops)
            {
                PrintLoops();
                return;
            }

            for (int i = 1; i <= numberOfLoops; i++)
            {
                loops[current] = i;
                NestedLoops(current + 1);
            }
        }

        static void PrintLoops()
        {
            for (int i = 0; i < numberOfLoops; i++)
            {
                Console.Write("{0} ", loops[i]);
            }

            Console.WriteLine();
        }
    }
}
