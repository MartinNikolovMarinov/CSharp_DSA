namespace _03.RideTheHorse
{
    public static class MovesController
    {
        public static Cell MoveLeftDown(Cell cell)
        {
            int deltaX = cell.X - 2;
            int deltaY = cell.Y + 1;

            if (deltaX >= 0 && deltaY < RideTheHorseSolver.maxRows)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveLeftUp(Cell cell)
        {
            int deltaX = cell.X - 2;
            int deltaY = cell.Y - 1;

            if (deltaX >= 0 && deltaY >= 0)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveUpLeft(Cell cell)
        {
            int deltaX = cell.X - 1;
            int deltaY = cell.Y - 2;

            if (deltaX >= 0 && deltaY >= 0)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveUpRight(Cell cell)
        {
            int deltaX = cell.X + 1;
            int deltaY = cell.Y - 2;

            if (deltaX < RideTheHorseSolver.maxCols && deltaY >= 0)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveRightUp(Cell cell)
        {
            int deltaX = cell.X + 2;
            int deltaY = cell.Y - 1;

            if (deltaX < RideTheHorseSolver.maxCols && deltaY >= 0)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveRightDown(Cell cell)
        {
            int deltaX = cell.X + 2;
            int deltaY = cell.Y + 1;

            if (deltaX < RideTheHorseSolver.maxCols && deltaY < RideTheHorseSolver.maxRows)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveDownRight(Cell cell)
        {
            int deltaX = cell.X - 1;
            int deltaY = cell.Y + 2;

            if (deltaX >= 0 && deltaY < RideTheHorseSolver.maxRows)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }

        public static Cell MoveDownLeft(Cell cell)
        {
            int deltaX = cell.X + 1;
            int deltaY = cell.Y + 2;

            if (deltaX < RideTheHorseSolver.maxCols && deltaY < RideTheHorseSolver.maxRows)
            {
                return RideTheHorseSolver.field[deltaY, deltaX];
            }

            return null;
        }
    }
}
