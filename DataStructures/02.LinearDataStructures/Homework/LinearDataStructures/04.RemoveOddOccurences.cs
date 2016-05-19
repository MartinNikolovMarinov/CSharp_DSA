using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public class RemoveOddOccurences
    {
        public static int[] RemoveNumbersWithOddOccurence(int[] arr)
        {
            List<int> result = new List<int>(arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                int currElement = arr[i];
                int occurencesCount = 1;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (currElement == arr[j])
                    {
                        occurencesCount++;
                    }
                }

                if (occurencesCount % 2 == 0)
                {
                    result.Add(currElement);
                }
            }

            return result.ToArray();
        }
    }
}
