namespace _02.ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static List<Edge> graph;
        static int nodeCount;
        static int edgeCount;

        private static List<Edge> GenGraph()
        {
            var graph = new List<Edge>();
            for (int i = 0; i < edgeCount; i++)
            {
                var line = Console.ReadLine().Split();
                int startNode = int.Parse(line[0]);
                int endNode = int.Parse(line[1]);
                int weight = int.Parse(line[2]);

                graph.Add(new Edge(endNode, startNode, weight));
                graph.Add(new Edge(startNode, endNode, weight));
            }

            return graph;
        }

        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parent = new int[numberOfVertices];
            var mst = new List<Edge>(edges.Count); // minimal spanning tree

            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode) // No cycle
                {
                    mst.Add(edge);
                    parent[rootStartNode] = rootEndNode;
                }
            }

            return mst;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            // Attach all nodes to the root for optimization.
            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }

        static void Main(string[] args)
        {
            nodeCount = int.Parse(Console.ReadLine());
            edgeCount = int.Parse(Console.ReadLine());
            graph = GenGraph();
            var mst = Kruskal(nodeCount, graph);
            Console.WriteLine(string.Join("\n", mst));
        }
    }
}
