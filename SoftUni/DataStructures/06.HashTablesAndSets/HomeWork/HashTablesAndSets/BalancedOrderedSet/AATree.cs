namespace BalancedOrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class AATree<TValue> : ICollection<TValue> where TValue : IComparable<TValue>
    {
        private static bool ElementNotFound = false;
        public BinaryNode<TValue> Root { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly { get { return false; } }

        public AATree()
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
            this.Root = Add(item, this.Root);
        }

        private BinaryNode<TValue> Add(TValue item, BinaryNode<TValue> node)
        {
            if (node == null)
            {
                var newNode = new BinaryNode<TValue>()
                {
                    Value = item,
                    Level = 1
                };

                return newNode;
            }
            else if (item.CompareTo(node.Value) < 0)
            {
                node.Left = Add(item, node.Left);
            }
            else if (item.CompareTo(node.Value) > 0)
            {
                node.Right = Add(item, node.Right);
            }
            else
            {
                throw new ArgumentException(item + " already exists in the AATree.");
            }

            node = Skew(node);
            node = Split(node);

            return node;
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
            this.Root = Remove(item, this.Root);

            if (ElementNotFound)
            {
                return false;
            }
            else
            {
                this.Count--;
                return true;
            }
        }

        private BinaryNode<TValue> Remove(TValue item, BinaryNode<TValue> node)
        {
            if (node == null)
            {
                ElementNotFound = true;
                return node;
            }
            else if (item.CompareTo(node.Value) > 0)
            {
                node.Right = Remove(item, node.Right);
            }
            else if (item.CompareTo(node.Value) < 0)
            {
                node.Left = Remove(item, node.Left);
            }
            else
            {
                if (!node.HasChildren())
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    var successor = BinaryNode<TValue>.FindSuccessor(node);
                    node.Right = Remove(successor.Value, node.Right);
                    node.Value = successor.Value;
                }
                else
                {
                    var predecessor = BinaryNode<TValue>.FindPredecessor(node);
                    node.Left = Remove(predecessor.Value, node.Left);
                    node.Value = predecessor.Value;
                }
            }

            node = DecreeseLevel(node);
            node = Skew(node);
            node.Right = Skew(node.Right);
            if (node.Right != null)
            {
                node.Right.Right = Skew(node.Right.Right);
            }

            node = Split(node);
            node.Right = Split(node.Right);
            return node;
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
#endif

        private static BinaryNode<TValue> Skew(BinaryNode<TValue> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node;
            }
            else if (node.Level == node.Left.Level)
            {
                var leftChild = node.Left;
                node.Left = leftChild.Right;
                leftChild.Right = node;
                return leftChild;
            }
            else
            {
                return node;
            }
        }

        private static BinaryNode<TValue> Split(BinaryNode<TValue> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Level == node.Right.Right.Level)
            {
                var right = node.Right;
                node.Right = right.Left;
                right.Left = node;
                right.Level++;
                return right;
            }
            else
            {
                return node;
            }
        }

        private static BinaryNode<TValue> DecreeseLevel(BinaryNode<TValue> node)
        {
            if (node.Left == null || node.Right == null)
            {
                return node;
            }

            int shouldBe = Math.Min(node.Left.Level, node.Right.Level) + 1;
            if (shouldBe < node.Level)
            {
                node.Level = shouldBe;
                if (shouldBe < node.Right.Level)
                {
                    node.Right.Level = shouldBe;
                }
            }

            return node;
        }
    }
}
