namespace PlayWithTrees
{
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T>
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        public T Value { get; set; }
        public Tree<T> Parent { get; set; }
        public List<Tree<T>> Children { get; set; }

        public Tree(T value, params Tree<T>[] children) 
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in this.Children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        public static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        public static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values.Where(
                node => node.Children.Count > 0 && node.Parent != null).ToList();
            return middleNodes;
        }

        public static IEnumerable<Tree<int>> FindLeafs()
        {
            var leafNodes = nodeByValue.Values.Where(
                node => node.Children.Count == 0).ToList();
            return leafNodes;
        }

        public static List<Tree<int>> FindDeepestPath()
        {
            Tree<int> deepestNode = null;
            int depthCounter = 0;

            foreach (var node in nodeByValue.Values)
            {
                var currentNode = node;
                int currentDepth = 0;

                while (currentNode.Parent != null)
                {
                    currentDepth++;
                    currentNode = currentNode.Parent;
                }

                if (currentDepth > depthCounter)
                {
                    depthCounter = currentDepth;
                    deepestNode = node;
                }
            }

            List<Tree<int>> path = new List<Tree<int>>();
            while (deepestNode != null)
            {
                path.Add(deepestNode);
                deepestNode = deepestNode.Parent;
            }

            return path;
        }

        public static List<Tree<int>> FindPathsWithSum(int sum)
        {
            List<Tree<int>> paths = new List<Tree<int>>();

            foreach (var node in nodeByValue.Values)
            {
                Tree<int> currentNode = node;
                int currentSum = currentNode.Value;

                while (currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    currentSum += currentNode.Value;
                }

                if (currentSum == sum)
                {
                    paths.Add(node);
                }
            }

            return paths;
        }

        private static int SumTree(Tree<int> node, int treeSum)
        {
            foreach (var child in node.Children)
            {
                treeSum += child.Value;
                SumTree(child, treeSum);
            }

            return treeSum;
        }

        public static List<Tree<int>> FindSubPathsWithSum(int sum)
        {
            List<Tree<int>> subTreeRoots = new List<Tree<int>>();

            foreach (var node in nodeByValue.Values)
            {
                int currentSum = 0;
                currentSum = SumTree(node, node.Value);

                if (currentSum == sum)
                {
                    subTreeRoots.Add(node);
                }
            }

            return subTreeRoots;
        }
    }
}
