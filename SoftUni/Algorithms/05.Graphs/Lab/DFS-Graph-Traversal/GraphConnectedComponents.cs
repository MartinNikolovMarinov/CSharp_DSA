using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<List<int>> connectedComponents;
    static int currentComponent = 0;
    static bool[] visited = null;
    static List<int>[] graph = new List<int>[]
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

    public static void Main()
    {
        graph = ReadGraph();
        visited = new bool[graph.Length];
        connectedComponents = new List<List<int>>();
        currentComponent = 0;
        FindGraphConnectedComponents();
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }

        return graph;
    }

    private static void FindGraphConnectedComponents()
    {
        for (int i = 0; i < graph.Length; i++)
        {
            if (visited[i] == false)
            {
                DFS(i);
                currentComponent++;
            }
        }

        foreach (var comp in connectedComponents)
        {
            Console.WriteLine("Connected component: " + string.Join(" ", comp));
        }
    }

    private static void DFS(int node)
    {
        if (visited[node] == false)
        {
            visited[node] = true;
            foreach (int currNode in graph[node])
            {
                DFS(currNode);
            }

            if (connectedComponents.Count == currentComponent)
                connectedComponents.Add(new List<int>());
            connectedComponents[currentComponent].Add(node);
        }
    }
}
