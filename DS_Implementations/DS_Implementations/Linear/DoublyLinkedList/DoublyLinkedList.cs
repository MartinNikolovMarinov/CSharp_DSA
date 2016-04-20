namespace DS_Implementations.Linear.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T val)
            {
                this.Value = val;
                this.Next = null;
                this.Prev = null;
            }

            public override string ToString()
            {
                return this.Value.ToString();
            }
        }

        // Fields :
        private Node head;
        private Node tail;

        // Properties :
        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }
        public Node First { get { return this.head; } }
        public Node Last { get { return this.tail; } }

        public DoublyLinkedList() 
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        // Methods :
        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else if (this.Count == 1)
            {
                this.head.Next = newNode;
                newNode.Prev = this.head;
                this.tail = newNode;
            } 
            else
            {
                this.tail.Next = newNode;
                newNode.Prev = this.tail;
                this.tail = newNode;
            }

            this.Count++;
        }

        public void AddFirst(T item)
        {
            var newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else if (this.Count == 1)
            {
                this.head.Prev = newNode;
                newNode.Next = this.head;
                this.tail = this.head;
                this.head = newNode;

            }
            else
            {
                newNode.Next = this.head;
                newNode.Next.Prev = newNode;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddAfter(Node node, T value)
        {
            var newNode = new Node(value);

            if (node.Next == null)
            {
                node.Next = newNode;
            }
            else
            {
                newNode.Next = node.Next;
                node.Next = newNode;
            }

            this.Count++;
        }

        public void AddBefore(Node node, T value)
        {
            var newNode = new Node(value);

            if (node.Prev == null)
            {
                node.Prev = newNode;
            }
            else
            {
                newNode.Prev = node.Prev;
                node.Prev = newNode;
            }

            this.Count++;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var elem in this)
            {
                if (elem.Equals(item))
                    return true;
            }

            return false;
        }

        public bool Remove(T item)
        {
            bool deleted = false;

            if (this.Count == 1)
            {
                if (this.head.Value.Equals(item))
                {
                    this.Clear();
                    deleted = true;
                }
            }
            else if (this.Count == 2)
            {
                if (this.head.Value.Equals(item))
                {
                    this.head = this.tail;
                    this.head.Prev = null;
                    deleted = true;
                }
                else if (this.tail.Value.Equals(item))
                {
                    this.tail = this.head;
                    this.head.Next = null;
                    deleted = true;
                }
            }
            else if (this.Count > 2)
            {
                foreach (var node in this.EnumarateNodes())
                {
                    if (node.Value.Equals(item))
                    {
                        var next = node.Next;
                        var prev = node.Prev;

                        if (next != null)
                            next.Prev = prev;
                        else
                            this.tail = prev;

                        if (prev != null)
                            prev.Next = next;
                        else
                            this.head = next;
                        
                        deleted = true;
                        break;
                    }    
                }
            }

            if (deleted)
                this.Count--;

            return deleted;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = 0;
            foreach (var elem in this)
            {
                array[arrayIndex + i] = elem;
                i++;
            }
        }

        public Node GetNodeAt(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException();

            int i = -1;
            foreach (var elem in this.EnumarateNodes())
            {
                if (++i == index)
                    return elem;
            }

            throw new KeyNotFoundException();
        }

        public Node this[int key] 
        {
            get { return this.GetNodeAt(key); } 
        }

        public IEnumerable<Node> EnumarateNodes()
        {
            Node curr = this.head;
            while (curr != null)
            {
                yield return curr;
                curr = curr.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node curr = this.head;
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

#if DEBUG
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var elem in this)
            {
                sb.AppendFormat("{0}, ", elem);
            }

            return sb.ToString();
        }
#endif
    }
}
