using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedSet
{
    public class OrderedSetNode<T>
    {
        public T Value { get; set; }
        public OrderedSetNode<T> Parent { get; set; }
        public OrderedSetNode<T> LeftChild { get; set; }
        public OrderedSetNode<T> RightChild { get; set; }
        public List<OrderedSetNode<T>> Children
        {
            get
            {
                var children = new List<OrderedSetNode<T>>();

                if (this.LeftChild != null)
                {
                    children.Add(this.LeftChild);
                }

                if (this.RightChild != null)
                {
                    children.Add(this.RightChild);
                }

                return children;
            }
        }

        public OrderedSetNode(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }

        public override string ToString()
        {
            return string.Format("({0})", this.Value.ToString());
        }

        public static void CopyNode(OrderedSetNode<T> source, ref OrderedSetNode<T> dest)
        {
            dest.Value = source.Value;
            dest.Parent = source.Parent;
            dest.LeftChild = source.LeftChild;
            dest.RightChild = source.RightChild;
        }
    }
}
