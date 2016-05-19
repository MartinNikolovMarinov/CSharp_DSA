using System;
using LinearDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class SortWordsTests
    {
        [TestMethod]
        public void SortWordsTest()
        {
            string input1 = "wow softuni alpha";
            input1 = WordSorting.SortWords(input1);
            Assert.AreEqual("alpha softuni wow", input1);

            string input2 = "hi";
            input2 = WordSorting.SortWords(input2);
            Assert.AreEqual("hi", input2);

            string input3 = "rakiya beer wine vodka whiskey";
            input3 = WordSorting.SortWords(input3);
            Assert.AreEqual("beer rakiya vodka whiskey wine", input3);
        }
    }
}
