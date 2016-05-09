public class Node<T>
{
	public T Value;
	public List<Node<T>> Children { get; set; }
	public bool Visited { get; set; }
	public int DiscoveryTime { get; set; }
	public int FinishTime { get; set; }

	public Node(T val)
	{
		this.Value = val;
		this.Children = new List<Node<T>>();
	}

	public override int GetHashCode()
	{
		return this.Value.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("{0} -> {{ d = {1}, f = {2} }}", Value, DiscoveryTime, FinishTime);
	}
}

static int visitTime;

public static void DFS<T>(Node<T> node, Action<Node<T>> action)
{
	if (node.Visited == false)
	{
		node.Visited = true;
		node.DiscoveryTime = visitTime++;

		foreach (var child in node.Children)
		{
			DFS(child, action);
		}

		node.FinishTime = visitTime++;
		if (action != null)
			action(node);
	}
}

// Example 1 :
public static void Main()
{
	visitTime = 1;
	var graph = new List<Node<char>>()
	{
		new Node<char>('u'),
		new Node<char>('v'),
		new Node<char>('w'),
		new Node<char>('x'),
		new Node<char>('y'),
		new Node<char>('z'),
	};

	// u -> v, x
	graph[0].Children.Add(graph[1]);
	graph[0].Children.Add(graph[3]);
	// v -> y
	graph[1].Children.Add(graph[4]);
	// w -> y, z
	graph[2].Children.Add(graph[4]);
	graph[2].Children.Add(graph[5]);
	// x -> v
	graph[3].Children.Add(graph[1]);
	// y -> x
	graph[4].Children.Add(graph[3]);
	// z -> z
	graph[5].Children.Add(graph[5]);

	foreach (var node in graph)
	{
		DFS<char>(node, x => { Console.WriteLine(x); });
	}
}

// Example 2 :
public static void Main()
{
	visitTime = 1;
	var graph = new List<Node<char>>()
	{
		new Node<char>('s'),
		new Node<char>('z'),
		new Node<char>('y'),
		new Node<char>('x'),
		new Node<char>('w'),
		new Node<char>('t'),
		new Node<char>('v'),
		new Node<char>('u'),
	};

	// s -> z, w
	graph[0].Children.Add(graph[1]);
	graph[0].Children.Add(graph[4]);
	// z -> y, w
	graph[1].Children.Add(graph[2]);
	graph[1].Children.Add(graph[4]);
	// y -> x
	graph[2].Children.Add(graph[3]);
	// x -> z
	graph[3].Children.Add(graph[1]);
	// w -> x
	graph[4].Children.Add(graph[3]);
	// t -> v, u
	graph[5].Children.Add(graph[6]);
	graph[5].Children.Add(graph[7]);
	// v -> s, w
	graph[6].Children.Add(graph[0]);
	graph[6].Children.Add(graph[4]);
	// u -> t, v
	graph[7].Children.Add(graph[5]);
	graph[7].Children.Add(graph[6]);

	foreach (var node in graph)
	{
		DFS<char>(node, x => { Console.WriteLine(x); });
	}
}