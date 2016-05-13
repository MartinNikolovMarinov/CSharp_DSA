namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node startNode, Node endNode)
        {
            int[] previous = new int[graph.Count];
            bool[] visited = new bool[graph.Count];
            PriorityQueue<Node> q = new PriorityQueue<Node>();

            for (int i = 0; i < graph.Count; i++)
            {
                previous[i] = -1;
            }

            foreach (var node in graph)
            {
                node.Key.DistanceFromStart = int.MaxValue;
            }

            q.Enqueue(startNode);
            startNode.DistanceFromStart = 0;

            while (q.Count != 0)
            {
                var currNode = q.ExtractMin();
                if (currNode.Index == endNode.Index)
                    break;

                foreach (var edge in graph[currNode])
                {
                    if(visited[edge.Key.Index] == false)
                    {
                        q.Enqueue(edge.Key);
                        visited[edge.Key.Index] = true;
                    }

                    var distance = currNode.DistanceFromStart + edge.Value;
                    if (distance < edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;
                        previous[edge.Key.Index] = currNode.Index;
                        q.DecreaseKey(edge.Key);
                    }
                }
            }

            if (previous[endNode.Index] == -1)
                return null;

            var path = new List<int>();
            int curr = endNode.Index;
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
