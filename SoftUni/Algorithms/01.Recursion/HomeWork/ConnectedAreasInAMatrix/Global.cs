namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Global
    {
        static char wallSymbol = '*';
        static bool visitedAll;
        static int xMax, yMax;
        static SortedSet<ConnectedArea> areas;
        static ConnectedArea currentConnection;

        public static IEnumerable<ConnectedArea> FindConnectedAreas(Cell[,] field)
        {
            areas = new SortedSet<ConnectedArea>();
            visitedAll = false;
            xMax = field.GetLength(0);
            yMax = field.GetLength(1);
            int currentX = 0;
            int currentY = 0;

            while (visitedAll == false)
            {
                currentConnection = new ConnectedArea(new Move(currentX, currentY));
                FindConnections(field, currentX, currentY);

                if (currentConnection.Size > 1)
                {
                    areas.Add(currentConnection);
                }

                if (currentY + 1 >= yMax)
                {
                    currentY = 0;
                    currentX++;
                    if (currentX >= xMax)
                    {
                        visitedAll = true;
                    }
                }
                else
                {
                    currentY++;
                }
            }

            return areas.Reverse();
        }

        private static void FindConnections(Cell[,] field, int x, int y)
        {
            if (field[x, y].Value == wallSymbol)
            {
                return;
            }

            field[x, y].Visited = true;

            if (IsMovePossible(field, x, y + 1))
            {
                int dX = x;
                int dY = y + 1;

                // Right
                currentConnection.Size++;
                FindConnections(field, dX, dY);
            }
            if (IsMovePossible(field, x, y - 1))
            {
                int dX = x;
                int dY = y - 1;

                // Left
                currentConnection.Size++;
                FindConnections(field, dX, dY);
            }
            if (IsMovePossible(field, x + 1, y))
            {
                int dX = x + 1;
                int dY = y;

                // Down
                currentConnection.Size++;
                FindConnections(field, dX, dY);
            }
            if (IsMovePossible(field, x - 1, y))
            {
                int dX = x - 1;
                int dY = y;

                // Up
                currentConnection.Size++;
                FindConnections(field, dX, dY);
            }
        }

        private static bool IsMovePossible(Cell[,] field, int x, int y)
        {
            if (x < 0 || y < 0 ||
                x >= field.GetLength(0) ||
                y >= field.GetLength(1) ||
                field[x, y].Value == wallSymbol ||
                field[x, y].Visited)
            {
                return false;
            }

            return true;
        }
    }
}
