namespace _03.RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public static class RideTheHorseSolver
    {
        public static int maxRows = 0;
        public static int maxCols = 0;
        public static int startRow = 0;
        public static int startCol = 0;
        public static Cell[,] field;

        public static void RunSolver()
        {
            maxRows = int.Parse(Console.ReadLine());
            maxCols = int.Parse(Console.ReadLine());
            startRow = int.Parse(Console.ReadLine());
            startCol = int.Parse(Console.ReadLine());
            field = GenerateField();
            FindPaths();

            Console.WriteLine();
            Console.WriteLine("Output : ");
            PrintMiddleColumn();
        }

        static void FindPaths()
        {
            Queue<Cell> q = new Queue<Cell>();
            var startCell = field[startRow, startCol];
            startCell.Value = 1;
            startCell.Visited = true;
            q.Enqueue(startCell);

            int count = 0;
            while (q.Count > 0)
            {
                Cell currentCell = q.Dequeue();
                EnqueuePosibleMoves(q, currentCell);
                count++;
            }
        }

        private static void EnqueuePosibleMoves(Queue<Cell> q, Cell currentCell)
        {
            Cell nextCell;

            nextCell = MovesController.MoveLeftDown(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveLeftUp(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveUpLeft(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveUpRight(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveRightUp(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveRightDown(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveDownRight(currentCell);
            VisitNextCell(q, nextCell, currentCell);

            nextCell = MovesController.MoveDownLeft(currentCell);
            VisitNextCell(q, nextCell, currentCell);
        }


        private static void VisitNextCell(Queue<Cell> q, Cell nextCell, Cell currentCell)
        {
            if (nextCell != null)
            {
                if (nextCell.Value == 0)
                {
                    nextCell.Value = currentCell.Value + 1;
                }

                if (!nextCell.Visited)
                {
                    nextCell.Visited = true;
                    q.Enqueue(nextCell);
                }
            }
        }

        static void PrintMiddleColumn()
        {
            for (int row = 0; row < maxRows; row++)
            {
                Console.WriteLine(field[row, maxCols / 2].Value + " ");
            }
        }

        static Cell[,] GenerateField()
        {
            Cell[,] field = new Cell[maxRows, maxCols];

            for (int row = 0; row < maxRows; row++)
            {
                for (int col = 0; col < maxCols; col++)
                {
                    field[row, col] = new Cell()
                    {
                        X = col,
                        Y = row
                    };
                }
            }

            return field;
        }
    }
}
