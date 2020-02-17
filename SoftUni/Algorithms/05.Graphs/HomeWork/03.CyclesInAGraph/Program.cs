namespace _03.CyclesInAGraph
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class Program
	{
		static Dictionary<char, List<char>> graph;
		static HashSet<char> visited;
        static HashSet<char> cycleNodes;
        static char ignoreLastNode;
        static bool cycleDetected;

		static void Main(string[] args)
		{
			graph = ReadGraph();
			visited = new HashSet<char>();
            cycleNodes = new HashSet<char>();
            cycleDetected = false;

			foreach (var item in graph.Keys)
			{
                ignoreLastNode = item;
				DFSFindCycle(item);
                if (cycleDetected)
                    break;
			}

            Console.WriteLine("Acyclic: {0}", cycleDetected ? "No" : "Yes");
		}

        private static void DFSFindCycle(char node)
		{
            if (cycleNodes.Contains(node) && ignoreLastNode != node)
            {
                cycleDetected = true;
                return;
            }

			if (visited.Contains(node) == false)
			{
				visited.Add(node);
                ignoreLastNode = cycleNodes.LastOrDefault();
                cycleNodes.Add(node);
                
				foreach (char child in graph[node])
				{
					DFSFindCycle(child);
				}

                cycleNodes.Remove(node);
			}
		}

		private static Dictionary<char, List<char>> ReadGraph()
		{
			char from, to;
			graph = new Dictionary<char, List<char>>();
			string line = Console.ReadLine();

			while (!String.IsNullOrWhiteSpace(line))
			{
				string[] split = line.Split();
				from = split[0][0];
				to = split[2][0];

				if (graph.ContainsKey(from) == false)
					graph.Add(from, new List<char>());
				if (graph.ContainsKey(to) == false)
					graph.Add(to, new List<char>());
				
				graph[from].Add(to);
				graph[to].Add(from);
				line = Console.ReadLine();
			}

			return graph;
		}
	}
}
