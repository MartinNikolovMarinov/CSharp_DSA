using System;
using System.Linq;
using System.Collections.Generic;


public class GraphConnectedComponents
{
    static bool[] visited;
    static List<int>[] graph;
    /*
        = new List<int>[]
    {
        new List<int>() { 3, 6 },
        new List<int>() { 3, 4, 5, 6 },
        new List<int>() { 8 },
        new List<int>() { 0, 1, 5 },
        new List<int>() { 1, 6 },
        new List<int>() { 1, 3 },
        new List<int>() { 0, 1, 4 },
        new List<int>() { },
        new List<int>() { 2 }
    };
    */

    static void DFS(int node) 
    {
        if (!visited[node])
        {
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child);
            }
            Console.Write(" " + node);
        }
    }

    static void FindGrapthConnectedComponents() 
    {
        visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }

    }

    static List<int>[] ReadGrapth()
    {
        int n = int.Parse(Console.ReadLine());
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }

        return graph;
    }

    public static void Main()
    {
        graph = ReadGrapth();
        FindGrapthConnectedComponents();
    }
}
