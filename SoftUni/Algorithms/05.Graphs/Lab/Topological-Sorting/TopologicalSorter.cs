using System;
using System.Linq;
using System.Collections.Generic;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visitedNodes;
    private LinkedList<string> sortedNodes;
    private HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort(bool iterative = true)
    {
        if (iterative)
        {
            return TopSortIT();
        }
        else
        {
            this.sortedNodes = new LinkedList<string>();
            this.visitedNodes = new HashSet<string>();
            this.cycleNodes = new HashSet<string>();

            foreach (var node in this.graph.Keys)
            {
                TopSortDFS(node);
            }

            return sortedNodes;
        }
    }

    private ICollection<string> TopSortIT()
    {
        var predecessorsCount = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
                predecessorsCount[node.Key] = 0;

            foreach (var childNode in node.Value)
            {
                if (!predecessorsCount.ContainsKey(childNode))
                    predecessorsCount[childNode] = 0;

                predecessorsCount[childNode]++;
            }
        }

        var removedNodes = new List<string>();
        while (true)
        {
            string nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorsCount[n] == 0);
            if (nodeToRemove == null)
                break;

            foreach (string children in this.graph[nodeToRemove])
            {
                predecessorsCount[children]--;
            }

            graph.Remove(nodeToRemove);
            removedNodes.Add(nodeToRemove);
        }

        if (graph.Count > 0)
            throw new InvalidOperationException("A cycle detected in the graph.");

        return removedNodes;
    }

    private void TopSortDFS(string node)
    {
        if (this.cycleNodes.Contains(node))
            throw new InvalidOperationException("A cycle detected in the graph.");

        if (!visitedNodes.Contains(node))
        {
            this.visitedNodes.Add(node);
            this.cycleNodes.Add(node);

            if (graph.ContainsKey(node))
            {
                foreach (string child in graph[node])
                {
                    TopSortDFS(child);
                }
            }

            this.cycleNodes.Remove(node);
            this.sortedNodes.AddFirst(node);
        }
    }
}
