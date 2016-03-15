namespace _01.FindTheRoot
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[n];
            
            for (int i = 0; i < m; i++)
			{
			    string[] rawInput = Console.ReadLine().Split();
                int childValue = int.Parse(rawInput[1]);
                hasParent[childValue] = true;
			}

            var noParentNodes = new List<int>();
            for (int i = 0; i < n; i++)
			{
			    if (hasParent[i] == false)
                {
		            noParentNodes.Add(i);
                }
			}

            switch (noParentNodes.Count)
            {
                case 0:
                    Console.WriteLine("No root!");
                    break;
                case 1:
                    Console.WriteLine(noParentNodes[0]);
                    break;
                default:
                    Console.WriteLine("Multiple root nodes!");
                    break;
            }
        }
    }
}
