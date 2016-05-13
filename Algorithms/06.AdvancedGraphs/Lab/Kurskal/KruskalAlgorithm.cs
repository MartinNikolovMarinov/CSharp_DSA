namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parent = new int[numberOfVertices];
            var mst = new List<Edge>(edges.Count);
            
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
            
            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }
            
            return root;
        }
    }
}
