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

static void BFS(int startNode, Action<int> action)
{
	int currNode = 0;
	Queue<int> q = new Queue<int>();
	q.Enqueue(startNode);
	visited[startNode] = true;

	while (q.Count != 0)
	{
		currNode = q.Dequeue();
		if (action != null)
			action(currNode);

		foreach (int child in graph[currNode])
		{
			if (visited[child] == false)
			{
				q.Enqueue(child);
				visited[child] = true;
			}
		}
	}
}