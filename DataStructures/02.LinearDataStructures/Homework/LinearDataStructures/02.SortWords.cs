using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LinearDataStructures
{
    public static class WordSorting
    {
        private static List<string> SplitWords(string input) 
        {
            List<string> splitInput = new List<string>();
            StringBuilder charBuffer = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    if (charBuffer.Length != 0)
                    {
                        splitInput.Add(charBuffer.ToString());
                        charBuffer.Clear();
                    }
                }
                else
                {
                    charBuffer.Append(input[i]);    
                }
            }

            if (charBuffer.Length != 0)
            {
                splitInput.Add(charBuffer.ToString());
            }

            return splitInput;
        }

        private static void Swap<T>(ref T lhs, ref T rhs) 
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        private static void QuickSort<T>(List<T> arr, int left, int right) where T : IComparable
        {
            int i = left; 
            int j = right;
            T pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(arr, left, j);
            }

            if (i < right)
            {
                QuickSort(arr, i, right);
            }
        }

        private static string ListElementsToString(List<string> list) 
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i] + ' ');
            }

            return sb.ToString().Trim();
        }
       

        public static string SortWords(string input) 
        {
            List<string> listOfWords = SplitWords(input);
            QuickSort(listOfWords, 0, listOfWords.Count - 1);
            return ListElementsToString(listOfWords);
        }
    }
}
