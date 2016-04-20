namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; set; }

        public int Count { get { return this.Items.Count; } }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return BinarySearch(item, 0, this.Items.Count - 1);
        }

        private int BinarySearch(T item, int start, int end)
        {
            if (end < start)
                return -1;

            int mid = (start + end) / 2;

            if (this.Items[mid].CompareTo(item) > 0)
                return BinarySearch(item, start, mid - 1);    
            else if (this.Items[mid].CompareTo(item) < 0)
                return BinarySearch(item, mid + 1, end);
            else
                return mid;
        }

        // I have no idea how this should work with generics ...
        public int InterpolationSearch(int item)
        {
            List<int> items = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                items.Add(Convert.ToInt32(this.Items[i]));
            }
            int start = 0;
            int end = this.Count - 1;
            if (start > end)
            {
                return -1;
            }

            while (items[start] <= item && items[end] >= item)
            {
                int mid = start + (((item - items[start]) * (end - start)) / (items[end] - items[start]));
                if (items[mid] > item)
                {
                    end = mid - 1;
                }
                else if (items[mid] < item)
                {
                    start = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public void Shuffle()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                int rndIndex = i + Util.rnd.Next(0, this.Items.Count - i);
                T tmp = this.Items[i];
                this.Items[i] = this.Items[rndIndex];
                this.Items[rndIndex] = tmp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }        
    }
}