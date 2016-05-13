namespace _01.CableCompany
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<Edge>[] graph;
        static int budget;
        static int budgetUsed;
        static int nodeCount;
        static int edgeCount;

        private static List<Edge>[] GenGraph(HashSet<int> connectedNodes)
        {
            var graph = new List<Edge>[nodeCount];
            for (int i = 0; i < edgeCount; i++)
            {
                var line = Console.ReadLine().Split();
                int startNode = int.Parse(line[0]);
                int endNode = int.Parse(line[1]);
                int weight = int.Parse(line[2]);
                bool connected = line.Length == 4 ? true : false;

                if (connected)
                {
                    // If edge is connected add it's nodes to the mst.
                    connectedNodes.Add(startNode);
                    connectedNodes.Add(endNode);
                }
                else
                {
                    // Else add it to the graph.
                    if (graph[startNode] == null)
                        graph[startNode] = new List<Edge>();
                    if (graph[endNode] == null)
                        graph[endNode] = new List<Edge>();

                    graph[startNode].Add(new Edge(startNode, endNode, weight));
                    graph[endNode].Add(new Edge(endNode, startNode, weight));
                }
            }

            return graph;
        }

        private static void Prim(HashSet<int> connectedNodes, List<Edge> newConnections)
        {
            var priorityQueue = new MinHeap<Edge>();
            foreach (int node in connectedNodes)
            {
                foreach (var edge in graph[node])
                {
                    // Every edge of already connected nodes must be added to the queue.
                    priorityQueue.Insert(edge);
                }
            }

            while (priorityQueue.Count != 0)
            {
                var smallestEdge = priorityQueue.GetMin();

                if (connectedNodes.Contains(smallestEdge.StartNode) ^
                    connectedNodes.Contains(smallestEdge.EndNode))
                {
                    budget -= smallestEdge.Weight;
                    if (budget > 0)
                    {
                        budgetUsed += smallestEdge.Weight;
                        newConnections.Add(smallestEdge);
                    }
                    else
                    {
                        break;
                    }

                    var nonTreeNode = connectedNodes.Contains(smallestEdge.StartNode) ?
                        smallestEdge.EndNode : smallestEdge.StartNode;
                    connectedNodes.Add(nonTreeNode);
                    foreach (var childEdge in graph[nonTreeNode])
                    {
                        priorityQueue.Insert(childEdge);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            budget = int.Parse(Console.ReadLine());
            budgetUsed = 0;
            nodeCount = int.Parse(Console.ReadLine());
            edgeCount = int.Parse(Console.ReadLine());
            var connectedNodes = new HashSet<int>();
            var connectedEdges = new List<Edge>();
            graph = GenGraph(connectedNodes);

            var newConnections = new List<Edge>();
            Prim(connectedNodes, newConnections);

            Console.WriteLine(string.Join("\n", newConnections));
            Console.WriteLine("Budget used: {0}", budgetUsed);
        }
    }
}
