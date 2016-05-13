public class Edge : IComparable<Edge>
{
	public Edge(int startNode, int endNode, int weight)
	{
		this.StartNode = startNode;
		this.EndNode = endNode;
		this.Weight = weight;
	}

	public int StartNode { get; set; }

	public int EndNode { get; set; }

	public int Weight { get; set; }

	public int CompareTo(Edge other)
	{
		int diff = this.Weight.CompareTo(other.Weight);
		return diff;
	}

	public override string ToString()
	{
		return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
	}
}

public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
{
	edges.Sort();
	var parent = new int[numberOfVertices];
	var mst = new List<Edge>(edges.Count); // minimal spanning tree
	
	for (int i = 0; i < numberOfVertices; i++)
	{
		parent[i] = i;
	}

	foreach (var edge in edges)
	{
		int rootStartNode = FindRoot(edge.StartNode, parent);
		int rootEndNode = FindRoot(edge.EndNode, parent);
		if (rootStartNode != rootEndNode) // No cycle
		{
			mst.Add(edge);
			parent[rootStartNode] = rootEndNode;
		}
	}

	return mst;
}

public static int FindRoot(int node, int[] parent)
{
	int root = node;
	while (parent[root] != root)
	{
		root = parent[root];
	}
	
	// Attach all nodes to the root for optimization.
	while (node != root)
	{
		var oldParent = parent[node];
		parent[node] = root;
		node = oldParent;
	}
	
	return root;
}