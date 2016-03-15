namespace DS_Implementations.Trees.AVLTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using DS_Implementations.Trees;

    public class AVLTree<TValue> : ICollection<TValue> 
        where TValue : IComparable<TValue>
    {
        private enum RotationType
        {
            LeftLeft,
            RightRight,
            LeftRight,
            RightLeft
        }

        private bool ElementFound = false;
        public BinaryNode<TValue> Root { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }

        public AVLTree() 
        {
            this.Clear();
        }

        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        public void Add(TValue item)
        {
            this.Count++;
            if (this.Root == null)
            {
                this.Root = new BinaryNode<TValue>(item);
            }
            else 
            {
               this.Root = Add(item, this.Root);
            }
        }

        public void Add(IEnumerable<TValue> items) 
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        private BinaryNode<TValue> Add(TValue item, BinaryNode<TValue> currNode, int lastDir = 0)
        {
            if (currNode == null)
            {
                var newNode = new BinaryNode<TValue>(item);
                return newNode;
            }
            else if (currNode.Value.CompareTo(item) > 0)
            {
                currNode.Left = Add(item, currNode.Left, 0);
                currNode.Left.Parent = currNode;
            }
            else if (currNode.Value.CompareTo(item) < 0)
            {
                currNode.Right = Add(item, currNode.Right, 1);
                currNode.Right.Parent = currNode;
            }
            else
            {
                throw new ArgumentException(item + " already exists in the tree.");
            }

            currNode.Level = DeepestNodeLevel(currNode.Left, currNode.Right) + 1;
            if (IsImbalanced(currNode.Left, currNode.Right))
            {
                currNode = RebalanceSubTree(currNode, lastDir);
            }

            return currNode;
        }

        public bool Contains(TValue item)
        {
            var node = this.Root;
            while (node != null)
            {
                if (item.CompareTo(node.Value) > 0)
                    node = node.Right;
                else if (item.CompareTo(node.Value) < 0)
                    node = node.Left;
                else
                    return true;
            }

            return false;
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentException("arrayIndex variable can't be negative.");
            }

            int counter = arrayIndex;
            Traverse(node =>
            {
                array[counter] = node.Value;
                counter++;
            });
        }

        public bool Remove(TValue item)
        {
            this.ElementFound = false;
            this.Root = Remove(item, this.Root);

            if (ElementFound)
            {
                this.Count--;
                return true;                
            }
            else 
            {
                return false;
            }
        }

        private BinaryNode<TValue> Remove(TValue item, BinaryNode<TValue> currNode, int lastDir = 0)
        {
            if (currNode == null)
            {
                return null;
            }
            else if (currNode.Value.CompareTo(item) > 0)
            {
                currNode.Left = Remove(item, currNode.Left, 0);
            }
            else if (currNode.Value.CompareTo(item) < 0)
            {
                currNode.Right = Remove(item, currNode.Right, 1);
            }
            else
            {
                bool LeftChildOnly = currNode.Left != null && currNode.Right == null;
                bool RightChildOnly = currNode.Left == null && currNode.Right != null;

                if (ElementFound == false)
                {
                    ElementFound = true;
                }

                if (!currNode.HasChildren())
                {
                    return null;
                }
                else if (LeftChildOnly)
                {
                    if (currNode.Parent != null)
                    {
                        currNode.Left.Parent = currNode.Parent;
                        if (lastDir == 0)
                            currNode.Parent.Left = currNode.Left;
                        else
                            currNode.Parent.Right = currNode.Left;
                    }
                    else 
                    {
                        currNode.Left.Parent = null;
                    }

                    return currNode.Left;
                }
                else if (RightChildOnly)
                {
                    if (currNode.Parent != null)
                    {
                        currNode.Right.Parent = currNode.Parent;
                        if (lastDir == 0)
                            currNode.Parent.Left = currNode.Right;
                        else
                           currNode.Parent.Right = currNode.Right;
                    }
                    else
                    {
                        currNode.Right.Parent = null;
                    }
                
                    return currNode.Right;
                }
                else 
                {
                    var predessesor = BinaryNode<TValue>.FindPredecessor(currNode);
                    if (predessesor.Left != null || !predessesor.HasChildren())
                    {
                        var temp = currNode.Value;
                        currNode.Value = predessesor.Value;
                        predessesor.Value = temp;
                        currNode.Left = Remove(item, currNode.Left, 0);
                    }
                    else 
                    {
                        throw new ArgumentException("Internal tree error.");
                    }
                }
            }

            currNode.Level = DeepestNodeLevel(currNode.Left, currNode.Right) + 1;
            if (IsImbalanced(currNode.Left, currNode.Right))
            {
                currNode = RebalanceSubTree(currNode, lastDir);
            }

            return currNode;
        }


        public IEnumerator<TValue> GetEnumerator()
        {
            var arr = new TValue[this.Count];
            int counter = 0;
            this.Traverse(node =>
            {
                arr[counter] = node.Value;
                counter++;
            });

            foreach (var item in arr)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Traverse(Action<BinaryNode<TValue>> action, TraverseOption option = TraverseOption.InOrder)
        {
            if (this.Root == null)
            {
                return;
            }

            this.Root.Traverse(action, option);
        }

#if DEBUG
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Traverse(node => sb.AppendFormat("{0} ", node.Value));
            return sb.ToString();
        }

        public void PrintRoot() 
        {
            this.Root.PrintNode();
        }

        private static bool levelCheck;
        public bool LevelCheck() 
        {
            levelCheck = true;
            return LevelCheck(this.Root);
        }

        public bool LevelCheck(BinaryNode<TValue> node) 
        {
            if (node.Parent != null && node.Parent.Level <= node.Level)
            {
                levelCheck = false;
            }

            if (node.Left == null && node.Right == null)
            {
                return levelCheck;
            }

            int leftSubtreeLvl = node.Left == null ? -1 : node.Left.Level;
            int rightSubtreeLvl = node.Right == null ? -1 : node.Right.Level;

            if (Math.Abs(leftSubtreeLvl - rightSubtreeLvl) > 1)
            {
                levelCheck = false;
            }

            if (node.Left != null)
                LevelCheck(node.Left);

            if (node.Right != null)
                LevelCheck(node.Right);

            return levelCheck;
        }

        private static bool parentCheck;
        public bool ParentCheck() 
        {
            parentCheck = true;
            return ParentCheck(this.Root, null);
        }

        private bool ParentCheck(BinaryNode<TValue> node, BinaryNode<TValue> expectedParent)
        {
            if (node.Left != null)
                ParentCheck(node.Left, node);

            var parent = node.Parent;
            if ((parent == null && expectedParent != null) ||
                (parent != null && expectedParent == null) ||
                (parent != null && !parent.Equals(expectedParent)))
            {
                throw new ArgumentException(node.Value + " --> has wrong parent pointer !!! ");
            }

            if (node.Right != null)
                ParentCheck(node.Right, node);

            return parentCheck;
        }
#endif

        private static bool IsImbalanced(BinaryNode<TValue> left, BinaryNode<TValue> right)
        {
            int leftSubtreeLvl = left == null ? -1 : left.Level;
            int rightSubtreeLvl = right == null ? -1 : right.Level;

            if (Math.Abs(leftSubtreeLvl - rightSubtreeLvl) > 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private static int DeepestNodeLevel(BinaryNode<TValue> left, BinaryNode<TValue> right)
        {
            int leftSubtreeLvl = left == null ? -1 : left.Level;
            int rightSubtreeLvl = right == null ? -1 : right.Level;
            return Math.Max(leftSubtreeLvl, rightSubtreeLvl);
        }

        private static BinaryNode<TValue> RebalanceSubTree(BinaryNode<TValue> currNode, int lastDir)
        {
            BinaryNode<TValue> newCurrent;

            RotationType typeOfRotation = ChooseRotation(currNode);
            if (typeOfRotation == RotationType.LeftLeft)
            {
                var parent = currNode.Parent;
                newCurrent = RotateLeftLeft(parent, currNode, lastDir);
            }
            else if (typeOfRotation == RotationType.RightRight)
            {
                var parent = currNode.Parent;
                newCurrent = RotateRightRight(parent, currNode, lastDir);
            }
            else if (typeOfRotation == RotationType.RightLeft)
            {
                var parent = currNode.Parent;
                newCurrent = RotateRightLeft(parent, currNode, lastDir);
            }
            else if (typeOfRotation == RotationType.LeftRight)
            {
                var parent = currNode.Parent;
                newCurrent = RotateLeftRight(parent, currNode, lastDir);
            }
            else
            {
                throw new ArgumentException("Internal tree error.");
            }

            return newCurrent;
        }

        private static RotationType ChooseRotation(BinaryNode<TValue> currNode)
        {
            if (currNode == null)
                throw new ArgumentException("Internal tree error.");

            if (LeftHeavy(currNode.Left, currNode.Right))
            {
                if (currNode.Left == null)
                    throw new ArgumentException("Internal tree error.");

                int leftSubtreeLvl = currNode.Left.Left == null ? -1 : currNode.Left.Left.Level;
                int rightSubtreeLvl = currNode.Left.Right == null ? -1 : currNode.Left.Right.Level;

                if (leftSubtreeLvl >= rightSubtreeLvl)
                    return RotationType.LeftLeft;
                else
                    return RotationType.LeftRight;
            }
            else if (RightHeavy(currNode.Left, currNode.Right))
            {
                if (currNode.Right == null)
                    throw new ArgumentException("Internal tree error.");

                int leftSubtreeLvl = currNode.Right.Left == null ? -1 : currNode.Right.Left.Level;
                int rightSubtreeLvl = currNode.Right.Right == null ? -1 : currNode.Right.Right.Level;

                if (rightSubtreeLvl >= leftSubtreeLvl)
                    return RotationType.RightRight;
                else
                    return RotationType.RightLeft;
            }
            else
            {
                throw new ArgumentException("Internal tree error.");
            }
        }

        private static bool LeftHeavy(BinaryNode<TValue> left, BinaryNode<TValue> right)
        {
            int leftSubtreeLvl = left == null ? -1 : left.Level;
            int rightSubtreeLvl = right == null ? -1 : right.Level;
            return leftSubtreeLvl - rightSubtreeLvl > 1;
        }

        private static bool RightHeavy(BinaryNode<TValue> left, BinaryNode<TValue> right)
        {
            int leftSubtreeLvl = left == null ? -1 : left.Level;
            int rightSubtreeLvl = right == null ? -1 : right.Level;
            return rightSubtreeLvl - leftSubtreeLvl > 1;
        }

        private static BinaryNode<TValue> RotateRightRight(BinaryNode<TValue> parent, BinaryNode<TValue> currNode, int lastDir)
        {
            var newCurrent = currNode.Right;
            var left = currNode;
            var right = currNode.Right.Right;

            if (parent != null)
            {
                if (lastDir == 0)
                    parent.Left = newCurrent;
                else
                    parent.Right = newCurrent;
            }

            // new right:
            right.Parent = newCurrent;
            // new left:
            left.Parent = newCurrent;
            left.Right = newCurrent.Left;
            if (newCurrent.Left != null)
            {
                newCurrent.Left.Parent = left;
            }

            // new mid:
            newCurrent.Parent = parent;
            newCurrent.Right = right;
            newCurrent.Left = left;
            // Fix levels after rotation:
            right.Level = DeepestNodeLevel(right.Left, right.Right) + 1;
            left.Level = DeepestNodeLevel(left.Left, left.Right) + 1;
            newCurrent.Level = DeepestNodeLevel(newCurrent.Left, newCurrent.Right) + 1;
            return newCurrent;
        }
        private static BinaryNode<TValue> RotateLeftLeft(BinaryNode<TValue> parent, BinaryNode<TValue> currNode, int lastDir)
        {
            var newCurrent = currNode.Left;
            var right = currNode;
            var left = currNode.Left.Left;

            if (parent != null)
            {
                if (lastDir == 0)
                    parent.Left = newCurrent;
                else
                    parent.Right = newCurrent;
            }

            // new right:
            right.Parent = newCurrent;
            right.Left = newCurrent.Right;
            if (newCurrent.Right != null)
            {
                newCurrent.Right.Parent = right;
            }

            // new left:
            left.Parent = newCurrent;
            // new mid:
            newCurrent.Parent = parent;
            newCurrent.Right = right;
            newCurrent.Left = left;
            // Fix levels after rotation:
            right.Level = DeepestNodeLevel(right.Left, right.Right) + 1;
            left.Level = DeepestNodeLevel(left.Left, left.Right) + 1;
            newCurrent.Level = DeepestNodeLevel(newCurrent.Left, newCurrent.Right) + 1;
            return newCurrent;
        }

        private static BinaryNode<TValue> RotateRightLeft(BinaryNode<TValue> parent, BinaryNode<TValue> currNode, int lastDir)
        {
            var newCurrent = currNode.Right.Left;
            var right = currNode.Right;
            var left = currNode;

            if (parent != null)
            {
                if (lastDir == 0)
                    parent.Left = newCurrent;
                else
                    parent.Right = newCurrent;
            }

            // new right:
            right.Parent = newCurrent;
            right.Left = newCurrent.Right;
            if (newCurrent.Right != null)
            {
                newCurrent.Right.Parent = right;
            }

            // new left
            left.Parent = newCurrent;
            left.Right = newCurrent.Left;
            if (newCurrent.Left != null)
            {
                newCurrent.Left.Parent = left;
            }

            // new mid:
            newCurrent.Parent = parent;
            newCurrent.Right = right;
            newCurrent.Left = left;
            // Fix levels after rotation:
            right.Level = DeepestNodeLevel(right.Left, right.Right) + 1;
            left.Level = DeepestNodeLevel(left.Left, left.Right) + 1;
            newCurrent.Level = DeepestNodeLevel(newCurrent.Left, newCurrent.Right) + 1;
            return newCurrent;
        }

        private static BinaryNode<TValue> RotateLeftRight(BinaryNode<TValue> parent, BinaryNode<TValue> currNode, int lastDir)
        {
            var newCurrent = currNode.Left.Right;
            var right = currNode;
            var left = currNode.Left;

            if (parent != null)
            {
                if (lastDir == 0)
                    parent.Left = newCurrent;
                else
                    parent.Right = newCurrent;
            }

            // new right:
            right.Parent = newCurrent;
            right.Left = newCurrent.Right;
            if (newCurrent.Right != null)
            {
                newCurrent.Right.Parent = right;
            }

            // new left
            left.Parent = newCurrent;
            left.Right = newCurrent.Left;
            if (newCurrent.Left != null)
            {
                newCurrent.Left.Parent = left;
            }

            // new mid:
            newCurrent.Parent = parent;
            newCurrent.Right = right;
            newCurrent.Left = left;
            // Fix levels after rotation:
            right.Level = DeepestNodeLevel(right.Left, right.Right) + 1;
            left.Level = DeepestNodeLevel(left.Left, left.Right) + 1;
            newCurrent.Level = DeepestNodeLevel(newCurrent.Left, newCurrent.Right) + 1;
            return newCurrent;
        }
    }
}
