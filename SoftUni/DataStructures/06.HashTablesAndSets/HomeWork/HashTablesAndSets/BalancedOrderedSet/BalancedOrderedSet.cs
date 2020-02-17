namespace BalancedOrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BalancedOrderedSet<T> : ICollection<T> where T : IComparable<T>
    {
        private AATree<T> set;

        public int Count { get { return this.set.Count; } }
        public bool IsReadOnly { get { return false; }}

        public BalancedOrderedSet() 
        {
            this.set = new AATree<T>();
        }

        public void Add(T item)
        {
            this.set.Add(item);
        }

        public void Clear()
        {
            this.set.Clear();
        }

        public bool Contains(T item)
        {
            return this.set.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.set.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return this.set.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
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
