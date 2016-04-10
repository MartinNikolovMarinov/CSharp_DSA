namespace AvlTreeLab
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AvlTree<T> where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public AvlTree()
        {
            this.root = null;
            this.Count = 0;
        }

        #region Add Functionality
        
        public void Add(T item)
        {
            bool inserted = true;
            if (this.root == null)
                this.root = new Node<T>(item);
            else
                inserted = this.InternalInsert(this.root, item);

            if (inserted)
                this.Count++;
        }

        private bool InternalInsert(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            bool shouldRetrace = false;

            while (true)
            {
                currentNode.Count++;
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.BalancedFactor--;
                        shouldRetrace = currentNode.BalancedFactor != 0;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        currentNode.BalancedFactor++;
                        shouldRetrace = currentNode.BalancedFactor != 0;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return false;
                }
            }

            if (shouldRetrace)
                this.RetraceInsert(currentNode);

            return true;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BalancedFactor == 1)
                    {
                        parent.BalancedFactor++;
                        if (node.BalancedFactor == -1)
                            this.RotateLeft(node);

                        this.RotateRight(parent);
                        break;
                    }
                    else if (parent.BalancedFactor == -1)
                    {
                        parent.BalancedFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalancedFactor = 1;
                    }
                }
                else
                {
                    if (parent.BalancedFactor == -1)
                    {
                        parent.BalancedFactor--;
                        if (node.BalancedFactor == 1)
                            this.RotateRight(node);

                        this.RotateLeft(parent);
                        break;
                    }
                    else if (parent.BalancedFactor == 1)
                    {
                        parent.BalancedFactor = 0;
                        break;
                    }
                    else
                    {
                        parent.BalancedFactor = -1;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                    parent.LeftChild = child;
                else
                    parent.RightChild = child;
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            // Modify count according.
            node.Count = ( node.LeftChild != null ? node.LeftChild.Count : 0 ) +
                ( node.RightChild != null ? node.RightChild.Count : 0 ) + 1;
            child.Count = ( child.LeftChild != null ? child.LeftChild.Count : 0 ) +
                ( child.RightChild != null ? child.RightChild.Count : 0 ) + 1;

            // Modify balance.
            node.BalancedFactor += 1 - Math.Min(child.BalancedFactor, 0);
            child.BalancedFactor += 1 + Math.Max(node.BalancedFactor, 0);
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                    parent.LeftChild = child;
                else
                    parent.RightChild = child;
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.LeftChild = child.RightChild;
            child.RightChild = node;

            // Modify count according.
            node.Count = ( node.LeftChild != null ? node.LeftChild.Count : 0 ) +
                ( node.RightChild != null ? node.RightChild.Count : 0 ) + 1;
            child.Count = (child.LeftChild != null ? child.LeftChild.Count : 0 ) +
                ( child.RightChild != null ? child.RightChild.Count : 0 ) + 1;
            
            // Modify balance.
            node.BalancedFactor -= 1 + Math.Max(child.BalancedFactor, 0);
            child.BalancedFactor -= 1 - Math.Min(node.BalancedFactor, 0);
        }

        #endregion

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
                return;
            else
                InOrderDfs(this.root, 1, action);
        }

        public bool Contains(T item)
        {
            var node = this.root;
            while (node != null)
            {
                if (node.Value.CompareTo(item) < 0)
                    node = node.RightChild;
                else if (node.Value.CompareTo(item) > 0)
                    node = node.LeftChild;
                else
                    return true;
            }

            return false;
        }

        public List<T> Range(T from, T to)
        {
            var node = this.root;
            List<T> result = new List<T>();
            InternalRange(this.root, result, from, to);
            return result;
        }

        public T this[int index]
        {
            get
            {
                return this.IndexOf(index);
            }
        }

        public T IndexOf(int i)
        {
            if (i < 0 || i >= this.Count)
                throw new ArgumentOutOfRangeException("Invalid index.");
            else 
                return InternalIndexOf(i);
        }

        private T InternalIndexOf(int i)
        {
            var node = this.root;
            int leftSubTreeCount = 0;

            while (true)
            {
                leftSubTreeCount = 0;
                if (node.LeftChild != null)
                    leftSubTreeCount = node.LeftChild.Count;

                if (i == leftSubTreeCount)
                    return node.Value;

                if (i <= leftSubTreeCount)
                {
                    node = node.LeftChild;
                    continue;
                }

                if (i > leftSubTreeCount)
                {
                    i -= leftSubTreeCount + 1;
                    node = node.RightChild;
                }
            }
        }

        private static void InternalRange(Node<T> node, List<T> result, T from, T to)
        {
            if (node.LeftChild != null && node.LeftChild.Value.CompareTo(from) >= 0)
                InternalRange(node.LeftChild, result, from, to);

            if (node.Value.CompareTo(from) >= 0 && node.Value.CompareTo(to) <= 0)
                result.Add(node.Value);

            if (node.RightChild != null && node.RightChild.Value.CompareTo(from) >= 0)
                InternalRange(node.RightChild, result, from, to);
        }


        private static void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
                InOrderDfs(node.LeftChild, depth + 1, action);

            action(depth, node.Value);
            if (node.RightChild != null)
                InOrderDfs(node.RightChild, depth + 1, action);
        }

#if DEBUG
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.ForeachDfs((depth, val) => sb.AppendFormat("{0} ", val));
            return sb.ToString();
        }
#endif
    }
}