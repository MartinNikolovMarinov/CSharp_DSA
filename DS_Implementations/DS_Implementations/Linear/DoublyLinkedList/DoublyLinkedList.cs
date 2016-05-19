namespace DS_Implementations.Linear.DoublyLinkedList
{
    using System;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class Node<K>
        {
            public Node(K val)
            {
                this.Value = val;
                this.Next = null;
                this.Prev = null;
            }

            public K Value { get; set; }
            public Node<K> Next { get; set; }
            public Node<K> Prev { get; set; }

            public override string ToString()
            {
                return string.Format("{0}", this.Value);
            }
        }

        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var node = new Node<T>(element);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                var prev = head;
                head = node;
                head.Next = prev;
                if (head.Next == tail)
                    tail.Prev = head;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            var node = new Node<T>(element);
            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                if (head == tail)
                    head.Next = node;
                var prev = tail;
                tail.Next = node;
                tail = node;
                tail.Prev = prev;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements in List.");

            Count--;
            var elem = head.Value;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
                if (head.Prev != null)
                    head.Prev = null;
            }

            return elem;
        }

        public T RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException("No elements in List.");

            Count--;
            var elem = tail.Value;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.Prev;
                if (tail.Next != null)
                    tail.Next = null;
            }

            return elem;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var item in this)
            {
                action(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curr = head;
            while (curr != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            int i = 0;
            foreach (var item in this)
            {
                arr[i++] = item;
            }

            return arr;
        }

#if DEBUG
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var elem in this)
            {
                sb.AppendFormat("{0}, ", elem);
            }

            return sb.ToString();
        }
#endif
    }
}
