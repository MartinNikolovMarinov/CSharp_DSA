namespace _06.Snakes
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static List<List<char>> allSnakes = new List<List<char>>();
        private static List<List<char>> uniqueSnakes = new List<List<char>>();

        private static void GenerateSnake(int[] array)
        {
            var newSnake = new List<char>();
            for (int i = 0; i < array.Length; i++)
            {
                switch (array[i])
                {
                    case 0: newSnake.Add('R'); break;
                    case 1: newSnake.Add('D'); break;
                    case 2: newSnake.Add('L'); break;
                    case 3: newSnake.Add('U'); break;
                    default: throw new ArgumentException("Invalid direction");
                }
            }

            allSnakes.Add(newSnake);
        }
        
        static void Main(string[] args)
        {
            int n = 4;
            var variation = new Variation(n, 3, GenerateSnake);
            variation.VariationWithRep();

            for (int i = 0; i < allSnakes.Count; i++)
            {
                Console.WriteLine(string.Join(", ", allSnakes[i]));
            }
        }
    }
}
