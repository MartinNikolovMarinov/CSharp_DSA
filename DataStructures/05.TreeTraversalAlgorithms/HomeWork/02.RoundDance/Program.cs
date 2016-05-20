namespace _02.RoundDance
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int frednships = int.Parse(Console.ReadLine());
            int leader = int.Parse(Console.ReadLine());
            var nodes = new Dictionary<int, Node<int>>();

            for (int i = 0; i < frednships; i++)
            {
                string[] rawNodeInput = Console.ReadLine().Split();
                int currentValue = int.Parse(rawNodeInput[0]);
                int childValue = int.Parse(rawNodeInput[1]);
                bool parentNodeExists = nodes.ContainsKey(currentValue);
                bool childNodeExists = nodes.ContainsKey(childValue);
                Node<int> first, second;

                if (parentNodeExists && childNodeExists)
                {
                    // Both nodes exist
                    first = nodes[currentValue];
                    second = nodes[childValue];
                }
                else if (parentNodeExists)
                {
                    // Only parent exists
                    first = nodes[currentValue];
                    second = new Node<int>(childValue);

                    // Add child node to list
                    nodes.Add(childValue, second);
                }
                else if (childNodeExists)
                {
                    // Only child exists
                    first = new Node<int>(currentValue);
                    second = nodes[childValue];

                    // Add current node to list
                    nodes.Add(currentValue, first);
                }
                else
                {
                    // None exist
                    first = new Node<int>(currentValue);
                    second = new Node<int>(childValue);

                    if (currentValue == childValue)
                        throw new ArgumentException("Circular dependency.");

                    // Add both to list
                    nodes.Add(currentValue, first);
                    nodes.Add(childValue, second);
                }

                first.AddChild(second);
                second.AddChild(first);
            }

            Node<int> leaderNode = nodes[leader];
            FindLongestDance(leaderNode);
            Console.WriteLine(longestDance);
        }

        private static int currDanceLen = 1;
        private static int longestDance = 0;

        private static void FindLongestDance(Node<int> curr)
        {
            curr.Visited = true;
            if (!curr.HasNoChildren())
            {
                foreach (var node in curr.Children)
                {
                    if (!node.Visited)
                    {
                        currDanceLen++;
                        FindLongestDance(node);
                    }
                }
            }

            if (currDanceLen > longestDance)
                longestDance = currDanceLen;
            currDanceLen = 1;
        }
    }
}
