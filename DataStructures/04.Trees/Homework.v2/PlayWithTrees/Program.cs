namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < nodesCount - 1; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = Tree<int>.GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = Tree<int>.GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Root node: {0}", Tree<int>.FindRootNode().Value);

            var leafNodes = Tree<int>
                .FindLeafs()
                .OrderBy(n => n.Value)
                .ToList();

            Console.Write("Leaf nodes: ");
            for (int i = 0; i < leafNodes.Count; i++)
            {
                if (i == leafNodes.Count - 1)
                {
                    Console.Write("{0}", leafNodes[i].Value);
                }
                else
                {
                    Console.Write("{0}, ", leafNodes[i].Value);
                }
            }
            Console.WriteLine();

            var middleNodes = Tree<int>
                .FindMiddleNodes()
                .OrderBy(n => n.Value)
                .ToList();
            Console.Write("Middle nodes: ");
            for (int i = 0; i < middleNodes.Count; i++)
            {
                if (i == middleNodes.Count - 1)
                {
                    Console.Write("{0}", middleNodes[i].Value);
                }
                else
                {
                    Console.Write("{0}, ", middleNodes[i].Value);
                }
            }
            Console.WriteLine();

            var longestPath = Tree<int>.FindDeepestPath();
            longestPath.Reverse();
            Console.Write("Longest Path: ");
            for (int i = 0; i < longestPath.Count; i++)
            {
                if (i == longestPath.Count - 1)
                {
                    Console.Write("{0} ", longestPath[i].Value);
                }
                else
                {
                    Console.Write("{0} -> ", longestPath[i].Value);
                }
            }
            Console.WriteLine("(length = {0})", longestPath.Count);

            var paths = Tree<int>.FindPathsWithSum(27);
            Console.WriteLine("Paths of sum 27: ");
            foreach (var path in paths)
            {
                var currentNode = path;
                var buffer = new List<int>();

                while (currentNode != null)
                {
                    buffer.Add(currentNode.Value);
                    currentNode = currentNode.Parent;
                }

                for (int i = buffer.Count - 1; i >= 0; i--)
                {
                    Console.Write("{0}{1}", buffer[i], i == 0 ? "" : " -> ");
                }

                Console.WriteLine();
            }

            var subPaths = Tree<int>.FindSubPathsWithSum(subtreeSum);
            Console.WriteLine("Subtrees of sum 43: ");
            foreach (var node in subPaths)
            {
                Console.Write(node.Value);

                foreach (var child in node.Children)
                {
                    Console.Write(" + {0}", child.Value);
                }
            }
            Console.WriteLine();
        }
    }
}
