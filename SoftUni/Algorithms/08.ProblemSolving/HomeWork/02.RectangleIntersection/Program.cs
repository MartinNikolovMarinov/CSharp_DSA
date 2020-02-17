namespace _02.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public class Rect
        {
            // {minX} {maxX} {minY} {maxY}. 
            public Rect(int x1, int x2, int y2, int y1)
            {
                this.X1 = x1;
                this.Y1 = y1;
                this.X2 = x2;
                this.Y2 = y2;
            }

            public int X1 { get; set; }

            public int Y1 { get; set; }

            public int X2 { get; set; }

            public int Y2 { get; set; }

            public int Width { get { return this.X2 - this.X1; } }

            public int Height { get { return this.Y1 - this.Y2; } }

            public int CalcArea()
            {
                return this.Width * 2 +  this.Height * 2;
            }

            public override bool Equals(object obj)
            {
                if (obj is Rect)
                {
                    var other = obj as Rect;
                    return this.X1 == other.X1 && this.X2 == other.X2 && 
                        this.Y1 == other.Y1 && this.Y2 == other.Y2;
                }

                return false;
            }

            public override string ToString()
            {
                return string.Format("({0}, {1}), ({2}, {3})", X1, Y1, X2, Y2);
            }
        }

        public static Rect GetIntersectArea(Rect rect1, Rect rect2)
        {
            int x1 = Math.Max(rect1.X1, rect2.X1);
            int x2 = Math.Min(rect1.X2, rect2.X2);
            int y1 = Math.Min(rect1.Y1, rect2.Y1);
            int y2 = Math.Min(rect1.Y2, rect1.Y2);
            var intersectRect = new Rect(x1, x2, y2, y1);

            if (x1 < x2 && y1 > y2)
                return intersectRect;
            else
                return null;
        }

        public static int CalcIntersectArea(Rect rect1, Rect rect2)
        {
            int x1 = Math.Max(rect1.X1, rect2.X1);
            int x2 = Math.Min(rect1.X2, rect2.X2);
            int y1 = Math.Min(rect1.Y1, rect2.Y1);
            int y2 = Math.Min(rect1.Y2, rect1.Y2);
            var intersectRect = new Rect(x1, x2, y2, y1);

            if (x1 < x2 && y1 > y2)
                return intersectRect.CalcArea();
            else
                return -1;
        }

        public static bool CheckIntersect(Rect rect1, Rect rect2)
        {
            return CalcIntersectArea(rect1, rect2) != -1;
        }

        static int allIntersect;
        static Dictionary<Tuple<int, int>, bool> matrix;

        static void Main(string[] args)
        {
            int rectCount = int.Parse(Console.ReadLine());
            Rect[] rects = new Rect[rectCount];
            for (int i = 0; i < rectCount; i++)
            {
                var data = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                var newRect = new Rect(data[0], data[1], data[2], data[3]);
                rects[i] = newRect;
            }

            allIntersect = 0;
            matrix = new Dictionary<Tuple<int, int>, bool>();
            for (int i = -1000; i < 1000; i++)
            {
                matrix.Add(new Tuple<int,int>(i, i), false);
            }
            foreach (var rect in rects)
            {
                FindIntersections(rects, rect, rectCount);
            }

            Console.WriteLine(allIntersect);
        }

        private static void FindIntersections(Rect[] rects, Rect current, int rectCount)
        {
            foreach(var rect in rects)
            {
                if (!rect.Equals(current) && CheckIntersect(rect, current))
                {
                    FindIntersections(rects, rect, rectCount);
                    var intersectArea = GetIntersectArea(rect, current);
                    Console.WriteLine();
                }
            }
        }
    }
}
