using System;
using LinearDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddingElements()
        {
            LinkedList<string> test = new LinkedList<string>();
            test.Add("test1");
            test.Add("test2");
            test.Add("test3");
            test.Add("test4");
            test.Add("test5");
            test.Add("test6");
            test.Add("test7");
            test.Add("test8");

            string[] result = test.ToArray();

            CollectionAssert.AreEqual(new string[] 
                {
                    "test1", 
                    "test2", 
                    "test3",
                    "test4", 
                    "test5",
                    "test6",
                    "test7",
                    "test8"
                }, result);
        }

        [TestMethod]
        public void FirstAndLastIndex()
        {
            LinkedList<int> test = new LinkedList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(2);
            test.Add(3);

            Assert.AreEqual(2, test.LastIndexOf(2));
            Assert.AreEqual(1, test.FirstIndexOf(2));

            Assert.AreEqual(-1, test.LastIndexOf(7));
            Assert.AreEqual(-1, test.FirstIndexOf(7));
        }

        [TestMethod]
        public void RemoveTests()
        {
            LinkedList<int> test = new LinkedList<int>();
            test.Add(1);
            test.Add(2);

            test.Remove(1);
            Assert.AreEqual(2, test.ElementAt(0));
            Assert.AreEqual(1, test.Length);

            test.Remove(2);
            Assert.AreEqual(0, test.Length);

            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);

            test.Remove(1);
            CollectionAssert.AreEqual(new int[] {2, 3, 4, 5, 6}, test.ToArray());
            Assert.AreEqual(5, test.Length);

            test.Remove(6);
            CollectionAssert.AreEqual(new int[] { 2, 3, 4, 5}, test.ToArray());
            Assert.AreEqual(4, test.Length);

            test.Remove(4);
            CollectionAssert.AreEqual(new int[] { 2, 3, 5 }, test.ToArray());
            Assert.AreEqual(3, test.Length);

            test.Remove(3);
            CollectionAssert.AreEqual(new int[] { 2, 5 }, test.ToArray());
            Assert.AreEqual(2, test.Length);

            test.Remove(5);
            CollectionAssert.AreEqual(new int[] { 2}, test.ToArray());
            Assert.AreEqual(1, test.Length);
        }
    }
}
