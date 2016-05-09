public class Node<T>
{
    public T Value;
    public Node<T> Parent;
    public List<Node<T>> Children { get; set; }
    public bool Visited { get; set; }
    public int Distance;

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
        return string.Format("{0} -> {{ parent = {1}, dist = {2} }}", Value, 
            this.Parent != null ? Parent.Value.ToString() : "null", Distance);
    }
}

static void BFS<T>(Node<T> startNode, Action<Node<T>> action)
{
    Node<T> currNode = null;
    var q = new Queue<Node<T>>();
    q.Enqueue(startNode);
    startNode.Distance = 0;
    startNode.Visited = true;

    while (q.Count != 0)
    {
        currNode = q.Dequeue();

        foreach (var child in currNode.Children)
        {
            if (child.Visited == false)
            {
                child.Parent = currNode;
                child.Distance = currNode.Distance + 1;
                q.Enqueue(child);
                child.Visited = true;
            }
        }
        
        if (action != null)
            action(currNode);
    }
}

// Example 1 :
public static void Main()
{
    var graph = new List<Node<char>>()
    {
        new Node<char>('v'),
        new Node<char>('r'),
        new Node<char>('s'),
        new Node<char>('w'),
        new Node<char>('t'),
        new Node<char>('x'),
        new Node<char>('u'),
        new Node<char>('y'),
    };

    // v -> r
    graph[0].Children.Add(graph[1]);

    // r -> v, s
    graph[1].Children.Add(graph[0]);
    graph[1].Children.Add(graph[2]);

    // s -> r, w
    graph[2].Children.Add(graph[1]);
    graph[2].Children.Add(graph[3]);

    // w -> s, t, x
    graph[3].Children.Add(graph[2]);
    graph[3].Children.Add(graph[4]);
    graph[3].Children.Add(graph[5]);
    
    // t -> w, x, u
    graph[4].Children.Add(graph[3]);
    graph[4].Children.Add(graph[5]);
    graph[4].Children.Add(graph[6]);

    // x -> w, t, u, y
    graph[5].Children.Add(graph[3]);
    graph[5].Children.Add(graph[4]);
    graph[5].Children.Add(graph[6]);
    graph[5].Children.Add(graph[7]);

    // u -> t, x, y
    graph[6].Children.Add(graph[4]);
    graph[6].Children.Add(graph[5]);
    graph[6].Children.Add(graph[7]);

    // y -> x, u
    graph[7].Children.Add(graph[5]);
    graph[7].Children.Add(graph[6]);

    BFS(graph[2], x => { Console.WriteLine(x); });
}