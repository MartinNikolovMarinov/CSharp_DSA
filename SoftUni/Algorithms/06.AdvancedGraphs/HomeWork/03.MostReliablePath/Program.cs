namespace _03.MostReliablePath
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static int nodesCount, edgeCount, startIndex, endIndex;
        static Dictionary<int, Node> graph;

        private static Dictionary<int, Node> ReadGraph()
        {
            nodesCount = int.Parse(Console.ReadLine());
            var line = Console.ReadLine().Split();
            startIndex = int.Parse(line[0]);
            endIndex = int.Parse(line[1]);
            edgeCount = int.Parse(Console.ReadLine());
            graph = new Dictionary<int, Node>();

            for (int i = 0; i < edgeCount; i++)
            {
                line = Console.ReadLine().Split();
                int s = int.Parse(line[0]);
                int e = int.Parse(line[1]);
                int w = int.Parse(line[2]);

                if (graph.ContainsKey(s) == false)
                    graph.Add(s, new Node(s));
                if (graph.ContainsKey(e) == false)
                    graph.Add(e, new Node(e));

                graph[s].AddChild(new Edge(s, e, w));
                graph[e].AddChild(new Edge(e, s, w));
            }

            return graph;
        }
        
        static void Main(string[] args)
        {
            graph = ReadGraph();
            var path = FindMostReliablePath();
            Console.WriteLine("Most reliable path reliability: {0:0.00}", graph[endIndex].ReliabilityFromStart);
            Console.WriteLine(string.Join("->", path));
        }

        private static List<int> FindMostReliablePath()
        {
            int[] previous = new int[graph.Count];
            PriorityQueue<Node> q = new PriorityQueue<Node>();

            for (int i = 0; i < graph.Count; i++)
            {
                graph[i].Visited = false;
                graph[i].ReliabilityFromStart = 0;
                previous[i] = -1;
            }

            q.Enqueue(graph[startIndex]);
            graph[startIndex].ReliabilityFromStart = 100;
            graph[startIndex].Visited = true;

            while (q.Count != 0)
            {
                var currNode = q.ExtractMin();
                if (currNode.Index == endIndex)
                    break;

                foreach (var edge in graph[currNode.Index].ChildEdges)
                {
                    var endNode = graph[edge.EndNode];
                    // var endNode = graph[edge.EndNode];

                    if (endNode.Visited == false)
                    {
                        endNode.Visited = true;
                        q.Enqueue(endNode);
                    }

                    double distance;
                    if (currNode.ReliabilityFromStart == 0)
                        distance = edge.Reliability;
                    else
                        distance = (currNode.ReliabilityFromStart * edge.Reliability) / 100d;

                    if (distance > endNode.ReliabilityFromStart)
                    {
                        endNode.ReliabilityFromStart = distance;
                        previous[endNode.Index] = currNode.Index;
                        q.DecreaseKey(endNode);
                    }
                }
            }


            if (previous[endIndex] == -1)
                return null;

            var path = new List<int>();
            int curr = endIndex;
            while (curr != -1)
            {
                path.Add(curr);
                curr = previous[curr];
            }

            path.Reverse();
            return path;
        }

    }
}
