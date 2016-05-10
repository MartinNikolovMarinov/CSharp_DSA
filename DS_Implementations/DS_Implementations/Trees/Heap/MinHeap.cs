namespace DS_Implementations.Trees.Heap
{
    using DS_Implementations;
    using System;

    public class MinHeap<T> : Heap<T> where T : IComparable<T>
    {
        public void Insert(T value)
        {
            if (this.Count + 1 >= heap.Length)
                this.ResizeHeap();

            if (this.Count == 0)
            {
                this.heap[0] = value;
                this.Count++;
                return;
            }

            int i = this.Count;
            this.heap[this.Count] = value;
            while (value.CompareTo(heap[(i - 1) / 2]) < 0)
            {
                Global.Swap(ref this.heap[i], ref this.heap[(i - 1) / 2]);
                i = (i - 1) / 2;
            }

            this.Count++;
        }

        public T GetMin()
        {
            if (this.Count == 0)
                throw new ArgumentOutOfRangeException();

            T min = this.heap[0];
            this.heap[0] = this.heap[this.Count - 1];
            this.Count--;
            MinHeapify(0);
            return min;
        }

        private void MinHeapify(int i)
        {
            int smallest = i;
            int left = (i + 1) * 2 - 1;
            int right = (i + 1) * 2;

            if (right >= this.Count)
                return;
            if (left <= heap.Length && heap[left].CompareTo(heap[i]) < 0)
                smallest = left;
            if (right <= heap.Length && heap[right].CompareTo(heap[smallest]) < 0)
                smallest = right;

            if (smallest != i)
            {
                Global.Swap(ref heap[i], ref heap[smallest]);
                MinHeapify(smallest);
            }
        }
    }
}
