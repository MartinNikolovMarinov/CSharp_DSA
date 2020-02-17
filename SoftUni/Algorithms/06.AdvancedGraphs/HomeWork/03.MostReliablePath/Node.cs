namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable<Node>
    {
        public Node(int index)
        {
            this.Index = index;
            this.Visited = false;
            this.ReliabilityFromStart = 0;
            this.ChildEdges = null;
        }

        public int Index { get; set; }
        public bool Visited { get; set; }
        public double ReliabilityFromStart { get; set; }
        public List<Edge> ChildEdges { get; set; }

        public void AddChild(Edge c)
        {
            if (this.ChildEdges == null)
                this.ChildEdges = new List<Edge>();
            this.ChildEdges.Add(c);
        }

        public int CompareTo(Node other)
        {
            double diff = other.ReliabilityFromStart - this.ReliabilityFromStart;
            if (diff > 0)
                return 1;
            else if (diff < 0)
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            return string.Format("({0}) -> {1:0.00}%", Index, ReliabilityFromStart);
        }
    }
}
