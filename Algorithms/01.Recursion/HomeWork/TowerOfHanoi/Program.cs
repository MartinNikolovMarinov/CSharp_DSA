namespace TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static int stepsTaken = 0;
        static Stack<int> source;
        static Stack<int> destination;
        static Stack<int> spare;

        static void Main(string[] args)
        {
            Console.Write("Number of pegs: ");
            int n = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, n).Reverse());
            destination = new Stack<int>();
            spare = new Stack<int>();

            Console.WriteLine();
            PrintRods();
            MoveDisks(n, source, destination, spare);
            CheckSolution(destination, n);
        }


        static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk {1}", stepsTaken, bottomDisk);
                PrintRods();
            }
            else 
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);

                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk {1}", stepsTaken, bottomDisk);
                PrintRods();

                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        static void PrintRods()
        {
            Console.WriteLine("Source {0}", string.Join(",", source.Reverse()));
            Console.WriteLine("Destination {0}", string.Join(",", destination.Reverse()));
            Console.WriteLine("Spare {0}", string.Join(",", spare.Reverse()));
            Console.WriteLine();
        }

        static void CheckSolution(Stack<int> destination, int n)
        {
            if (destination.Count != n)
            {
                throw new ArgumentException("Invalid solution!");
            }

            var arr = destination.ToArray();
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != i + 1)
                {
                    throw new ArgumentException("Invalid solution!");
                }
            }
        }
    }
}
