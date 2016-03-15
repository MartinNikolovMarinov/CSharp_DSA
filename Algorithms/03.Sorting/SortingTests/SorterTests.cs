namespace Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Sorting;

    [TestClass]
    public class SorterTests
    {
        private class SortTester
        {
            public Action<int[]> sortIntsFn = null;

            public void RunAllTests_int()
            {
                if (sortIntsFn != null)
                {
                    this.TestOne_int();
                    this.TestOne_int();
                    this.TestThree_int();
                    this.TestFour_int();
                    this.TestFive_int();
                    this.TestSix_rnd_int();
                }
            }

            private void TestOne_int()
            {
                int[] arr = { 1, 2, 3, 4 };
                int[] expected = { 1, 2, 3, 4 };
                sortIntsFn(arr);
                CollectionAssert.AreEqual(expected, arr);
            }

            private void TestTwo_int()
            {
                int[] arr = { 4, 3, 2, -1, 0 };
                int[] expected = { -1, 0, 2, 3, 4 };
                sortIntsFn(arr);
                CollectionAssert.AreEqual(expected, arr);
            }

            private void TestThree_int()
            {
                int[] arr = { 69, 47, 66, 15, 66, 89, 44, 60, 53, 66, 11, 78, 8, 29, 22 };
                int[] expected = { 8, 11, 15, 22, 29, 44, 47, 53, 60, 66, 66, 66, 69, 78, 89 };
                sortIntsFn(arr);
                CollectionAssert.AreEqual(expected, arr);
            }

            private void TestFour_int()
            {
                int[] arr = { };
                int[] expected = { };
                sortIntsFn(arr);
                CollectionAssert.AreEqual(expected, arr);
            }

            private void TestFive_int()
            {
                int[] arr = { 2 };
                int[] expected = { 2 };
                sortIntsFn(arr);
                CollectionAssert.AreEqual(expected, arr);
            }

            private void TestSix_rnd_int()
            {
                Random rnd = new Random();
                int[] arr = new int[5000];
                for (int i = 0; i < arr.Length; i++)
                {
                    int current = rnd.Next(-1000, 1000);
                    arr[i] = current;
                }

                int[] expected = arr.OrderBy(x => x).ToArray();
                sortIntsFn(arr);
                CollectionAssert.AreEqual(expected, arr);
            }
        }

        SortTester sortTester = new SortTester();

        [TestMethod]
        public void SelectionSortTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.SelectionSort;
            sortTester.RunAllTests_int();
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.BubbleSort;
            sortTester.RunAllTests_int();
        }

        [TestMethod]
        public void QuickSortRndPivotTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.QuickSort;
            sr.QuickSortPivotType = PivotType.Rnd;
            sortTester.RunAllTests_int();
        }

        [TestMethod]
        public void QuickSortHiPivotTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.QuickSort;
            sr.QuickSortPivotType = PivotType.Hi;
            sortTester.RunAllTests_int();
        }

        [TestMethod]
        public void QuickSortLowPivotTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.QuickSort;
            sr.QuickSortPivotType = PivotType.Low;
            sortTester.RunAllTests_int();
        }

        [TestMethod]
        public void MergeSortTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.MergeSort;
            sortTester.RunAllTests_int();
        }

        [TestMethod]
        public void HeapSortTest()
        {
            var sr = new Sorter<int>();
            sortTester.sortIntsFn = sr.HeapSort;
            sortTester.RunAllTests_int();
        }
    }
}
