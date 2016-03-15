namespace DS_ImplementationTests.Trees.AATree
{
    using System;
    using System.Linq;
    using DS_Implementations.Trees.AATree;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AATreeTests
    {
        [TestMethod]
        public void AddNodesTest()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            tree.Add(16);
            tree.Add(10);
            tree.Add(11);
            tree.Add(5);

            int[] expectedResult = { 5, 10, 11, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 10 11 15 16 20 25 ", tree.ToString());
            Assert.AreEqual(7, tree.Count);
        }

        [TestMethod]
        public void AddToDataTestWithRndNumbers()
        {
            AATree<int> tree = new AATree<int>();
            int[] expectedResult = new int[10000];
            Random rnd = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int currentRnd = rnd.Next(i * 10, i * 10 + 10); // assure we don't duplicate values.
                tree.Add(currentRnd);
                expectedResult[i] = currentRnd;
            }

            Array.Sort(expectedResult);
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
        }

        [TestMethod]
        public void RemoveLeafs()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            tree.Add(16);
            tree.Add(10);
            tree.Add(11);
            tree.Add(5);

            tree.Remove(5);
            int[] expectedResult = { 10, 11, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("10 11 15 16 20 25 ", tree.ToString());
            Assert.AreEqual(6, tree.Count);

            tree.Remove(11);
            expectedResult = new[] { 10, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("10 15 16 20 25 ", tree.ToString());
            Assert.AreEqual(5, tree.Count);

            tree.Remove(10);
            expectedResult = new[] { 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("15 16 20 25 ", tree.ToString());
            Assert.AreEqual(4, tree.Count);

            tree.Remove(25);
            expectedResult = new[] { 15, 16, 20 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("15 16 20 ", tree.ToString());
            Assert.AreEqual(3, tree.Count);

            tree.Remove(16);
            expectedResult = new[] { 15, 20 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("15 20 ", tree.ToString());
            Assert.AreEqual(2, tree.Count);

            tree.Remove(20);
            expectedResult = new[] { 15 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("15 ", tree.ToString());
            Assert.AreEqual(1, tree.Count);

            tree.Remove(15);
            expectedResult = new int[0];
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("", tree.ToString());
            Assert.AreEqual(0, tree.Count);
        }

        public void RemoveRootWithOnlyLeftNode()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            tree.Add(16);

            tree.Remove(15);
            int[] expectedResult = { 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("16 20 25 ", tree.ToString());
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void RemoveRootWithOnlyRightNode()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(15);
            tree.Add(10);
            tree.Add(11);
            tree.Add(5);

            tree.Remove(15);
            int[] expectedResult = { 5, 10, 11 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 10 11 ", tree.ToString());
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void RemoveInternalNodes()
        {
            AATree<int> tree = new AATree<int>();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            tree.Add(16);
            tree.Add(10);
            tree.Add(11);
            tree.Add(5);

            tree.Remove(10);
            int[] expectedResult = { 5, 11, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 11 15 16 20 25 ", tree.ToString());
            Assert.AreEqual(6, tree.Count);

            tree.Remove(11);
            expectedResult = new int[] { 5, 15, 16, 20, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 15 16 20 25 ", tree.ToString());
            Assert.AreEqual(5, tree.Count);

            tree.Remove(20);
            expectedResult = new int[] { 5, 15, 16, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 15 16 25 ", tree.ToString());
            Assert.AreEqual(4, tree.Count);

            tree.Remove(15);
            expectedResult = new int[] { 5, 16, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 16 25 ", tree.ToString());
            Assert.AreEqual(3, tree.Count);

            tree.Remove(16);
            expectedResult = new int[] { 5, 25 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 25 ", tree.ToString());
            Assert.AreEqual(2, tree.Count);

            tree.Remove(25);
            expectedResult = new int[] { 5 };
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("5 ", tree.ToString());
            Assert.AreEqual(1, tree.Count);

            tree.Remove(5);
            expectedResult = new int[0];
            CollectionAssert.AreEqual(expectedResult, tree.ToArray());
            Assert.AreEqual("", tree.ToString());
            Assert.AreEqual(0, tree.Count);
        }
    }
}
