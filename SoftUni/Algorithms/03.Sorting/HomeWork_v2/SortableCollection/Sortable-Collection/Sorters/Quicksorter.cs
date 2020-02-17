namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public enum PivotType { NotSet, Rnd, Hi, Low }
        public PivotType QuickSortPivotType = PivotType.Hi;
        private static Random rnd = new Random();

        public void Sort(List<T> collection)
        {
             QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> collection, int low, int hi)
        {
            if (low < hi)
            {
                int pivot = ChoosePivot(low, hi);
                pivot = Partition(collection, low, hi, pivot);
                QuickSort(collection, low, pivot);
                QuickSort(collection, pivot + 1, hi);
            }
        }

        private int ChoosePivot(int low, int hi)
        {
            switch (QuickSortPivotType)
            {
                case PivotType.Rnd:
                    return rnd.Next(low, hi - 1);
                case PivotType.Hi:
                    return hi - 1;
                case PivotType.Low:
                    return low;
                default:
                    return hi - 1;
            }
        }

        private int Partition(List<T> collection, int low, int hi, int pivot)
        {
            T elemAtPivot = collection[pivot];
            int i = low - 1;
            int j = hi + 1;

            while (true)
            {
                do
                {
                    j--;
                } while (collection[j].CompareTo(elemAtPivot) > 0);

                do
                {
                    i++;
                } while (collection[i].CompareTo(elemAtPivot) < 0);

                if (i < j)
                    Util.Swap(collection, i, j);
                else
                    return j;
            }
        }
    }
}
