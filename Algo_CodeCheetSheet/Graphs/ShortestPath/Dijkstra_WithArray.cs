// G = (V, E);
// Running Dijkstra Algorithm on a graph represented by a matrix[count(v), count(v)].
// The running time is O(|V| * |V|).

// Example graph :
var graph = new[,]
{
	// 0   1   2   3   4   5   6   7   8   9  10  11
	{ 0,  0,  0,  0,  0,  0, 10,  0, 12,  0,  0,  0 }, // 0
	{ 0,  0,  0,  0, 20,  0,  0, 26,  0,  5,  0,  6 }, // 1
	{ 0,  0,  0,  0,  0,  0,  0, 15, 14,  0,  0,  9 }, // 2
	{ 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  7,  0 }, // 3
	{ 0, 20,  0,  0,  0,  5, 17,  0,  0,  0,  0, 11 }, // 4
	{ 0,  0,  0,  0,  5,  0,  6,  0,  3,  0,  0, 33 }, // 5
	{10,  0,  0,  0, 17,  6,  0,  0,  0,  0,  0,  0 }, // 6
	{ 0, 26, 15,  0,  0,  0,  0,  0,  0,  3,  0, 20 }, // 7
	{12,  0, 14,  0,  0,  3,  0,  0,  0,  0,  0,  0 }, // 8
	{ 0,  5,  0,  0,  0,  0,  0,  3,  0,  0,  0,  0 }, // 9
	{ 0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0 }, // 10
	{ 0,  6,  9,  0, 11, 33,  0, 20,  0,  0,  0,  0 }, // 11
};

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
			if(graph[minNode, i] > 0) // All child nodes have a value bigger than 0.
			{
				// TODO: Comment here !
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