// This algorithm find the shortest path between two nodes in a graph.
// Let G = (V, E);
// The algorithm uses O((|V|+|E|)*log(|V|)) time to complete.

public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
{
	private Dictionary<T, int> searchCollection; 
	private List<T> heap;

	public PriorityQueue()
	{
		this.heap = new List<T>();
		this.searchCollection = new Dictionary<T,int>();
	} 

	public int Count
	{
		get
		{
			return this.heap.Count;
		}
	}

	public T ExtractMin()
	{
		var min = this.heap[0];
		var last = this.heap[this.heap.Count - 1];
		this.searchCollection[last] = 0;
		this.heap[0] = last;
		this.heap.RemoveAt(this.heap.Count - 1);
		if (this.heap.Count > 0)
		{
			this.HeapifyDown(0);
		}

		this.searchCollection.Remove(min);

		return min;
	}

	public T PeekMin()
	{
		return this.heap[0];
	}

	public void Enqueue(T element)
	{
		this.searchCollection.Add(element, this.heap.Count);
		this.heap.Add(element);
		this.HeapifyUp(this.heap.Count - 1);
	}

	private void HeapifyDown(int i)
	{
		var left = (2 * i) + 1;
		var right = (2 * i) + 2;
		var smallest = i;

		if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
		{
			smallest = left;
		}

		if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
		{
			smallest = right;
		}

		if (smallest != i)
		{
			T old = this.heap[i];
			this.searchCollection[old] = smallest;
			this.searchCollection[this.heap[smallest]] = i;
			this.heap[i] = this.heap[smallest];
			this.heap[smallest] = old;
			this.HeapifyDown(smallest);
		}
	}

	private void HeapifyUp(int i)
	{
		var parent = (i - 1) / 2;
		while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
		{
			T old = this.heap[i];
			this.searchCollection[old] = parent;
			this.searchCollection[this.heap[parent]] = i;
			this.heap[i] = this.heap[parent];
			this.heap[parent] = old;

			i = parent;
			parent = (i - 1) / 2;
		}
	}

	public void DecreaseKey(T element)
	{
		int index = this.searchCollection[element];
		this.HeapifyUp(index);
	}

	public IEnumerator<T> GetEnumerator()
	{
		foreach (var item in this.heap)
		{
			yield return item;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	public override string ToString()
	{
		string t = string.Join(", ", this.heap);
		return t;
	}
}

public class Node : IComparable<Node>
{
	// set default value for the distance equal to positive infinity
	public Node(int index, int distance = int.MaxValue)
	{
		this.Index = index;
		this.DistanceFromStart = distance;
	}

	public int Index { get; set; }

	public int DistanceFromStart { get; set; }

	public int CompareTo(Node other)
	{
		return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
	}

	public override string ToString()
	{
		return string.Format("{0} -> {1}d", Index, DistanceFromStart);
	}
}

// The graph is an adjacency list of all nodes and their child nodes. 
public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Node startNode, Node endNode)
{
	int[] previous = new int[graph.Count]; // Remembers where we came from.
	bool[] visited = new bool[graph.Count]; // Marks which nodes gave been visited.
	PriorityQueue<Node> q = new PriorityQueue<Node>(); // The Queue has a few modifications.

	for (int i = 0; i < graph.Count; i++)
	{
		previous[i] = -1; // Initially all nodes haven't been reached and have no previous node.
	}

	foreach (var node in graph)
	{
		node.Key.DistanceFromStart = int.MaxValue; // All nodes have unknown distance from the start.
	}

	// We mark the first node as visited and the distance is 0.
	q.Enqueue(startNode);
	startNode.DistanceFromStart = 0;

	while (q.Count != 0)
	{
		var currNode = q.ExtractMin();
		if (currNode.Index == endNode.Index) // Reached the goal.
			break;

		foreach (var keyValuePair in graph[currNode])
		{
			var node = keyValuePair.Key;
			var nodeDistFromStart = keyValuePair.Value;

			// If the node is not visited we add it to the queue
			// and mark it as visited.
			if(visited[node.Index] == false)
			{
				q.Enqueue(node);
				visited[node.Index] = true;
			}

			// If the distance from the start to the currNode is
			// less than the new distance then we found a better path.
			var newDistance = currNode.DistanceFromStart + nodeDistFromStart;
			if (newDistance < node.DistanceFromStart)
			{
				node.DistanceFromStart = newDistance; // Set new distance.
				previous[node.Index] = currNode.Index; // Set the parent of the node to currNode.
				// Now that we have changed the currNode.DistanceFromStart we have
				// to reorder the PriorityQueue.
				q.DecreaseKey(node);
			}
		}
	}

	// If the parent of the node at endNode.Index is
	// -1, that means it's unreachable from startNode.Index.
	if (previous[endNode.Index] == -1)
		return null;

	// Reconstruct path and we are done !
	var path = new List<int>();
	int curr = endNode.Index;
	while (curr != -1)
	{
		path.Add(curr);
		curr = previous[curr];
	}

	path.Reverse();
	return path;
}