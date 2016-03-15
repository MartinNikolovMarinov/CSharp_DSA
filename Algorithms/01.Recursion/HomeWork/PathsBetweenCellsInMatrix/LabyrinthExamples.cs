namespace PathsBetweenCellsInMatrix
{
    public static class LabyrinthExamples
    {
        /// <summary>
        /// | s |   |   |   |
        /// |   | * | * |   |
        /// |   | * | * |   |
        /// |   | * | e |   |
        /// |   |   |   |   |
        /// </summary>
        public static Cell[,] Example1() 
        {
            var labyrinth = new Cell[,]
            {
               {
                    new Cell('s'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' ')
               },
               {
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell(' '),
               },
               {
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell(' '),
               },
               {
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('e'),
                    new Cell(' '),
               },
               {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
               }
            };

            return labyrinth;
        }

        /// <summary>
        /// | s |   |   |   |   |   |
        /// |   | * | * |   | * |   |
        /// |   | * | * |   | * |   |
        /// |   | * | e |   |   |   |
        /// |   |   |   | * |   |   |
        /// </summary>
        public static Cell[,] Example2()
        {
            var labyrinth = new Cell[,]
            {
               {
                    new Cell('s'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' ')
               },
               {
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' ')
               },
               {
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' ')
               },
               {
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('e'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' ')
               },
               {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' ')
               }
            };

            return labyrinth;
        }

        /// <summary>
        /// | s | * | * |
        /// |   |   |   |
        /// |   |   | e |
        /// 
        /// DRRD
        /// DRDR
        /// DDRR
        /// DDRURD
        /// </summary>
        public static Cell[,] Example3() 
        {
            var labyrinth = new Cell[,]
            {
                {
                    new Cell('s'),
                    new Cell('*'),
                    new Cell('*'),
                },
                {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                },
                {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('e'),
                }
            };

            return labyrinth;
        }
    }
}
