namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    public static class LabyrinthTreversal
    {
        static char wallSymbol = '*';
        static char exitSymbol = 'e';
        static List<string[]> paths = new List<string[]>();
        static LinkedList<string> currentPath = new LinkedList<string>();

        public static ICollection<string[]> FindAllPaths(Cell[,] labyrinth, int startX, int startY) 
        {
            paths = new List<string[]>();
            currentPath = new LinkedList<string>();
            currentPath.AddLast("");
            Move(labyrinth, startX, startY);
            return paths;
        }

        private static void Move(Cell[,] labyrinth, int x, int y)
        {
            if (currentPath.Count == 0)
            {
                // Found all paths:
                return;
            }
            else if (labyrinth[x, y].Value == exitSymbol)
            {
                // Found an exit path from the labyrinth
                
                // Copy the path :
                string[] currPathCopy = new string[currentPath.Count];
                currentPath.CopyTo(currPathCopy, 0);
                paths.Add(currPathCopy);

                // Go back to find other paths
                labyrinth[x, y].InTheCurrentPath = false;
                currentPath.RemoveLast();
                return;
            }

            if (IsMovePossible(labyrinth, x, y + 1))
            {
                int dX = x;
                int dY = y + 1;

                // Right
                currentPath.AddLast("R");
                labyrinth[x, y].InTheCurrentPath = true;
                Move(labyrinth, dX, dY);
            }
           
            if (IsMovePossible(labyrinth, x, y - 1))
            {
                int dX = x;
                int dY = y - 1;

                // Left
                currentPath.AddLast("L");
                labyrinth[x, y].InTheCurrentPath = true;
                Move(labyrinth, dX, dY);
            }
           
            if (IsMovePossible(labyrinth, x + 1, y))
            {
                int dX = x + 1;
                int dY = y;

                // Down
                currentPath.AddLast("D");
                labyrinth[x, y].InTheCurrentPath = true;
                Move(labyrinth, dX, dY);
            }
            
            if (IsMovePossible(labyrinth, x - 1, y))
            {
                int dX = x - 1;
                int dY = y;

                // Up
                currentPath.AddLast("U");
                labyrinth[x, y].InTheCurrentPath = true;
                Move(labyrinth, dX, dY);
            }
            
            labyrinth[x, y].InTheCurrentPath = false;
            currentPath.RemoveLast();
        }

        private static bool IsMovePossible(Cell[,] labyrinth, int x, int y)
        {
            if (x < 0 || y < 0 ||
                x >= labyrinth.GetLength(0) ||
                y >= labyrinth.GetLength(1) ||
                labyrinth[x, y].Value == wallSymbol ||
                labyrinth[x, y].InTheCurrentPath)
            {
                return false;
            }

            return true;
        }
    }
}
