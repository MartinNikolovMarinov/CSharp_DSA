namespace StackAndQueuesTests
{
    using System;
    using _03.ArrayStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PushPopCountTest()
        {
            ArrayStack<int> tStack = new ArrayStack<int>();
            Assert.AreEqual(0, tStack.Count);

            tStack.Push(1);
            Assert.AreEqual(1, tStack.Count);
            Assert.AreEqual(1, tStack.Peek());

            tStack.Push(3);
            Assert.AreEqual(2, tStack.Count);
            Assert.AreEqual(3, tStack.Peek());

            tStack.Pop();
            Assert.AreEqual(1, tStack.Count);
            Assert.AreEqual(1, tStack.Peek());
        }

        [TestMethod]
        public void Push3000TimesTest()
        {
            ArrayStack<int> tStack = new ArrayStack<int>();
            Assert.AreEqual(0, tStack.Count);

            for (int i = 1; i < 1000; i++)
            {
                tStack.Push(i);
            }

            Assert.AreEqual(999, tStack.Count);

            for (int i = 1000; i < 2000; i++)
            {
                tStack.Push(i);
            }

            tStack.Push(tStack.Peek() + 1);
            Assert.AreEqual(2000, tStack.Count);
            Assert.AreEqual(2000, tStack.Pop());
            Assert.AreEqual(1999, tStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void PopEmptyStackTest()
        {
            ArrayStack<int> tStack = new ArrayStack<int>();
            tStack.Pop();
        }

        [TestMethod]
        public void PopWithInitialCapacity1Test()
        {
            ArrayStack<int> tStack = new ArrayStack<int>(1);

            Assert.AreEqual(0, tStack.Count);
            tStack.Push(11);
            Assert.AreEqual(1, tStack.Count);
            tStack.Push(17);
            Assert.AreEqual(2, tStack.Count);

            Assert.AreEqual(17, tStack.Pop());
            Assert.AreEqual(1, tStack.Count);
            Assert.AreEqual(11, tStack.Pop());
            Assert.AreEqual(0, tStack.Count);
        }

        [TestMethod]
        public void StackToArrayTest()
        {
            ArrayStack<int> tStack = new ArrayStack<int>();

            tStack.Push(3);
            tStack.Push(5);
            tStack.Push(-2);
            tStack.Push(7);

            CollectionAssert.AreEqual(new int[] { 7, -2, 5, 3 }, tStack.ToArray());
        }

        [TestMethod]
        public void EmptyStackToArrayTest()
        {
            ArrayStack<int> tStack = new ArrayStack<int>();
            CollectionAssert.AreEqual(new int[] { }, tStack.ToArray());
        }
    }
}
