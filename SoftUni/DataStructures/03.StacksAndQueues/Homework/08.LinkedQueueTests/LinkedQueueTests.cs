namespace StackAndQueuesTests
{
    using System;
    using _07.LinkedQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ZeroElementsDequeuing()
        {
            LinkedQueue<int> linkedQ = new LinkedQueue<int>();
            linkedQ.Dequeue();
        }

        [TestMethod]
        public void OneElementQueuingAndDequeuing()
        {
            LinkedQueue<int> linkedQ = new LinkedQueue<int>();
            linkedQ.Enqueue(7);

            Assert.AreEqual(1, linkedQ.Count);
            Assert.AreEqual(7, linkedQ.Dequeue());
            Assert.AreEqual(0, linkedQ.Count);
        }

        [TestMethod]
        public void TwoElementsQueuingAndDequeuing()
        {
            LinkedQueue<int> linkedQ = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQ.Count);
            linkedQ.Enqueue(7);

            Assert.AreEqual(1, linkedQ.Count);
            Assert.AreEqual(7, linkedQ.Dequeue());
            Assert.AreEqual(0, linkedQ.Count);

            linkedQ.Enqueue(7);
            linkedQ.Enqueue(8);
            Assert.AreEqual(2, linkedQ.Count);
            Assert.AreEqual(7, linkedQ.Dequeue());
            Assert.AreEqual(1, linkedQ.Count);
            Assert.AreEqual(1, linkedQ.Count);
            Assert.AreEqual(8, linkedQ.Dequeue());
            Assert.AreEqual(0, linkedQ.Count);
        }

        [TestMethod]
        public void TestWithALotOfElements()
        {
            LinkedQueue<int> linkedQ = new LinkedQueue<int>();
            Assert.AreEqual(0, linkedQ.Count);

            for (int i = 1; i <= 1000; i++)
            {
                linkedQ.Enqueue(i);
            }

            Assert.AreEqual(1000, linkedQ.Count);
            Assert.AreEqual(1, linkedQ.Dequeue());
            Assert.AreEqual(999, linkedQ.Count);

            for (int i = 1000; i <= 2000; i++)
            {
                linkedQ.Enqueue(i);
            }

            Assert.AreEqual(2000, linkedQ.Count);
            Assert.AreEqual(2, linkedQ.Dequeue());
            Assert.AreEqual(1999, linkedQ.Count);
        }

        [TestMethod]
        public void ToArrayTests()
        {
            LinkedQueue<int> linkedQ = new LinkedQueue<int>();
            linkedQ.Enqueue(1);
            linkedQ.Enqueue(2);
            linkedQ.Enqueue(3);
            linkedQ.Enqueue(4);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, linkedQ.ToArray());
        }
    }
}
