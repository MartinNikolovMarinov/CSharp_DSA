namespace _07.LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public QueueNode(T data, QueueNode<T> NextNode = null, QueueNode<T> PrevNode = null)
            {
                this.Data = data;
                this.NextNode = NextNode;
                this.PrevNode = PrevNode;
            }

            public T Data { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }
        }


        private int count;
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public LinkedQueue()
        {
            this.count = 0;
            this.head = null;
            this.tail = null;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Enqueue(T value)
        {
            QueueNode<T> newNode = new QueueNode<T>(value);
            this.count++;

            if (this.head == null)
            {
                this.head = newNode;
                return;
            }

            if (this.tail == null)
            {
                this.tail = newNode;
                this.tail.PrevNode = this.head;
                this.head.NextNode = this.tail;
                return;
            }

            this.tail.NextNode = newNode;
            newNode.PrevNode = this.tail;
            this.tail = newNode;
        }

        public T Dequeue()
        {
            if (this.head == null && this.tail == null)
                throw new IndexOutOfRangeException("Nothing to dequeue.");

            T result;

            if (this.tail == null && this.Count == 1)
            {
                result = this.head.Data;
                this.head = null;
                this.count--;
                return result;
            }
            else if (this.Count == 2)
            {
                result = this.head.Data;
                this.head = this.head.NextNode;
                this.head.PrevNode = null;
                this.tail = null;
                this.count--;
                return result;
            }
            else
            {
                result = this.head.Data;
                this.head = this.head.NextNode;
                this.head.PrevNode = null;
                this.count--;
                return result;
            }
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];
            QueueNode<T> currentNode = this.head;

            for (int i = 0; i < this.count; i++)
            {
                result[i] = currentNode.Data;
                currentNode = currentNode.NextNode;
            }

            return result;
        }
    }
}
