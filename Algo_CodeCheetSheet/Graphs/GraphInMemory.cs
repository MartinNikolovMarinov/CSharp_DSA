// Graph is denoted as G(V, E)
// Set of nodes V with many-to-many relation/edges E between them.

// Adjacency list.
// Pluses : 
//		Uses minimum amount of memory O(V + E).
//		Get list of neighbors is fast/constant.
// Minuses :
//		Figuring out if certain edges are connected is slow/linear.
static List<int>[] graph = new List<int>[]
{
	new List<int> {3, 6}, 
	new List<int> {2, 3, 4, 5, 6},
	new List<int> {1, 4, 5},
	new List<int> {0, 1, 5},
	new List<int> {1, 2, 6},
	new List<int> {1, 2, 3},
	new List<int> {0, 1, 4}
};

// Adjacency matrix.
// Pluses :
//		Figuring out if certain edges are connected is fast/constant.
// Minuses :
//		Uses more than minimal memory O(V * V)
// 		Get list of neighbors is slow/linear.
var graph = new[,]
{
   { 0, 0, 0, 1, 0, 0, 1 },
   { 0, 0, 1, 1, 1, 1, 1 },
   { 0, 1, 0, 0, 1, 1, 0 },
   { 1, 1, 0, 0, 0, 1, 0 },
   { 0, 1, 1, 0, 0, 0, 1 },
   { 0, 1, 1, 1, 0, 0, 0 },
   { 1, 1, 0, 0, 1, 0, 0 }
};

// List of edges :
// Has no pluses, but it's simpler for the programmer.
class Edge
{
  public int Parent {get; set; }
  public int Child {get; set; }
}

var graph = new List<Edge>() 
{
  new Edge() { Parent = 0, Child = 3 },
  new Edge() { Parent = 0, Child = 6 },
  ...
}