namespace DS_Implementations.Trees.Heap
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

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
}
