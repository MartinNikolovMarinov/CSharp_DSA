namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            Heapify(collection);
            int end = collection.Count - 1;
            while (end > 0)
            {
                Util.Swap(collection, end, 0);
                end--;
                SiftDown(collection, 0, end);
            }
        }

        private void Heapify(List<T> collection)
        {
            int start = ((collection.Count - 2) / 2);
            while (start >= 0)
            {
                SiftDown(collection, start, collection.Count - 1);
                start--;
            }
        }

        private void SiftDown(List<T> collection, int start, int end)
        {
            int root = start;
            while (root * 2 + 1 <= end)
            {
                int child = root * 2 + 1;
                int swap_i = root;
                if (collection[swap_i].CompareTo(collection[child]) < 0)
                    swap_i = child;
                if (child + 1 <= end && collection[swap_i].CompareTo(collection[child + 1]) < 0)
                    swap_i = child + 1;
                if (swap_i == root)
                    return;
                else
                {
                    Util.Swap(collection, root, swap_i);
                    root = swap_i;
                }
            }
        }
    }
}
