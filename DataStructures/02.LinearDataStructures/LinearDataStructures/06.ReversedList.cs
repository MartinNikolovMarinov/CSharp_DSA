using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    public class ReversedList<T> : IEnumerable<T>
    {
        private T[] elements;
        private int capacity;
        private int count;

        public ReversedList() 
        {
            this.elements = new T[4];
            this.capacity = 4;
            this.count = 0;
        }

        public int Count 
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public T this[int key]
        {
            get
            {
                try
                {
                    return this.elements[this.count - key - 1];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("The given key is out of range");
                }
            }
            set
            {
                try
                {
                    this.elements[this.count - key - 1] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("The given key is out of range");
                }
            }

        }

        public void Add(T value) 
        {
            if (this.Count + 1 > this.Capacity)
            {
                Array.Resize(ref this.elements, this.Capacity * 2);
                this.capacity *= 2;
            }

            this.elements[count] = value;
            this.count++;
        }

        public void Remove(int index) 
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException(String.Format("The index must be in [0-{0}]", this.Count));
            }

            T[] newArr = new T[Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                if (i != this.Count - index - 1)
                {
                    newArr[i] = this.elements[i];
                }
            }

            this.elements = newArr;
            this.count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[this.Count - i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
