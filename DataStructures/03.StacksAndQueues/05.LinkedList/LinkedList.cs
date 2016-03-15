namespace _05.LinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedStack<T>
    {
        public class Node<T>
        {
            public T Data { get; set; }

            public Node<T> Next { get; set; }

            public Node(T data, Node<T> nextNode = null)
            {
                this.Data = data;
                this.Next = nextNode;
            }

            public override string ToString()
            {
                return this.Data.ToString();
            }
        }

        private Node<T> root;
        private int count;

        public LinkedStack()
        {
            this.count = 0;
            this.root = null;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Push(T value)
        {
            this.root = new Node<T>(value, this.root);
            this.count++;
        }

        public T Pop()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException("Can't pop from empty stack.");
            }

            T data = this.root.Data;
            this.root = this.root.Next;
            this.count--;
            return data;
        }

        public T Peek()
        {
            return this.root.Data;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];
            Node<T> currentElement = this.root;

            for (int i = 0; i < this.count; i++)
            {
                result[i] = currentElement.Data;
                currentElement = currentElement.Next;
            }

            return result;
        }
    }
}