using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public class CountOfOccurences
    {
        public static string CountOccurences(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int currElement = arr[i];
                int count = 1;

                for (int j = i; j < arr.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (currElement == arr[j])
                    {
                        count++;
                    }
                }

                if (!result.ContainsKey(currElement))
                {
                    result.Add(currElement, count);
                }
            }

            var keysList = result.Keys.ToList();
            keysList.Sort();

            for (int i = 0; i < keysList.Count; i++)
			{
                int currNumber = keysList[i];
                int currNumberOccurences = result[keysList[i]];
                sb.AppendFormat("{0} -> {1} times{2}", currNumber, currNumberOccurences, Environment.NewLine);
			}

            return sb.ToString().Trim();
        }
    }
}
