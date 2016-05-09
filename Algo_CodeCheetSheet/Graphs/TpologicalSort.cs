private static bool[] visitedNodes;
private static LinkedList<int> sortedNodes;
private static HashSet<int> cycleNodes;

public static ICollection<int> TopSort(List<int>[] graph)
{
	visitedNodes = new bool[graph.Length];
	sortedNodes = new LinkedList<int>();
	cycleNodes = new HashSet<int>();

	for (int i = 0; i < graph.Length; i++)
	{
		TopSortDFS(graph, i);
	}

	return sortedNodes;
}

private static void TopSortDFS(List<int>[] graph, int node)
{
	if (cycleNodes.Contains(node))
		throw new InvalidOperationException("A cycle detected in the graph.");

	if (visitedNodes[node] == false)
	{
		visitedNodes[node] = true;
		cycleNodes.Add(node);
		foreach (int child in graph[node])
		{
			TopSortDFS(graph, child);
		}

		cycleNodes.Remove(node);
		sortedNodes.AddFirst(node);
	}
}