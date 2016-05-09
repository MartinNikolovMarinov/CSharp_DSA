namespace _01.DistanceBetweenVertices
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static int FindVertexDistance(Dictionary<int, List<int>> graph, int startNode, int searchedVertex)
        {
            int distance = 1;
            int currNode = 0;
            var q = new Queue<Tuple<int, int>>();
            var visited = new HashSet<int>();

            q.Enqueue(new Tuple<int, int>(startNode, 0));
            visited.Add(startNode);

            while (q.Count != 0)
            {
                var tmp = q.Dequeue();
                currNode = tmp.Item1;
                distance = tmp.Item2 + 1;
              
                foreach (int child in graph[currNode])
                {
                    if (child == searchedVertex)
                        return distance;

                    if (visited.Contains(child) == false)
                    {
                        q.Enqueue(new Tuple<int, int>(child, distance));
                        visited.Add(child);
                    }
                }
            }

            return -1;
        }

        static void ExampleOne()
        {
            var graph = new Dictionary<int, List<int>>()
            {
                { 1, new List<int> { 1, 2 } },
                { 2, new List<int> { } },
            };

            Console.WriteLine("Example one :");
            Console.WriteLine("{{1, 2}} -> {0}", FindVertexDistance(graph, 1, 2));
            Console.WriteLine("{{2, 1}} -> {0}", FindVertexDistance(graph, 2, 1));
        }

        static void ExampleTwo()
        {
            var graph = new Dictionary<int, List<int>>()
            {
	            { 1, new List<int> { 4 } },
                { 2, new List<int> { 4 } },
                { 3, new List<int> { 4, 5 } },
                { 4, new List<int> { 6 } },
                { 5, new List<int> { 3, 7, 8 } },
                { 6, new List<int> { } },
                { 7, new List<int> { 8 } },
                { 8, new List<int> { } }
            };

            Console.WriteLine("Example two :");
            Console.WriteLine("{{1, 6}} -> {0}", FindVertexDistance(graph, 1, 6));
            Console.WriteLine("{{1, 5}} -> {0}", FindVertexDistance(graph, 1, 5));
            Console.WriteLine("{{5, 6}} -> {0}", FindVertexDistance(graph, 5, 6));
            Console.WriteLine("{{5, 8}} -> {0}", FindVertexDistance(graph, 5, 8));
        }

        private static void ExampleThree()
        {
            var graph = new Dictionary<int, List<int>>()
            {
                { 11, new List<int> { 4 } },
                { 4, new List<int> { 12, 1 } },
                { 1, new List<int> { 12, 21, 7 } },
                { 7, new List<int> { 21 } },
                { 12, new List<int> { 4, 19 } },
                { 19, new List<int> { 1, 21 } },
                { 21, new List<int> { 14, 31 } },
                { 14, new List<int> { 14 } },
                { 31, new List<int> {  } }
            };

            Console.WriteLine("Example three :");
            Console.WriteLine("{{11, 7}} -> {0}", FindVertexDistance(graph, 11, 7));
            Console.WriteLine("{{11, 21}} -> {0}", FindVertexDistance(graph, 11, 21));
            Console.WriteLine("{{21, 4}} -> {0}", FindVertexDistance(graph, 21, 4));
            Console.WriteLine("{{19, 14}} -> {0}", FindVertexDistance(graph, 19, 14));
            Console.WriteLine("{{1, 4}} -> {0}", FindVertexDistance(graph, 1, 4));
            Console.WriteLine("{{1, 11}} -> {0}", FindVertexDistance(graph, 1, 11));
            Console.WriteLine("{{31, 21}} -> {0}", FindVertexDistance(graph, 31, 21));
            Console.WriteLine("{{11, 14}} -> {0}", FindVertexDistance(graph, 11, 14));
        }

        static void Main(string[] args)
        {
            ExampleOne();
            ExampleTwo();
            ExampleThree();
        }
    }
}
