namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            Split(collection, 0, collection.Count);
        }

        private void Split(List<T> collection, int low, int hi)
        {
            if (hi - low <= 1)
                return;

            int mid = (hi + low) / 2;
            Split(collection, low, mid); // split step
            Split(collection, mid, hi);
            T[] merged = Merge(collection, low, mid, hi); // merge step
            Util.CopyArrToList(merged, 0, collection, low, merged.Length);
        }

        private T[] Merge(List<T> arr, int low, int mid, int hi)
        {
            T[] result = new T[hi - low];
            int low_i = 0;
            int hi_i = 0;

            for (int i = 0; i < result.Length; i++)
            {
                T first, second;

                if (mid + hi_i >= hi)
                {
                    // done with the right part.
                    first = arr[low + low_i];
                    result[i] = first;
                    low_i++;
                    continue;
                }
                else
                {
                    second = arr[mid + hi_i];
                }

                if (low + low_i >= mid)
                {
                    // done with the left part.
                    second = arr[mid + hi_i];
                    result[i] = second;
                    hi_i++;
                    continue;
                }
                else
                {
                    first = arr[low + low_i];
                }


                if (first.CompareTo(second) <= 0)
                {
                    result[i] = first;
                    low_i++;
                }
                else
                {
                    result[i] = second;
                    hi_i++;
                }
            }

            return result;
        }
    }
}
