using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures.DistanceInLabyrinth
{
    public static class LabTraversal
    {
        public static Stack<Move> moves;

        private static LabCell[,] markAllUnreachableCells(LabCell[,] labyrint)
        {
            for (int i = 0; i < labyrint.GetLength(0); i++)
            {
                for (int j = 0; j < labyrint.GetLength(1); j++)
                {
                    if (labyrint[j, i].Value == "0")
                    {
                        labyrint[j, i].Value = "u";
                    }
                }
            }

            return labyrint;
        }

        private static bool CheckCurrsorValue(LabCell cursor, int movesCount)
        {
            try
            {
                int currentValueOfCursor = int.Parse(cursor.Value);

                if (currentValueOfCursor == 0 || currentValueOfCursor > movesCount)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsMovePossible(int x, int y, LabCell[,] labyrint) 
        {
            if (x < 0 || y < 0 || 
                x >= labyrint.GetLength(0) || 
                y >= labyrint.GetLength(1) || 
                labyrint[x, y].Value == "x" ||
                labyrint[x, y].InTheCurrentPath)
            {
                return false;
            }

            return true;
        }

        public static LabCell[,] FindPathsInLabirint(LabCell[,] labyrint, int startX, int startY) 
        {
            LabCell cursor = labyrint[startX, startY];
            int currX = startX;
            int currY = startY;
            int currMovesCount = 0;
            bool deadEnd = false;
            moves = new Stack<Move>();
            moves.Push(new Move(startX, startY));

            while (!deadEnd)
            {
                bool moved = false;

                #region LEFT
                if (moved == false && cursor.Left == false)
                {
                    cursor.Left = true;
                    currX--;

                    if (IsMovePossible(currX, currY, labyrint))
                    {
                        // move the cursor
                        cursor = labyrint[currX, currY];
                        cursor.InTheCurrentPath = true;
                        currMovesCount++;
                        // Prevent unintentional going back
                        cursor.Right = true;

                        // Set the value in the cell, if the moves it took to get here are less.
                        if (CheckCurrsorValue(cursor, currMovesCount))
                        {
                            cursor.Value = currMovesCount.ToString();
                        }

                        moved = true;
                        moves.Push(new Move(currX, currY));
                    }
                    else 
                    {
                        currX++;
                    }
                }
                #endregion

                #region UP
                if (moved == false && cursor.Up == false)
                {
                    cursor.Up = true;
                    currY--;

                    if (IsMovePossible(currX, currY, labyrint))
                    {
                        // move the cursor
                        cursor = labyrint[currX, currY];
                        cursor.InTheCurrentPath = true;
                        currMovesCount++;
                        // Prevent unintentional going back
                        cursor.Down = true;

                        // Set the value in the cell, if the moves it took to get here are less.
                        if (CheckCurrsorValue(cursor, currMovesCount))
                        {
                            cursor.Value = currMovesCount.ToString();
                        }

                        moved = true;
                        moves.Push(new Move(currX, currY));
                    }
                    else 
                    {
                        currY++;
                    }
                }
                #endregion

                #region RIGHT
                if (moved == false && cursor.Right == false)
                {
                    cursor.Right = true;
                    currX++;

                    if (IsMovePossible(currX, currY, labyrint))
                    {
                        // move the cursor
                        cursor = labyrint[currX, currY];
                        cursor.InTheCurrentPath = true;
                        currMovesCount++;
                        // Prevent unintentional going back
                        cursor.Left = true;

                        // Set the value in the cell, if the moves it took to get here are less.
                        if (CheckCurrsorValue(cursor, currMovesCount))
                        {
                            cursor.Value = currMovesCount.ToString();
                        }

                        moved = true;
                        moves.Push(new Move(currX, currY));
                    }
                    else
                    {
                        currX--;
                    }
                }
                #endregion

                #region DOWN
                if (moved == false && cursor.Down == false)
                {
                    cursor.Down = true;
                    currY++;

                    if (IsMovePossible(currX, currY, labyrint))
                    {
                        // move the cursor
                        cursor = labyrint[currX, currY];
                        cursor.InTheCurrentPath = true;
                        currMovesCount++;
                        // Prevent unintentional going back
                        cursor.Up = true;

                        // Set the value in the cell, if the moves it took to get here are less.
                        if (CheckCurrsorValue(cursor, currMovesCount))
                        {
                            cursor.Value = currMovesCount.ToString();
                        }

                        moved = true;
                        moves.Push(new Move(currX, currY));
                    }
                    else
                    {
                        currY--;
                    }
                }
                #endregion

                if (!moved)
                {
                    var movess = moves;
                    //Console.WriteLine();

                    moves.Pop();
                    if (moves.Count == 0)
                    {
                        deadEnd = true;
                        break;
                    }

                    Move prevMove = moves.First();
                    currX = prevMove.X;
                    currY = prevMove.Y;

                    // nullify cursor's current position 
                    cursor.Left = false;
                    cursor.Right = false;
                    cursor.Up = false;
                    cursor.Down = false;
                    cursor.InTheCurrentPath = false;

                    // Move cursor
                    cursor = labyrint[currX, currY];
                    currMovesCount--;
                }
            }

            labyrint = markAllUnreachableCells(labyrint);
            return labyrint;
        }
    }
}
