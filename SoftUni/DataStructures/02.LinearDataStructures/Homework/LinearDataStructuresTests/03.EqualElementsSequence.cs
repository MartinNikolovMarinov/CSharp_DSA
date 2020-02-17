using System;
using LinearDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearDataStructuresTests
{
    [TestClass]
    public class EqualElementsSequence
    {
        [TestMethod]
        public void EqualElementsSequenceTest()
        {
            int[] arr = { 12, 2, 7, 4, 3, 3, 8 };
            int[] result = LongestSubsequenceOfEqualElements.LongestSequenceOfEqualElements(arr);
            CollectionAssert.AreEqual(new int[] { 3, 3 }, result);

            arr = new int[] { 2, 2, 2, 3, 3, 3 };
            result = LongestSubsequenceOfEqualElements.LongestSequenceOfEqualElements(arr);
            CollectionAssert.AreEqual(new int[] { 2, 2, 2 }, result);

            arr = new int[] { 4, 4, 5, 5, 5 };
            result = LongestSubsequenceOfEqualElements.LongestSequenceOfEqualElements(arr);
            CollectionAssert.AreEqual(new int[] { 5, 5, 5 }, result);

            arr = new int[] { 1, 2, 3 };
            result = LongestSubsequenceOfEqualElements.LongestSequenceOfEqualElements(arr);
            CollectionAssert.AreEqual(new int[] { 1 }, result);

            arr = new int[] { 0 };
            result = LongestSubsequenceOfEqualElements.LongestSequenceOfEqualElements(arr);
            CollectionAssert.AreEqual(new int[] { 0 }, result);

            arr = new int[] { };
            result = LongestSubsequenceOfEqualElements.LongestSequenceOfEqualElements(arr);
            CollectionAssert.AreEqual(new int[] { }, result);
        }
    }
}
