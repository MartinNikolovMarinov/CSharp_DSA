using System;
using LinearDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class OccurrencesCountTests
    {
        [TestMethod]
        public void OccurrencesCountTest() 
        {
            int[] arr = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            string result = CountOfOccurences.CountOccurences(arr);
            Assert.AreEqual("2 -> 2 times\r\n" + 
                            "3 -> 4 times\r\n" + 
                            "4 -> 3 times", result);

            arr = new int[] { 1000 };
            result = CountOfOccurences.CountOccurences(arr);
            Assert.AreEqual("1000 -> 1 times", result);

            arr = new int[] { 0, 0, 0 };
            result = CountOfOccurences.CountOccurences(arr);
            Assert.AreEqual("0 -> 3 times", result);

            arr = new int[] { 7, 6, 5, 5, 6 };
            result = CountOfOccurences.CountOccurences(arr);
            Assert.AreEqual("5 -> 2 times\r\n" + 
                            "6 -> 2 times\r\n" + 
                            "7 -> 1 times", result);
        }
    }
}
