using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public class LinkedList<T> : IEnumerable<T> where T : IComparable
    {
        private ListNode<T> head;
        private int length;

        public LinkedList()
        {
            this.head = null;
            this.length = 0;
        }

        public ListNode<T> Head
        {
            get { return this.head;}
            set { this.head = value;}
        }

        public int Length
        {
            get { return this.length;}
            set { this.length = value;}
        }

        public void Add (T value) 
        {
            if (this.head == null)
            {
                this.head = new ListNode<T>(value, null);
                this.length++;
                return;
            }

		    ListNode<T> tailNode =  this.head;
		    while (tailNode.Next != null) 
            {
			    tailNode = tailNode.Next;
		    }

            var newNode = new ListNode<T>(value, null);
		    tailNode.Next = newNode;
            this.length++;
	    }

        private void RemoveWhenLessThanTwoElements(T value)
        {
            if (this.length == 1 && this.Head.Data.Equals(value)) 
            {
				this.head = null;
				this.length--;
			}

			if (this.length == 2)
            {
                if (this.Head.Data.Equals(value))
                {
					this.head = this.head.Next;
					this.length--;
                    return;
				}

                if (this.head.Next.Data.Equals(value))
                {
					this.head = new ListNode<T>(this.Head.Data, null);
					this.length--;
                    return;
				}
			}
        }

        private void RemoveWhenMoreThanTwoElements(T value) 
        {
            var curNode = this.head;
            var prev = this.head;

            // front boarder case:
            if (curNode.Data.Equals(value))
            {
                this.Head = this.Head.Next;
                this.Length--;
                return;
            }

            // middle case:
            curNode = curNode.Next;
            while (curNode.Next != null)
            {
                if (curNode.Data.Equals(value))
                {
                    prev.Next = curNode.Next;
                    this.length--;
                    return;
                }

                prev = prev.Next;
                curNode = curNode.Next;
            }

            // end boarder case:
            if (curNode.Data.Equals(value))
            {
                prev.Next = null;
                this.length--;
                return;
            }
        }

        public void Remove (T value) 
        {
            // less than 2 elements cases:
		    if (this.length <= 2) 
            {
                RemoveWhenLessThanTwoElements(value);
                return;
		    }

            RemoveWhenMoreThanTwoElements(value);
        }

        public int FirstIndexOf(T item) 
        {
            if (this.head == null)
            {
                return -1;
            }

            var curNode = this.head;
            for (var i = 0; i < this.length; i++)
            {
                if (curNode.Data.Equals(item))
                {
                    return i;
                }

                curNode = curNode.Next;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            if (this.head == null)
            {
                return -1;
            }

            var curNode = this.head;
            int index = -1;

            for (var i = 0; i < this.length; i++)
            {
                if (curNode.Data.Equals(item))
                {
                    index = i;
                }

                curNode = curNode.Next;
            }

            return index;
        }

        public T[] ToArray()
        {
		    var curNode = this.head;
		    T[] resultArr = new T[this.length];

		    for (var i = 0; i < this.length; i++) 
            {
			    resultArr[i] = curNode.Data;
                curNode = curNode.Next;
		    }

		    return resultArr;
	    }

        public T ElementAt(int index)
        {
            if (index < 0 || index > this.length)
            {
                throw new IndexOutOfRangeException(String.Format("Index must be in [0-{0}]", this.length));
            }

            var curNode = this.head;
            for (int i = 0; i < index; i++)
            {
                curNode = curNode.Next;
            }

            return curNode.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var curNode = this.head;

            for (int i = 0; i < this.length; i++)
            {
                yield return curNode.Data;
                curNode = curNode.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
