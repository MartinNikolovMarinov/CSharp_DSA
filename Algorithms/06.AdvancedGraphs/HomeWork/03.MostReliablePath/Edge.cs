namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;

    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int reliability)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Reliability = reliability;
        }

        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Reliability { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Reliability - other.Reliability;
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge)
                return this.Reliability - ((Edge)obj).Reliability == 0;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) -> {2}%", StartNode, EndNode, Reliability);
        }
    }
}
