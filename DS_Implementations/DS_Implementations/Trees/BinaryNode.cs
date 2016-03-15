namespace DS_Implementations.Trees
{
    using System;

    public class BinaryNode<TValue> where TValue : IComparable<TValue>
    {
        public TValue Value { get; set; }
        public int Level { get; set; }
        public BinaryNode<TValue> Parent { get; set; }
        public BinaryNode<TValue> Left { get; set; }
        public BinaryNode<TValue> Right { get; set; }

        public BinaryNode()
        {
            this.Parent = null;
            this.Left = null;
            this.Right = null;
            this.Level = 0;
        }
        public BinaryNode(TValue value)
            : this()
        {
            this.Value = value;
        }

        public bool HasChildren() 
        {
            return Left != null || Right != null;
        }

        #region Traverse
        public void Traverse(Action<BinaryNode<TValue>> action, TraverseOption option = TraverseOption.InOrder)
        {
            if (option == TraverseOption.InOrder)
                this.TraverseInOrder(this, action);
            else if (option == TraverseOption.PostOrder)
                this.TraversePostOrder(this, action);
            else
                this.TraversePreOrder(this, action);
        }

        private void TraversePreOrder(BinaryNode<TValue> currNode, Action<BinaryNode<TValue>> action)
        {
            action(currNode);

            if (currNode.Left != null)
                TraversePreOrder(currNode.Left, action);
            if (currNode.Right != null)
                TraversePreOrder(currNode.Right, action);
        }

        private void TraverseInOrder(BinaryNode<TValue> currNode, Action<BinaryNode<TValue>> action)
        {
            if (currNode.Left != null)
                TraverseInOrder(currNode.Left, action);

            action(currNode);

            if (currNode.Right != null)
                TraverseInOrder(currNode.Right, action);
        }

        private void TraversePostOrder(BinaryNode<TValue> currNode, Action<BinaryNode<TValue>> action)
        {
            if (currNode.Left != null)
                TraversePostOrder(currNode.Left, action);
            if (currNode.Right != null)
                TraversePostOrder(currNode.Right, action);

            action(currNode);
        }
        #endregion

#if DEBUG
        public void PrintNode()
        {
            var children = new BinaryNode<TValue>[] { this.Left, this.Right };
            this.PrintNode("", true, children);
        }

        private void PrintNode(String prefix, bool isTail, BinaryNode<TValue>[] children)
        {
            const string defaultSpace = "    ";
            const string tailEnding = "└──>";
            const string midEnding = "├──>";
            const string childSpace = "│   ";

            if (prefix == String.Empty)
            {
                Console.WriteLine(defaultSpace + this.Value + " L:" + this.Level);
            }
            else
            {
                Console.WriteLine(prefix + (isTail ? tailEnding : midEnding) + this.Value + " L:" + this.Level);
            }

            if (children[0] == null && children[1] == null)
            {
                return;
            }

            int i = 0;
            foreach (var child in children)
            {
                if (child == null)
                {
                    continue;
                }

                bool tailCheck = i == children.Length - 1;
                var currChildren = new BinaryNode<TValue>[] { child.Left, child.Right };
                child.PrintNode(prefix + (isTail ? defaultSpace : childSpace), tailCheck, currChildren);
                i++;
            }
        }
#endif
        public override string ToString()
        {
            return string.Format("{0}", this.Value, this.Level);
        }

        public static void DeepCopyNode(BinaryNode<TValue> source, ref BinaryNode<TValue> dest)
        {
            dest.Value = source.Value;
            dest.Parent = source.Parent;
            dest.Left = source.Left;
            dest.Right = source.Right;
        }

        public static BinaryNode<TValue> FindSuccessor(BinaryNode<TValue> node)
        {
            if (node == null)
                return null;

            if (node.Right != null)
                return FindMinimum(node.Right);

            var y = node.Parent;
            var x = node;
            while (y != null && x == y.Right)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }

        public static BinaryNode<TValue> FindPredecessor(BinaryNode<TValue> node)
        {
            if (node == null)
                return null;

            if (node.Left != null)
                return FindMaximum(node.Left);

            var parent = node.Parent;
            var y = parent;
            var x = node;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }

        public static BinaryNode<TValue> FindMinimum(BinaryNode<TValue> node)
        {
            if (node == null)
                return null;

            if (node.Left != null)
                return FindMinimum(node.Left);

            return node;
        }

        public static BinaryNode<TValue> FindMaximum(BinaryNode<TValue> node)
        {
            if (node == null)
                return null;

            if (node.Right != null)
                return FindMaximum(node.Right);

            return node;
        }
    }
}
