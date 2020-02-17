namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void PrintPaths(ICollection<string[]> paths)
        {
            foreach (var path in paths)
            {
                foreach (var str in path)
                {
                    Console.Write(str);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Total paths found: {0}", paths.Count);
        }

        static void Main(string[] args)
        {
            var labyrinth = LabyrinthExamples.Example1();
            var paths = LabyrinthTreversal.FindAllPaths(labyrinth, 0, 0);
            Console.WriteLine("Example 1: ");
            PrintPaths(paths);

            labyrinth = LabyrinthExamples.Example2();
            paths = LabyrinthTreversal.FindAllPaths(labyrinth, 0, 0);
            Console.WriteLine("\nExample 2: ");
            PrintPaths(paths);

            labyrinth = LabyrinthExamples.Example3();
            paths = LabyrinthTreversal.FindAllPaths(labyrinth, 0, 0);
            Console.WriteLine("\nExample 3: ");
            PrintPaths(paths);
        }
    }
}
