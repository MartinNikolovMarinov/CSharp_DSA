namespace _02.RoundDance
{
    using System;
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
            this.Visited = false;
        }

        public T Value { get; set; }
        public bool Visited { get; set; }
        public List<Node<T>> Children { get; private set; }

        public void AddChild(Node<T> child)
        {
            if (child == null)
                throw new ArgumentException("Can't add null children.");
            else 
                this.Children.Add(child);
        }

        public bool HasNoChildren()
        {
            return this.Children.Count == 0;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
