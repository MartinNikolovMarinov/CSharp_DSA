namespace _04.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<List<int>> graph;
        static HashSet<int> bosses;
        static bool[] visited;
        static long[] salaries;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            visited = new bool[graph.Count];
            salaries = new long[graph.Count];// Enumerable.Repeat(1, graph.Count).ToArray();

            foreach (int boss in bosses)
            {
                if (visited[boss] == false)
                    FindSalary(boss);
            }

            Console.WriteLine(salaries.Sum());
        }

        private static void FindSalary(int node)
        {
            if (visited[node] == false)
            {
                visited[node] = true;

                foreach (int child in graph[node])
                {
                    FindSalary(child);
                }

                long salary = 0;
                foreach (int child in graph[node])
                {
                    salary += salaries[child];
                }

                if (salary == 0)
                    salaries[node] = 1;
                else
                    salaries[node] = salary;
            }
        }

        private static List<List<int>> ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            var graph = new List<List<int>>(n);
            bosses = new HashSet<int>(Enumerable.Range(0, n));

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                graph.Add(new List<int>(line.Length));
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i].Add(j);
                        if (bosses.Contains(j))
                            bosses.Remove(j);
                    }
                }
            }

            return graph;
        }
    }
}
