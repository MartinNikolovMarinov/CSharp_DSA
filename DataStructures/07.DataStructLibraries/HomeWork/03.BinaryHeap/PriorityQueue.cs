namespace _03.BinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable
    {
        BinaryHeap<T> heap;

        public PriorityQueue() 
        {
            heap = new BinaryHeap<T>();
        }

        public void Enqueue(T item) 
        {
            this.heap.Add(item);
        }

        public T Dequeue()
        {
            return this.heap.RemoveMax();
        }

        public T Peek()
        {
            return this.heap.GetMax();
        }
        
        #if DEBUG

        public override string ToString()
        {
            return heap.ToString();
        }

        #endif
    }
}
