namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable
    {
        private OrderedSetNode<T> root;

        public int Count { get; private set; }

        
        public OrderedSet() 
        {
            this.root = null;
            this.Count = 0;
        }

        public void Add(T element)
        {
            if (root == null)
            {
                root = new OrderedSetNode<T>(element);
                this.Count++;
            }
            else
            {
                OrderedSetNode<T> prevNode = null;
                OrderedSetNode<T> currentNode = this.root;
                bool done = false;
                while (!done)
                {
                    prevNode = currentNode;

                    if (currentNode.Value.CompareTo(element) > 0)
                    {
                        currentNode = currentNode.LeftChild;
                        if (currentNode == null)
                        {
                            done = true;
                            var newNode = new OrderedSetNode<T>(element);
                            newNode.Parent = prevNode;
                            prevNode.LeftChild = newNode;
                        }
                    }
                    else if (currentNode.Value.CompareTo(element) < 0)
                    {
                        currentNode = currentNode.RightChild;
                        if (currentNode == null)
                        {
                            done = true;
                            var newNode = new OrderedSetNode<T>(element);
                            newNode.Parent = prevNode;
                            prevNode.RightChild = newNode;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Element already exists in set.");
                    }
                }

                this.Count++;
            }
        }

        public OrderedSetNode<T> FindElement(T element)
        {
            if (this.root == null)
            {
                return null;
            }

            var currentNode = this.root;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(element) > 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(element) < 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    break;
                }
            }

            return currentNode;
        }

        public bool Contains(T element) 
        {
            var node = this.FindElement(element);
            return node != null;
        }

        public void Clear() 
        {
            this.root = null;
            this.Count = 0;
        }

        private void RemoveLeaf(OrderedSetNode<T> node) 
        {
            var parent = node.Parent;

            if (parent == null)
            {
                // node is root
                this.root = null;
            }
            else if (parent.LeftChild != null && parent.LeftChild.Value.Equals(node.Value))
            {
                parent.LeftChild = null;
            }
            else if (parent.RightChild != null && parent.RightChild.Value.Equals(node.Value))
            {
                parent.RightChild = null;
            }
            else
            {
                throw new ArgumentException("Internal Tree error.");
            }
        }

        private void RemoveInternalNode(OrderedSetNode<T> node) 
        {
            if (node.Children.Count == 1)
            {
                if (node.LeftChild != null)
                {
                    node.LeftChild.Parent = node.Parent;
                    OrderedSetNode<T>.CopyNode(node.LeftChild, ref node);
                }
                else 
                {
                    node.RightChild.Parent = node.Parent;
                    OrderedSetNode<T>.CopyNode(node.RightChild, ref node);
                }

                return;
            }
            else 
            {
                var leftMostNodeOnTheRight = node.RightChild;
                var leftNode = node.LeftChild;
                while (leftMostNodeOnTheRight.LeftChild != null)
                {
                    leftMostNodeOnTheRight = leftMostNodeOnTheRight.LeftChild;
                }

                node.RightChild.Parent = node.Parent;
                OrderedSetNode<T>.CopyNode(node.RightChild, ref node);

                if (node.Value.Equals(leftMostNodeOnTheRight.Value))
                {
                    leftNode.Parent = node;
                    node.LeftChild = leftNode;
                }
                else 
                {
                    leftNode.Parent = leftMostNodeOnTheRight;
                    leftMostNodeOnTheRight.LeftChild = leftNode;
                }
            }
        }

        public void Remove(T element)
        {
            var node = this.FindElement(element);

            if (node == null)
            {
                throw new ArgumentException("Elements doesn't exists.");
            }
            
            if (node.Children.Count == 0)
            {
                RemoveLeaf(node);
            }
            else 
            {
                RemoveInternalNode(node);
            }

            this.Count--;
        }

        /// <summary>
        /// Traverse The tree in-order and save it's values in a list structure.
        /// </summary>
        /// <param name="node">Current node of the tree.</param>
        /// <param name="list">Save all values in this variable.</param>
        private void TraverseInOrder(OrderedSetNode<T> node, List<T> list) 
        {
            if (node.LeftChild != null)
            {
                this.TraverseInOrder(node.LeftChild, list);
            }

            list.Add(node.Value);

            if (node.RightChild != null)
            {
                this.TraverseInOrder(node.RightChild, list);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> list = new List<T>();
            if (this.Count > 0)
            {
                this.TraverseInOrder(this.root, list);
            }

            return list.GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T[] ToArray() 
        {
            T[] arr = new T[this.Count];
            int counter = 0;

            foreach (var element in this)
            {
                arr[counter] = element;
                counter++;
            }

            return arr;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in this)
            {
                sb.AppendFormat("{0} ", element.ToString());
            }

            return sb.ToString();
        }
    }
}
