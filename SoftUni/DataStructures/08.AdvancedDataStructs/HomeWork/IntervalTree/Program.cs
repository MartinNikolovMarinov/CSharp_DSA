namespace IntervalTree
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var i1 = new Interval(17, 19);
            var i2 = new Interval(5, 8);
            var i3 = new Interval(4, 8);
            var i4 = new Interval(15, 18);
            var i5 = new Interval(21, 24);
            var i6 = new Interval(7, 6);
            var intervalTree = new IntervalTree();
            intervalTree.Add(i1);
            intervalTree.Add(i2);
            intervalTree.Add(i3);
            intervalTree.Add(i4);
            intervalTree.Add(i5);
            intervalTree.Add(i6);

            Console.WriteLine("Set of intervals: ");
            Console.Write("{ ");
            foreach (var item in intervalTree)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine(" }");

            var intersect = intervalTree.GetIntersects(new Interval(21,23));
            Console.WriteLine();
            Console.WriteLine("All intervals that intersect [21, 23]: ");
            foreach (var interval in intersect)
            {
                Console.WriteLine(interval);
            }

            intersect = intervalTree.GetIntersects(new Interval(5, 7));
            Console.WriteLine();
            Console.WriteLine("All intervals that intersect [5, 7] inclusive: ");
            foreach (var interval in intersect)
            {
                Console.WriteLine(interval);
            }

            intersect = intervalTree.GetIntersects(new Interval(5, 7), IntersectType.Exclusive);
            Console.WriteLine();
            Console.WriteLine("All intervals that intersect [5, 7] exclusive: ");
            foreach (var interval in intersect)
            {
                Console.WriteLine(interval);
            }
        }
    }
}
