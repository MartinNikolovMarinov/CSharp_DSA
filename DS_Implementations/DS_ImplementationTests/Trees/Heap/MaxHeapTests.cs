namespace DS_ImplementationTests.Trees.Heap
{
    using System;
    using System.Linq;
    using DS_Implementations.Trees.Heap;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void HeapSimpleInsertTest()
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            Assert.AreEqual(0, heap.Count());

            heap.Insert(10);
            heap.Insert(8);
            heap.Insert(12);
            heap.Insert(16);
            heap.Insert(11);

            CollectionAssert.AreEqual(new int[] { 16, 12, 10, 8, 11 }, heap.ToArray());
            Assert.AreEqual(5, heap.Count());

            heap.Insert(99);
            CollectionAssert.AreEqual(new int[] { 99, 12, 16, 8, 11, 10 }, heap.ToArray());
            Assert.AreEqual(6, heap.Count());

            heap.Insert(8);
            CollectionAssert.AreEqual(new int[] { 99, 12, 16, 8, 11, 10, 8 }, heap.ToArray());
            Assert.AreEqual(7, heap.Count());

            heap.Insert(8);
            CollectionAssert.AreEqual(new int[] { 99, 12, 16, 8, 11, 10, 8, 8 }, heap.ToArray());
            Assert.AreEqual(8, heap.Count());

            heap.Insert(13);
            CollectionAssert.AreEqual(new int[] { 99, 13, 16, 12, 11, 10, 8, 8, 8 }, heap.ToArray());
            Assert.AreEqual(9, heap.Count());

            heap.Insert(50);
            CollectionAssert.AreEqual(new int[] { 99, 50, 16, 12, 13, 10, 8, 8, 8, 11 }, heap.ToArray());
            Assert.AreEqual(10, heap.Count());
        }

        [TestMethod]
        public void GetMaxTest()
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            heap.Insert(1);
            heap.Insert(2);
            heap.Insert(3);
            heap.Insert(4);
            heap.Insert(5);
            heap.Insert(6);

            CollectionAssert.AreEqual(new int[] { 6, 4, 5, 1, 3, 2 }, heap.ToArray());
            Assert.AreEqual(6, heap.Count());

            int result = heap.GetMax();
            CollectionAssert.AreEqual(new int[] { 5, 4, 2, 1, 3 }, heap.ToArray());
            Assert.AreEqual(5, heap.Count());
            Assert.AreEqual(6, result);

            result = heap.GetMax();
            CollectionAssert.AreEqual(new int[] { 4, 3, 2, 1 }, heap.ToArray());
            Assert.AreEqual(4, heap.Count());
            Assert.AreEqual(5, result);

            result = heap.GetMax();
            CollectionAssert.AreEqual(new int[] { 3, 1, 2 }, heap.ToArray());
            Assert.AreEqual(3, heap.Count());
            Assert.AreEqual(4, result);

            result = heap.GetMax();
            CollectionAssert.AreEqual(new int[] { 2, 1 }, heap.ToArray());
            Assert.AreEqual(2, heap.Count());
            Assert.AreEqual(3, result);

            result = heap.GetMax();
            CollectionAssert.AreEqual(new int[] { 1 }, heap.ToArray());
            Assert.AreEqual(1, heap.Count());
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void SortTest_1()
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            heap.Insert(6);
            heap.Insert(3);
            heap.Insert(4);
            heap.Insert(1);
            heap.Insert(5);
            heap.Insert(2);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 }, heap.Sort());
        }

        [TestMethod]
        public void SortTest_2()
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            CollectionAssert.AreEqual(new int[] { }, heap.Sort());
        }

        [TestMethod]
        public void SortTest_3()
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            heap.Insert(-6);
            heap.Insert(3);
            heap.Insert(2);
            heap.Insert(1);
            heap.Insert(1);
            heap.Insert(2);

            CollectionAssert.AreEqual(new int[] { -6, 1, 1, 2, 2, 3 }, heap.Sort());
        }

        [TestMethod]
        public void SortWithRandomElements()
        {
            MaxHeap<int> heap = new MaxHeap<int>();
            int[] arr = new int[1000];
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int rndNum = rnd.Next(-10000, 10000);
                arr[i] = rndNum;
                heap.Insert(rndNum);
            }

            Array.Sort(arr);
            CollectionAssert.AreEqual(arr, heap.Sort());
        }
    }
}