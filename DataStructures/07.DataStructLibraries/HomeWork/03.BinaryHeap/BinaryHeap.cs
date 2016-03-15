namespace _03.BinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryHeap<T> : IEnumerable<T>
        where T : IComparable
    {
        private const int DefaultCapacity = 5;
        private T[] heap;

        public int Count { get; set; }

        public BinaryHeap()
        {
            heap = new T[DefaultCapacity];
            Count = 0;
        }

        public void Add(T item)
        {
            if (Count == heap.Length - 1)
            {
                T[] newHeap = new T[Count * 2];
                Array.Copy(heap, newHeap, Count);
                heap = newHeap;
            }

            int pos = Count;
            T parent = heap[pos / 2];
            Count++;
            while (pos >= 1 && item.CompareTo(parent) < 0)
            {
                heap[pos] = heap[pos / 2];
                pos = pos / 2;
                parent = heap[pos / 2];
            }

            heap[pos] = item;
        }

        public void Clear()
        {
            heap = new T[DefaultCapacity];
            Count = 0;
        }

        public T RemoveMax()
        {
            T result = heap[Count - 1];
            Count--;
            return result;
        }

        public T GetMax() 
        {
            return heap[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return heap[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #if DEBUG

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in heap)
            {
                sb.AppendFormat("{0} ", element);
            }

            return sb.ToString();
        }

        #endif
    }
}
