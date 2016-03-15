namespace DS_Implementations.Trees.Heap
{
    using DS_Implementations;
    using System;
    
    public class MaxHeap<T> : Heap<T> where T : IComparable<T>
    {
        public MaxHeap(int capacity = 8) : base(capacity){}

        public void Insert(T value)
        {
            if (this.Count >= this.heap.Length)
            {
                this.ResizeHeap();
            }
            if (this.Count == 0)
            {
                this.heap[0] = value;
                this.Count++;
                return;
            }

            int i = this.Count;
            this.heap[this.Count] = value;
            while (value.CompareTo(heap[(i - 1) / 2]) > 0)
            {
                Global.Swap(ref this.heap[i], ref this.heap[(i - 1) / 2]);
                i = (i - 1) / 2;
            }

            this.Count++;
        }

        public void Insert(T[] values) 
        {
            foreach (var v in values)
            {
                this.Insert(v);
            }
        }

        public T GetMax()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("No elements in heap.");
            }

            T result = this.heap[0];
            int i = 0;
            bool lastMove = false;
            this.heap[0] = this.heap[this.Count - 1];
            this.Count--;

            while (!lastMove)
            {
                int left = (i + 1) * 2 - 1;
                int right = (i + 1) * 2;
                int biggerChild, smallerChild;
                BiggerAndSmallerIndex(i, left, right, out smallerChild, out biggerChild);

                if (biggerChild == -1 && smallerChild == -1)
                {
                    lastMove = true;
                }
                else if (smallerChild == -1)
                {
                    if (this.heap[i].CompareTo(this.heap[biggerChild]) < 0)
                    {
                        Global.Swap(ref this.heap[i], ref this.heap[biggerChild]);
                        i = biggerChild;
                    }
                    else
                    {
                        lastMove = true;
                    }
                }
                else if (biggerChild == -1)
                {
                    if (this.heap[i].CompareTo(this.heap[smallerChild]) < 0)
                    {
                        Global.Swap(ref this.heap[i], ref this.heap[smallerChild]);
                        i = smallerChild;
                    }
                    else
                    {
                        lastMove = true;
                    }
                }
                else
                {
                    if (this.heap[i].CompareTo(this.heap[biggerChild]) < 0)
                    {
                        Global.Swap(ref this.heap[i], ref this.heap[biggerChild]);
                        i = biggerChild;
                    }
                    else if (this.heap[i].CompareTo(this.heap[smallerChild]) < 0)
                    {
                        Global.Swap(ref this.heap[i], ref this.heap[smallerChild]);
                        i = smallerChild;
                    }
                    else
                    {
                        lastMove = true;
                    }
                }
            }

            return result;
        }

        public T[] Sort() 
        {
            int end = this.Count - 1;
            T[] arr = new T[this.Count];
            Array.Copy(this.heap, arr, this.Count);

            while (end > 0)
            {
                Global.Swap(ref arr[end], ref arr[0]);
                end--;
                siftDown(arr, 0, end);
            }

            if (arr.Length > 2 && arr[0].CompareTo(arr[1]) > 0)
            {
                Global.Swap(ref arr[0], ref arr[1]);
            }

            return arr;
        }

        private void siftDown(T[] arr, int start, int end)
        {
            int root = start;
            while ((root + 1) * 2 <= end)
            {
                int leftChild = (root + 1) * 2 - 1;
                int rightChild = (root + 1) * 2;
                int swapIndex = root;

                if (arr[swapIndex].CompareTo(arr[leftChild]) < 0)
                {
                    swapIndex = leftChild;
                }
                if ( rightChild <= end && arr[swapIndex].CompareTo(arr[rightChild]) < 0)
                {
                    swapIndex = rightChild;
                }
                if (swapIndex == root)
                {
                    return;
                }
                else
                {
                    Global.Swap(ref arr[root], ref arr[swapIndex]);
                    root = swapIndex;
                }
            }
        }

        private void BiggerAndSmallerIndex(int i, int left, int right, out int smallerChild, out int biggerChild)
        {
            if (left >= this.Count && right >= this.Count)
            {
                biggerChild = -1;
                smallerChild = -1;
            }
            else if (left >= this.Count)
            {
                biggerChild = right;
                smallerChild = -1;
            }
            else if (right >= this.Count)
            {
                biggerChild = left;
                smallerChild = -1;
            }
            else if (this.heap[right].CompareTo(this.heap[left]) > 0)
            {
                biggerChild = right;
                smallerChild = left;
            }
            else if (this.heap[left].CompareTo(this.heap[right]) > 0)
            {
                biggerChild = left;
                smallerChild = right;
            }
            else
            {
                throw new ArgumentException("Heap internal error!");
            }
        }
    }
}
