namespace _03.ArrayStack
{
    using System;
    using System.Collections.Generic;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 10;
        private const int GrowthMult = 2;
        private int count;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            elements = new T[capacity];
            this.count = 0;
        }

        public int Count 
        { 
            get { return this.count; } 
        }

        private void Grow()
        {
            T[] copyArr = new T[this.elements.Length * GrowthMult];
            Array.Copy(elements, copyArr, this.elements.Length);
            this.elements = copyArr;
        }

        public void Push(T value)
        {
            if (this.count >= this.elements.Length)
                this.Grow();
            
            this.elements[this.count++] = value;
        }

        public T Pop()
        {
            if (this.count == 0)
                throw new IndexOutOfRangeException("No more elements to pop.");
            
            return this.elements[--this.count];
        }

        public T Peek()
        {
            if (this.count == 0)
                throw new IndexOutOfRangeException("No elements to peek from.");
            
            return this.elements[this.count - 1];
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];
            for (int i = 0, reverse = this.count - 1; i < this.count; i++, reverse--)
            {
                result[reverse] = this.elements[i];
            }

            return result;
        }
    }
}
