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

private static void Prim(HashSet<int> mstNodes, List<Edge> mstEdges, int startNode)
{
    mstNodes.Add(startNode);
    var priorityQueue = new MinHeap<Edge>();
    foreach (var childEdge in graph[startNode])
    {
        priorityQueue.Insert(childEdge);
    }

    while (priorityQueue.Count != 0)
    {
        var smallestEdge = priorityQueue.GetMin();

        // If one of the nodes is inside and one of the 
        // nodes is outside  of the minimal spanning tree.
        if (mstNodes.Contains(smallestEdge.StartNode) ^
            mstNodes.Contains(smallestEdge.EndNode))
        {
            // Add the edge to mst.
            mstEdges.Add(smallestEdge);
            // Find which one is outside.
            var nonTreeNode = mstNodes.Contains(smallestEdge.StartNode) ?
                smallestEdge.EndNode : smallestEdge.StartNode;
            // Add the node to mst.
            mstNodes.Add(nonTreeNode);
            // All child edges of the nodes get enqueue in the priority queue.
            foreach (var childEdge in graph[nonTreeNode])
            {
                priorityQueue.Insert(childEdge);    
            }
        }
    }
}

static List<Edge>[] graph;

private static List<Edge>[] GenGraph()
{
    var graph = new List<Edge>[] 
    {
        new List<Edge>() 
        {
            new Edge(0, 1, 4),
            new Edge(0, 2, 5),
            new Edge(0, 3, 9),
        },
        new List<Edge>() 
        {
            new Edge(1, 0, 4),
            new Edge(1, 3, 2),
        },
        new List<Edge>() 
        {
            new Edge(2, 0, 5),
            new Edge(2, 3, 20),
            new Edge(2, 4, 7),
        },
        new List<Edge>() 
        {
            new Edge(3, 1, 2),
            new Edge(3, 2, 20),
            new Edge(3, 4, 8),
        },
        new List<Edge>() 
        {
            new Edge(4, 2, 7),
            new Edge(4, 3, 8),
            new Edge(4, 5, 12),
        },
        new List<Edge>()
        {
            new Edge(5, 4, 12),
        },
        new List<Edge>() 
        {
            new Edge(6, 7, 8),
            new Edge(6, 8, 10),
        },
        new List<Edge>() 
        {
            new Edge(7, 6, 8),
            new Edge(7, 8, 7),
        },
        new List<Edge>() 
        {
            new Edge(8, 6, 10),
            new Edge(8, 7, 7),
        },
    };

    return graph;
}

// Example :
static void Main(string[] args)
{
    graph = GenGraph();
    var mstNodes = new HashSet<int>();
    var mstEdges = new List<Edge>();

    for (int v = 0; v < graph.Length; v++)
    {
        if (mstNodes.Contains(v) == false)
            Prim(mstNodes, mstEdges, v);
    }

    Console.WriteLine(string.Join("\n", mstEdges));
}