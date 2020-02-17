namespace _01.ShortestPathInMatrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;

    class Program
    {
        #region Util

        public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
        {
            private Dictionary<T, int> searchCollection;
            private List<T> heap;

            public PriorityQueue()
            {
                this.heap = new List<T>();
                this.searchCollection = new Dictionary<T, int>();
            }

            public int Count
            {
                get
                {
                    return this.heap.Count;
                }
            }

            public T ExtractMin()
            {
                var min = this.heap[0];
                var last = this.heap[this.heap.Count - 1];
                this.searchCollection[last] = 0;
                this.heap[0] = last;
                this.heap.RemoveAt(this.heap.Count - 1);
                if (this.heap.Count > 0)
                {
                    this.HeapifyDown(0);
                }

                this.searchCollection.Remove(min);

                return min;
            }

            public T PeekMin()
            {
                return this.heap[0];
            }

            public void Enqueue(T element)
            {
                this.searchCollection.Add(element, this.heap.Count);
                this.heap.Add(element);
                this.HeapifyUp(this.heap.Count - 1);
            }

            private void HeapifyDown(int i)
            {
                var left = (2 * i) + 1;
                var right = (2 * i) + 2;
                var smallest = i;

                if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = left;
                }

                if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = right;
                }

                if (smallest != i)
                {
                    T old = this.heap[i];
                    this.searchCollection[old] = smallest;
                    this.searchCollection[this.heap[smallest]] = i;
                    this.heap[i] = this.heap[smallest];
                    this.heap[smallest] = old;
                    this.HeapifyDown(smallest);
                }
            }

            private void HeapifyUp(int i)
            {
                var parent = (i - 1) / 2;
                while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
                {
                    T old = this.heap[i];
                    this.searchCollection[old] = parent;
                    this.searchCollection[this.heap[parent]] = i;
                    this.heap[i] = this.heap[parent];
                    this.heap[parent] = old;

                    i = parent;
                    parent = (i - 1) / 2;
                }
            }

            public void DecreaseKey(T element)
            {
                int index = this.searchCollection[element];
                this.HeapifyUp(index);
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var item in this.heap)
                {
                    yield return item;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public override string ToString()
            {
                string t = string.Join(", ", this.heap);
                return t;
            }
        }
        
        public class Node : IComparable<Node>
        {
            private static int idCounter = 0;

            public Node(int x, int y, int weigth)
            {
                this.X = x;
                this.Y = y;
                this.Id = idCounter++;
                this.Weigth = weigth;
                this.DistanceFromStart = long.MaxValue;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Id { get; set; }
            public int Weigth { get; set; }
            public long DistanceFromStart { get; set; }
            public bool Visited { get; set; }
            public Node Previous { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is Node)
                    return this.Id.Equals((obj as Node).Id);
                else
                    return false;
            }

            public override int GetHashCode()
            {
                return this.Id.GetHashCode();
            }

            public override string ToString()
            {
                return string.Format("({0}, {1}) -> {2} {3}", X, Y, Weigth, DistanceFromStart);
            }

            public int CompareTo(Node other)
            {
                return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
            }
        }

        public static int rows;
        public static int cols;

        private static Node[,] ReadGraph()
        {
            var graph = new Node[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                var line = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    var node = new Node(i, j, line[j]);
                    graph[i, j] = node;
                }
            }

            return graph;
        }

        #endregion

        static void Main(string[] args)
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            var graph = ReadGraph();
            List<int> path = FindPath(graph);

            Console.WriteLine("Length: " + path.Sum());
            Console.WriteLine("Path: " + string.Join(" ", path));
        }

        private static List<int> FindPath(Node[,] graph)
        {
            var firstNode = graph[0, 0];
            var endNode = graph[rows - 1, cols - 1];
            PriorityQueue<Node> q = new PriorityQueue<Node>();

            q.Enqueue(firstNode);
            firstNode.DistanceFromStart = firstNode.Weigth;
            firstNode.Visited = true;

            while (q.Count != 0)
            {
                var currNode = q.ExtractMin();
                if (currNode.Equals(endNode))
                    break;

                var childNodes = new List<Node>();
                if (currNode.Y + 1 < cols)
                    childNodes.Add(graph[currNode.X, currNode.Y + 1]);
                if (currNode.X + 1 < rows)
                    childNodes.Add(graph[currNode.X + 1, currNode.Y]);
                if (currNode.Y - 1 >= 0)
                    childNodes.Add(graph[currNode.X, currNode.Y - 1]);
                if (currNode.X - 1 >= 0)
                    childNodes.Add(graph[currNode.X - 1, currNode.Y]);

                foreach (var child in childNodes)
                {
			        if(child.Visited == false)
			        {
				        q.Enqueue(child);
                        child.Visited = true;
			        }

			        var newDistance = currNode.DistanceFromStart + child.Weigth;
			        if (newDistance <= child.DistanceFromStart)
			        {
                        if (newDistance == child.DistanceFromStart && child.X < currNode.X)
                            break;
                        if (newDistance == child.DistanceFromStart && child.Y < currNode.Y)
                            break;

                        child.DistanceFromStart = newDistance;
				        child.Previous = currNode;
				        q.DecreaseKey(child);
			        }
                }
            }

            var path = new List<int>();
            while (endNode != null)
            {
                path.Add(endNode.Weigth);
                endNode = endNode.Previous;
            }

            path.Reverse();
            return path;
        }
    }
}
