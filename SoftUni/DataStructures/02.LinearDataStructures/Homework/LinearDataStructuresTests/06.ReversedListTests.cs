using System;
using LinearDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class ReversedListTests
    {
        [TestMethod]
        public void AddingAndIterationTest() 
        {
            ReversedList<int> rlist = new ReversedList<int>();
            rlist.Add(0);
            rlist.Add(1);
            rlist.Add(2);
            rlist.Add(3);

            Assert.AreEqual(3, rlist[0]);
            Assert.AreEqual(2, rlist[1]);
            Assert.AreEqual(1, rlist[2]);
            Assert.AreEqual(0, rlist[3]);
            Assert.AreEqual(4, rlist.Count);
            Assert.AreEqual(4, rlist.Capacity);

            rlist.Add(5);
            rlist.Add(6);
            Assert.AreEqual(6, rlist.Count);
            Assert.AreEqual(8, rlist.Capacity);
        }

        [TestMethod]
        public void RemoveTest()
        {
            ReversedList<int> rlist = new ReversedList<int>();
            rlist.Add(0);
            rlist.Add(1);
            rlist.Add(2);
            rlist.Add(3);

            rlist.Remove(0);

            Assert.AreEqual(2, rlist[0]);
            Assert.AreEqual(1, rlist[1]);
            Assert.AreEqual(0, rlist[2]);
            Assert.AreEqual(3, rlist.Count);
            Assert.AreEqual(4, rlist.Capacity);
        }

        [TestMethod]
        public void EnumerationTest()
        {
            ReversedList<string> rlist = new ReversedList<string>();
            rlist.Add("4444");
            rlist.Add("3333");
            rlist.Add("2222");

            List<string> result = new List<string>();
            foreach (var item in rlist)
            {
                result.Add(item);
            }

            Assert.AreEqual("2222", result[0]);
            Assert.AreEqual("3333", result[1]);
            Assert.AreEqual("4444", result[2]);
            Assert.AreEqual(3, rlist.Count);
            Assert.AreEqual(4, rlist.Capacity);
        }
    }
}
