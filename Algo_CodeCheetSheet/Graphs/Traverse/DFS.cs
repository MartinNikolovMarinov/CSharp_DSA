static List<int>[] graph = new List<int>[]
{
	new List<int>() { 1, 4 },
	new List<int>() { 0, 2, 4 },
	new List<int>() { 3, 1 },
	new List<int>() { 2, 4, 5 },
	new List<int>() { 0, 1, 3 },
	new List<int>() { 3 }
};
static bool[] visited = new bool[graph.Length];

// Use this.
static void DFS_REC(int node, Action<int> action)
{
	if (visited[node] == false)
	{
		visited[node] = true;
		if (action != null)
			action(node);

		foreach (int child in graph[node])
		{
			DFS_REC(child, action);
		}
	}
}

// Example with no recursion(it's a little bit different).
static void DFS_IT(int startNode, Action<int> action)
{
	int currNode = 0;
	Stack<int> s = new Stack<int>();
	s.Push(startNode);
	visited[startNode] = true;

	while (s.Count != 0)
	{
		currNode = s.Pop();
		if (action != null)
			action(currNode);

		foreach (var child in graph[currNode])
		{
			if (visited[child] == false)
			{
				s.Push(child);
				visited[child] = true;
			}
		}
	}
}