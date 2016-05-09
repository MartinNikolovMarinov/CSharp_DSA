namespace _02.AreasInMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static List<Cell[]> matrix;
        static int maxRow;
        static int maxCol;

        static List<Cell[]> ReadMatrix()
        {
            maxRow = int.Parse(Console.ReadLine());
            maxCol = 0;
            var matrix = new List<Cell[]>(maxRow);

            for (int i = 0; i < maxRow; i++)
            {
                Cell[] row = Console.ReadLine().ToArray()
                    .Select(x => { return new Cell(x); })
                    .ToArray();
                maxCol = row.Length;
                matrix.Add(row);
            }

            return matrix;
        }

        static void MatrixDFS(int x, int y)
        {
            var currCell = matrix[x][y];
            currCell.Visited = true;

            if (x - 1 >= 0 && matrix[x - 1][y].Visited == false
                && matrix[x - 1][y].Value == currCell.Value)
                // Can go up
                MatrixDFS(x - 1, y); 
            if (y + 1 < maxCol && matrix[x][y + 1].Visited == false
                && matrix[x][y + 1].Value == currCell.Value)
                // Can go right
                MatrixDFS(x, y + 1);
            if (x + 1 < maxRow && matrix[x + 1][y].Visited == false
                && matrix[x + 1][y].Value == currCell.Value)
                // Can go down
                MatrixDFS(x + 1, y);
            if (y - 1 >= 0 && matrix[x][y - 1].Visited == false
                && matrix[x][y - 1].Value == currCell.Value)
                // Can go left
                MatrixDFS(x, y - 1);
        }

        static void Main(string[] args)
        {
            matrix = ReadMatrix();
            var areas = new Dictionary<char, int>();
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j].Visited == false)
                    {
                        if (areas.ContainsKey(matrix[i][j].Value) == false)
                            areas.Add(matrix[i][j].Value, 0);
                        areas[matrix[i][j].Value]++;
                        MatrixDFS(i, j);
                    }
                }
            }

            foreach (var a in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", a.Key, a.Value);
            }
        }
    }
}
