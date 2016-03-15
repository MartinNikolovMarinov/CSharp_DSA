namespace ConnectedAreasInAMatrix
{
    public static class FieldExamples
    {

        /// <summary>
        /// | 1 |   |   | * | 2 |   |   | * | 3 |
        /// |   |   |   | * |   |   |   | * |   |
        /// |   |   |   | * |   |   |   | * |   |
        /// |   |   |   |   | * |   | * |   |   |
        /// </summary>
        public static Cell[,] Example1()
        {
            var field = new Cell[,]
            {
                {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                },
                {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                },
                {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                },
                {
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                },
            };

            return field;
        }

        /// <summary>
        /// | * | 1 |   | * | 3 |   |   | * | 2 |   |
        /// | * |   |   | * |   |   |   | * |   |   |
        /// | * |   |   | * | * | * | * | * |   |   |  
        /// | * |   |   | * | 4 |   |   | * |   |   | 
        /// | * |   |   | * |   |   |   | * |   |   |
        /// </summary>
        public static Cell[,] Example2()
        {
            var field = new Cell[,]
            {
                {
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                },
                {
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                },
                {
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                },
                {
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                },
                {
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell(' '),
                    new Cell('*'),
                    new Cell(' '),
                    new Cell(' '),
                }
            };

            return field;
        }
    }
}
