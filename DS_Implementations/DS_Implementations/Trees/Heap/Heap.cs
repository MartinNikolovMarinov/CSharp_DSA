namespace DS_Implementations.Trees.Heap
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    public class Heap<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        protected T[] heap;
        public int Count { get; set; }

        public Heap(int capacity = 8) 
        {
            this.heap = new T[capacity];
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

        protected void ResizeHeap()
        {
            T[] newHeap = new T[this.heap.Length * 2];
            Array.Copy(this.heap, newHeap, this.Count);
            this.heap = newHeap;
        }
    }
}
