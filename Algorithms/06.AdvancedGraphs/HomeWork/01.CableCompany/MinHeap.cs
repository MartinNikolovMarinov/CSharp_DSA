namespace _01.CableCompany
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    public static class Global
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    public class Heap<T> : IEnumerable<T> where T : IComparable<T>
    {
        private static readonly int DefaultCapacity = 8;

        protected T[] heap;
        public int Count { get; set; }

        public Heap()
        {
            this.heap = new T[DefaultCapacity];
        }

        protected void ResizeHeap()
        {
            T[] newHeap = new T[this.heap.Length * 2];
            Array.Copy(this.heap, newHeap, this.Count);
            this.heap = newHeap;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.heap[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            int counter = 0;
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
            {
                if (counter == this.Count - 1)
                    sb.AppendFormat("{0}", item);
                else
                    sb.AppendFormat("{0}, ", item);

                counter++;
            }

            return sb.ToString();
        }

        #region Sort

        public T[] Sort()
        {
            int end = this.Count - 1;
            T[] arr = new T[this.Count];
            Array.Copy(this.heap, arr, this.Count);

            while (end > 0)
            {
                Global.Swap(ref arr[end], ref arr[0]);
                end--;
                siftDown(arr, 0, end);
            }

            if (arr.Length > 2 && arr[0].CompareTo(arr[1]) > 0)
            {
                Global.Swap(ref arr[0], ref arr[1]);
            }

            return arr;
        }

        private void siftDown(T[] arr, int start, int end)
        {
            int root = start;
            while ((root + 1) * 2 <= end)
            {
                int leftChild = (root + 1) * 2 - 1;
                int rightChild = (root + 1) * 2;
                int swapIndex = root;

                if (arr[swapIndex].CompareTo(arr[leftChild]) < 0)
                {
                    swapIndex = leftChild;
                }
                if (rightChild <= end && arr[swapIndex].CompareTo(arr[rightChild]) < 0)
                {
                    swapIndex = rightChild;
                }
                if (swapIndex == root)
                {
                    return;
                }
                else
                {
                    Global.Swap(ref arr[root], ref arr[swapIndex]);
                    root = swapIndex;
                }
            }
        }

        #endregion
    }

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
