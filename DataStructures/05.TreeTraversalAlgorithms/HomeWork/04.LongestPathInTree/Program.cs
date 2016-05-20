namespace _04.LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LongestPathInATree
    {
        private static IDictionary<int, IList<int>> childNodes;
        private static IDictionary<int, int?> parents;
        private static IDictionary<int, int> nodeToRootSum;

        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            childNodes = new Dictionary<int, IList<int>>(nodesCount);
            parents = new Dictionary<int, int?>(nodesCount);
            nodeToRootSum = new Dictionary<int, int>(nodesCount);

            AddNodes(edgesCount);

            var root = FindRoot();
            DepthFirstSearch(root, 0);

            var longestPath = 0;
            longestPath = FindLongestPath(longestPath);

            Console.WriteLine(longestPath);
        }

        private static void AddNodes(int edgesCount)
        {
            for (int node = 0; node < edgesCount; node++)
            {
                var parentChildPair = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentParent = parentChildPair[0];
                var currentChild = parentChildPair[1];

                AddPair(currentParent, currentChild);
            }

            foreach (var node in childNodes.Keys)
            {
                nodeToRootSum[node] = 0;
            }
        }

        private static int FindLongestPath(int longestPath)
        {
            foreach (var nodeA in nodeToRootSum)
            {
                foreach (var nodeB in nodeToRootSum)
                {
                    if (nodeA.Key != nodeB.Key)
                    {
                        var currentPath = nodeA.Value - nodeB.Value + nodeB.Key;
                        if (currentPath > longestPath)
                        {
                            longestPath = currentPath;
                        }
                    }
                }
            }

            return longestPath;
        }

        private static int FindRoot()
        {
            var root = parents.FirstOrDefault(node => node.Value == null).Key;

            return root;
        }

        private static void DepthFirstSearch(int node, int totalSum)
        {
            totalSum += node;
            nodeToRootSum[node] = totalSum;

            foreach (var child in childNodes[node])
            {
                DepthFirstSearch(child, totalSum);
            }
        }

        private static void AddPair(int parent, int child)
        {
            if (!childNodes.ContainsKey(parent))
            {
                childNodes[parent] = new List<int>();
            }

            childNodes[parent].Add(child);

            if (!childNodes.ContainsKey(child))
            {
                childNodes[child] = new List<int>();
            }

            if (!parents.ContainsKey(parent))
            {
                parents[parent] = null;
            }

            parents[child] = parent;
        }
    }
}
