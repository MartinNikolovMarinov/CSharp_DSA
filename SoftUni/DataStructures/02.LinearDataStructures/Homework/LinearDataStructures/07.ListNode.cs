using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
	public class ListNode<T> where T : IComparable
	{
        public T Data { get; set; }
        public ListNode<T> Next { get; set; }

        public ListNode(T data, ListNode<T> next)
		{
			this.Data = data;
			this.Next = next;
		}

        public override bool Equals(object obj)
        {
            if (obj is ListNode<T>)
            {
                var objAsNode = obj as ListNode<T>;

                if (this.Data.CompareTo(objAsNode.Data) == 0)
                {
                    return true;
                }
            }

            return false;
        }
	}
}
