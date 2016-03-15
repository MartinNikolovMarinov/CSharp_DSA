namespace DS_ImplementationTests.Trees.AVLTree
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    using DS_Implementations;
    using DS_Implementations.Trees;
    using DS_Implementations.Trees.AVLTree;


    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void AddNodesTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(15);
            tree.Add(20);
            tree.Add(25);
            tree.Add(16);
            tree.Add(10);
            tree.Add(11);
            tree.Add(5);

            int[] expectedResult = { 5, 10, 11, 15, 16, 20, 25 };
            TreeAsserts<int>(expectedResult, tree);
        }

        [TestMethod]
        public void AddDecreasingNodesTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(30);
            tree.Add(26);
            tree.Add(25);
            tree.Add(20);
            tree.Add(15);
            tree.Add(10);
            tree.Add(5);

            int[] expectedResult = { 5, 10, 15, 20, 25, 26, 30 };
            TreeAsserts<int>(expectedResult, tree);
        }

        [TestMethod]
        public void RootCases()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(5);
            tree.Add(10);
            tree.Add(15);

            int[] expectedResult = { 5, 10, 15 };
            TreeAsserts<int>(expectedResult, tree);

            tree.Clear();
            tree.Add(5);
            tree.Add(-5);
            tree.Add(-15);

            expectedResult = new int[]{ -15, -5, 5 };
            TreeAsserts<int>(expectedResult, tree);

            tree.Clear();
            tree.Add(15);
            tree.Add(-5);
            tree.Add(5);

            expectedResult = new int[] { -5, 5, 15 };
            TreeAsserts<int>(expectedResult, tree);

            tree.Clear();
            tree.Add(5);
            tree.Add(15);
            tree.Add(6);

            expectedResult = new int[] { 5, 6, 15 };
            TreeAsserts<int>(expectedResult, tree);
        }

        [TestMethod]
        public void InternalCase_1() 
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(20);
            tree.Add(4);
            tree.Add(26);
            tree.Add(3);
            tree.Add(9);
            tree.Add(15);

            var expectedResult = new int[] { 3, 4, 9, 15, 20, 26 };
            TreeAsserts<int>(expectedResult, tree);
        }

        [TestMethod]
        public void InternalCase_2()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(20);
            tree.Add(4);
            tree.Add(26);
            tree.Add(3);
            tree.Add(9);
            tree.Add(21);
            tree.Add(30);
            tree.Add(2);
            tree.Add(7);
            tree.Add(11);
            tree.Add(15);

            var expectedResult = new int[] { 2, 3, 4, 7, 9, 11, 15, 20, 21, 26, 30 };
            TreeAsserts<int>(expectedResult, tree);
        }
        
        [TestMethod]
        public void AddToDataTestWithRndNumbers()
        {
            AVLTree<int> tree = new AVLTree<int>();
            int[] expectedResult = new int[10000];
            Random rnd = new Random();

            for (int i = 0; i < 10000; i++)
            {
                int currentRnd = rnd.Next(i * 10, i * 10 + 10); // assure we don't duplicate values.
                tree.Add(currentRnd);
                expectedResult[i] = currentRnd;
            }

            Array.Sort(expectedResult);
            TreeAsserts<int>(expectedResult, tree);
        }

        [TestMethod]
        public void RemoveingLeafs() 
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            tree.Add(7);
            tree.Add(8);
            tree.Add(9);

            tree.Remove(1);
            TreeAsserts<int>(new int[] { 2, 3, 4, 5, 6, 7, 8, 9 }, tree);
            tree.Remove(3);
            TreeAsserts<int>(new int[] { 2, 4, 5, 6, 7, 8, 9 }, tree);
            tree.Remove(9);
            TreeAsserts<int>(new int[] { 2, 4, 5, 6, 7, 8 }, tree);
            tree.Remove(7);
            TreeAsserts<int>(new int[] { 2, 4, 5, 6, 8 }, tree);
            tree.Remove(8);
            TreeAsserts<int>(new int[] { 2, 4, 5, 6 }, tree);
            tree.Remove(2);
            TreeAsserts<int>(new int[] { 4, 5, 6 }, tree);
            tree.Remove(4);
            TreeAsserts<int>(new int[] { 5, 6 }, tree);
            tree.Remove(6);
            TreeAsserts<int>(new int[] { 5 }, tree);
            tree.Remove(5);
            TreeAsserts<int>(new int[] { }, tree);
        }

        [TestMethod]
        public void RemoveOneChildNodes() 
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(-1);

            tree.Remove(1); // one left child
            TreeAsserts<int>(new int[] { -1, 2, 3 }, tree);
            tree.Add(4);
            tree.Remove(3); // one right child
            TreeAsserts<int>(new int[] { -1, 2, 4 }, tree);
        }

        [TestMethod]
        public void RemoveOneChildNodes_BiggerTree()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            tree.Add(7);
            tree.Add(8);
            tree.Add(9);
            tree.Add(10);

            tree.Remove(9); // one child on the right
            TreeAsserts<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10}, tree);
            tree.Remove(3);
            TreeAsserts<int>(new int[] { 1, 2, 4, 5, 6, 7, 8, 10 }, tree);
            tree.Remove(2); // one child on the left + some rotations back up the tree!
            TreeAsserts<int>(new int[] { 1, 4, 5, 6, 7, 8, 10 }, tree);
        }

        [TestMethod]
        public void RemoveInternalAndRootNodes() 
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            
            tree.Remove(8);
            TreeAsserts<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 10 }, tree);
            tree.Remove(7);
            TreeAsserts<int>(new int[] { 1, 2, 3, 4, 5, 6, 9, 10 }, tree);
            tree.Remove(6);
            TreeAsserts<int>(new int[] { 1, 2, 3, 4, 5, 9, 10 }, tree);
            tree.Remove(1);
            TreeAsserts<int>(new int[] { 2, 3, 4, 5, 9, 10 }, tree);
            tree.Remove(3);
            TreeAsserts<int>(new int[] { 2, 4, 5, 9, 10 }, tree);
            tree.Remove(4);
            TreeAsserts<int>(new int[] { 2, 5, 9, 10 }, tree);
            tree.Remove(9);
            TreeAsserts<int>(new int[] { 2, 5, 10 }, tree);
            tree.Remove(5);
            TreeAsserts<int>(new int[] { 2, 10 }, tree);
            tree.Remove(2);
            TreeAsserts<int>(new int[] { 10 }, tree);
            tree.Remove(10);
            //TreeAsserts<int>(new int[] { }, tree);
        }

        [TestMethod]
        public void RemoveOnlyRoot() 
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            var expectedResult = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            tree.Remove(9);
            expectedResult.Remove(9);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(8);
            expectedResult.Remove(8);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(7);
            expectedResult.Remove(7);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(6);
            expectedResult.Remove(6);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(5);
            expectedResult.Remove(5);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(4);
            expectedResult.Remove(4);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(3);
            expectedResult.Remove(3);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(13);
            expectedResult.Remove(13);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(12);
            expectedResult.Remove(12);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(11);
            expectedResult.Remove(11);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(10);
            expectedResult.Remove(10);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(2);
            expectedResult.Remove(2);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(15);
            expectedResult.Remove(15);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(14);
            expectedResult.Remove(14);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(1);
            expectedResult.Remove(1);
            TreeAsserts(expectedResult.ToArray(), tree);
            tree.Remove(1);
            expectedResult.Remove(1);
            TreeAsserts(expectedResult.ToArray(), tree);
        }

        [TestMethod]
        public void ContainsTest()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            Assert.AreEqual(true, tree.Contains(5));
            Assert.AreEqual(true, tree.Contains(9));
            Assert.AreEqual(true, tree.Contains(4));
            Assert.AreEqual(true, tree.Contains(1));
            Assert.AreEqual(true, tree.Contains(16));
            Assert.AreEqual(false, tree.Contains(-5));
        }

        [TestMethod]
        public void EnumeratorTes()
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

            int counter = 1;
            foreach (var item in tree)
            {
                Assert.AreEqual(counter, item);
                counter++;
            }
        }

        private static void TreeAsserts<T>(T[] expectedResult, AVLTree<T> tree)
            where T : IComparable<T>
        {
            if (expectedResult.Length == 0)
            {
                CollectionAssert.AreEqual(expectedResult, tree.ToArray());
                Assert.AreEqual(expectedResult.ElementsToString(" "), "[  ]");
                Assert.AreEqual(expectedResult.Length, tree.Count);
            }
            else 
            {
                CollectionAssert.AreEqual(expectedResult, tree.ToArray());
                Assert.AreEqual(expectedResult.ElementsToString(" "), "[ " + tree.ToString() + "]");
                Assert.AreEqual(expectedResult.Length, tree.Count);
                Assert.AreEqual(true, tree.ParentCheck());
                Assert.AreEqual(true, tree.LevelCheck());
            }
        }
    }
}
