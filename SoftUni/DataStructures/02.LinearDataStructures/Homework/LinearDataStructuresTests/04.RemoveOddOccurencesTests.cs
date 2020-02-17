using System;
using LinearDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class RemoveOddOccurencesTests
    {
        [TestMethod]
        public void RemoveOddOccurencesTest()
        {
            int[] arr = { 1, 2, 3, 4, 1 };
            arr = RemoveOddOccurences.RemoveNumbersWithOddOccurence(arr);
            CollectionAssert.AreEqual(new int[] { 1, 1 }, arr);

            arr = new int[] { 1, 2, 3, 4, 5, 3, 6, 7, 6, 7, 6 };
            arr = RemoveOddOccurences.RemoveNumbersWithOddOccurence(arr);
            CollectionAssert.AreEqual(new int[] { 3, 3, 7, 7 }, arr);

            arr = new int[] { 1, 2, 1, 2, 1, 2 };
            arr = RemoveOddOccurences.RemoveNumbersWithOddOccurence(arr);
            CollectionAssert.AreEqual(new int[] { }, arr);

            arr = new int[] { 3, 7, 3, 3, 4, 3, 4, 3, 7 };
            arr = RemoveOddOccurences.RemoveNumbersWithOddOccurence(arr);
            CollectionAssert.AreEqual(new int[] { 7, 4, 4, 7 }, arr);

            arr = new int[] { 1, 1 };
            arr = RemoveOddOccurences.RemoveNumbersWithOddOccurence(arr);
            CollectionAssert.AreEqual(new int[] { 1, 1 }, arr);

            arr = new int[] { };
            arr = RemoveOddOccurences.RemoveNumbersWithOddOccurence(arr);
            CollectionAssert.AreEqual(new int[] { }, arr);
        }
    }
}
