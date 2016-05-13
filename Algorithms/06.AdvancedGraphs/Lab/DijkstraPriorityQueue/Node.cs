namespace Dijkstra
{
    using System;

    public class Node : IComparable<Node>
    {
        // set default value for the distance equal to positive infinity
        public Node(int index, int distance = int.MaxValue)
        {
            this.Index = index;
            this.DistanceFromStart = distance;
        }

        public int Index { get; set; }

        public int DistanceFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}d", Index, DistanceFromStart);
        }
    }
}
