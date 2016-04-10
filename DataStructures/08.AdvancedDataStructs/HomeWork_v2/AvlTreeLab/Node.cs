namespace AvlTreeLab
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild; 

        public Node(T value)
        {
            this.Value = value;
            this.Count = 1;
        }

        // Fields :
        public T Value { get; set; }
        public int BalancedFactor { get; set; }
        public int Count { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild
        {
            get { return this.leftChild; }
            set
            {
                if (value != null)
                    value.Parent = this;

                this.leftChild = value;
            }
        }
        public Node<T> RightChild
        {
            get { return this.rightChild; }
            set
            {
                if (value != null)
                    value.Parent = this;

                this.rightChild = value;
            }
        }
        public bool IsLeftChild
        {
            get
            {
                return this.Parent != null && this.Equals(Parent.leftChild);
            }
        }
        public bool IsRightChild
        {
            get
            {
                return this.Parent != null && this.Equals(Parent.rightChild);
            }
        }

        // Method :
        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Node<T>)
                return base.Equals(obj);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

