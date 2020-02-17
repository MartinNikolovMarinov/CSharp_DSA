namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int startNode, int destNode)
        {
            int n = graph.GetLength(0);

            // These three could be stored in a Node class.
            int[] distance = new int[n]; // Stores distance from the source node.
            bool[] visited = new bool[n]; // Marks visited nodes.
            int[] previous = new int[n]; // Stores the node we came from.
            // Initialize the arrays :
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
                previous[i] = -1;    
            }

            distance[startNode] = 0; // Mark the starting node as visited.

            while (true)
            {
                // Find the nearest unused node :
                int minDist = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if(visited[node] == false && distance[node] < minDist)
                    {
                        minDist = distance[node];
                        minNode = node;
                    }
                }

                // No more paths to take.
                if (minDist == int.MaxValue)
                    break;
                // Found the node we were searching for.
                if (visited[destNode] == true)
                    break;

                // Improve the distance[0..n-1] through minNode.
                visited[minNode] = true;
                for (int i = 0; i < n; i++)
                {
                    if(graph[minNode, i] > 0)
                    {
                        int newDist = distance[minNode] + graph[minNode, i];
                        if (newDist < distance[i])
                        {
                            distance[i] = newDist;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            // No path found from source to destination.
            if (distance[destNode] == int.MaxValue)
                return null;

            var path = new List<int>();
            int currNode = destNode;
            while (currNode != -1)
            {
                path.Add(currNode);
                currNode = previous[currNode];
            }

            path.Reverse();
            return path;
        }
    }
}
