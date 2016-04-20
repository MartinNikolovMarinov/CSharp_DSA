namespace Sortable_Collection
{
    using System;
    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 100;
            const int MaxNumber = 999;
            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Util.rnd.Next(MaxNumber);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter() { Max = MaxNumber });

            Console.WriteLine(collectionToSort);
        }
    }
}
