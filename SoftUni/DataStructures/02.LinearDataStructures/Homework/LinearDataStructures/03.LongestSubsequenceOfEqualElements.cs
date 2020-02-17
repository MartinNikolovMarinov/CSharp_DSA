using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public static class LongestSubsequenceOfEqualElements
    {
        public static int[] LongestSequenceOfEqualElements(int[] arr)
        {
            if (arr.Length == 0)
            {
                return arr;
            }

            int sequenceCount = 0;
            int currSequenceCount = 0;
            int endIndex = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    currSequenceCount++;
                }
                else
                {
                    currSequenceCount = 0;
                }

                if (currSequenceCount > sequenceCount)
                {
                    sequenceCount = currSequenceCount;
                    endIndex = i + 1;
                }
            }

            int startIndex = endIndex - sequenceCount;
            int[] sequence = new int[sequenceCount + 1];
            Array.Copy(arr, startIndex, sequence, 0, sequenceCount + 1);
            return sequence;
        }
    }
}
