using System;
using BalancedOrderedSet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BalancedOrderedSetTests
{
    [TestClass]
    public class BalancedOrderedSetTests
    {
        [TestMethod]
        public void Balanced_SoftUniTestExample()
        {
            var set = new BalancedOrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);

            int[] expectedResult = { 6, 9, 12, 17, 19, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("6 9 12 17 19 25 ", set.ToString());
            Assert.AreEqual(6, set.Count);
        }

        [TestMethod]
        public void Balanced_AddNodesTest()
        {
            BalancedOrderedSet<int> set = new BalancedOrderedSet<int>();
            set.Add(15);
            set.Add(20);
            set.Add(25);
            set.Add(16);
            set.Add(10);
            set.Add(11);
            set.Add(5);

            int[] expectedResult = { 5, 10, 11, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 10 11 15 16 20 25 ", set.ToString());
            Assert.AreEqual(7, set.Count);
        }

        [TestMethod]
        public void Balanced_Add1000RndNodes()
        {
            BalancedOrderedSet<int> set = new BalancedOrderedSet<int>();
            int[] expectedResult = new int[1000];
            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int currentRnd = rnd.Next(i * 10, i * 10 + 10); // assure we don't duplicate values.
                set.Add(currentRnd);
                expectedResult[i] = currentRnd;
            }

            Array.Sort(expectedResult);
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
        }

        [TestMethod]
        public void Balanced_RemoveLeafs()
        {
            BalancedOrderedSet<int> set = new BalancedOrderedSet<int>();
            set.Add(15);
            set.Add(20);
            set.Add(25);
            set.Add(16);
            set.Add(10);
            set.Add(11);
            set.Add(5);

            set.Remove(5);
            int[] expectedResult = { 10, 11, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("10 11 15 16 20 25 ", set.ToString());
            Assert.AreEqual(6, set.Count);

            set.Remove(11);
            expectedResult = new[] { 10, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("10 15 16 20 25 ", set.ToString());
            Assert.AreEqual(5, set.Count);

            set.Remove(10);
            expectedResult = new[] { 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("15 16 20 25 ", set.ToString());
            Assert.AreEqual(4, set.Count);

            set.Remove(25);
            expectedResult = new[] { 15, 16, 20 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("15 16 20 ", set.ToString());
            Assert.AreEqual(3, set.Count);

            set.Remove(16);
            expectedResult = new[] { 15, 20 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("15 20 ", set.ToString());
            Assert.AreEqual(2, set.Count);

            set.Remove(20);
            expectedResult = new[] { 15 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("15 ", set.ToString());
            Assert.AreEqual(1, set.Count);

            set.Remove(15);
            expectedResult = new int[0];
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("", set.ToString());
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void Balanced_RemoveRootWithOnlyLeftNode()
        {
            BalancedOrderedSet<int> set = new BalancedOrderedSet<int>();
            set.Add(15);
            set.Add(20);
            set.Add(25);
            set.Add(16);

            set.Remove(15);
            int[] expectedResult = { 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("16 20 25 ", set.ToString());
            Assert.AreEqual(3, set.Count);
        }

        [TestMethod]
        public void Balanced_RemoveRootWithOnlyRightNode()
        {
            BalancedOrderedSet<int> set = new BalancedOrderedSet<int>();
            set.Add(15);
            set.Add(10);
            set.Add(11);
            set.Add(5);

            set.Remove(15);
            int[] expectedResult = { 5, 10, 11 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 10 11 ", set.ToString());
            Assert.AreEqual(3, set.Count);
        }

        [TestMethod]
        public void Balanced_RemoveInternalNodes()
        {
            BalancedOrderedSet<int> set = new BalancedOrderedSet<int>();
            set.Add(15);
            set.Add(20);
            set.Add(25);
            set.Add(16);
            set.Add(10);
            set.Add(11);
            set.Add(5);

            set.Remove(10);
            int[] expectedResult = { 5, 11, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 11 15 16 20 25 ", set.ToString());
            Assert.AreEqual(6, set.Count);

            set.Remove(11);
            expectedResult = new int[] { 5, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 15 16 20 25 ", set.ToString());
            Assert.AreEqual(5, set.Count);

            set.Remove(20);
            expectedResult = new int[] { 5, 15, 16, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 15 16 25 ", set.ToString());
            Assert.AreEqual(4, set.Count);

            set.Remove(15);
            expectedResult = new int[] { 5, 16, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 16 25 ", set.ToString());
            Assert.AreEqual(3, set.Count);

            set.Remove(16);
            expectedResult = new int[] { 5, 25 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 25 ", set.ToString());
            Assert.AreEqual(2, set.Count);

            set.Remove(25);
            expectedResult = new int[] { 5 };
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("5 ", set.ToString());
            Assert.AreEqual(1, set.Count);

            set.Remove(5);
            expectedResult = new int[0];
            CollectionAssert.AreEqual(expectedResult, set.ToArray());
            Assert.AreEqual("", set.ToString());
            Assert.AreEqual(0, set.Count);
        }
    }
}
