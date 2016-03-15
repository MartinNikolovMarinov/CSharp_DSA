namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var field = FieldExamples.Example1();
            var connectedAreas = Global.FindConnectedAreas(field);
            Console.WriteLine("Example 1:");
            PrintConnecteAreas(connectedAreas);

            field = FieldExamples.Example2();
            connectedAreas = Global.FindConnectedAreas(field);
            Console.WriteLine("Example 2:");
            PrintConnecteAreas(connectedAreas);
        }

        private static void PrintConnecteAreas(IEnumerable<ConnectedArea> connectedAreas)
        {
            int i = 1;
            Console.WriteLine("Total areas found: {0}", connectedAreas.Count());
            foreach (var currArea in connectedAreas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size {3}",
                    i, currArea.Start.X, currArea.Start.Y, currArea.Size);
                i++;
            }
        }
    }
}
