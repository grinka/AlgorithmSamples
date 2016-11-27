using System;
using System.Collections.Generic;
using Algorithm.Sort.Bobble;
using Algorithm.Sort.Common;
using Algorithm.Sort.Heap;
using Algorithm.Sort.Insertion;
using Algorithm.Sort.Quick;
using Algorithm.Sort.Selection;
using Algorithm.Sort.Shell;
using Algorithm.Sort.Smooth;
using CommonExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTest {
    [TestClass]
    public class SorterTest {
        private int[] InitArray1 = {3, 12, 6, 55, -4, 7, 1, 1, 4, 28, 8};
        private int[] InitArray1Half1 = {3, 12, 6, 55, -4, 7};
        private int[] Initarray1Half2 = {1, 1, 4, 28, 8};
        private int[] InitArray2 = {66, 666, 5, 45, 28, 14};
        private int[] InitArray3 = {1, 2, 4, 6, 4, 6, 23, 15};
        private int[] ShellSorterTest = {2, 1, 5, 3, 4, 1, 2, 12};

        private int[] array1SortedAsc = {-4, 1, 1, 3, 4, 6, 7, 8, 12, 28, 55};
        private int[] array2SortedAsc = {5, 14, 28, 45, 66, 666};
        private int[] array3SortedAsc = {1, 2, 4, 4, 6, 6, 15, 23};
        private int[] ShellSorterResult = {1, 1, 2, 2, 3, 4, 5, 12};


        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1() {
            var sorter = new BobbleSorter<int>(InitArray1);
            var sorted = sorter.GetSorted();
            Assert.IsTrue(sorted.SameArray(array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddRangeAll() {
            var sorter = new BobbleSorter<int>();
            sorter.AddRange(InitArray1);
            var sorted = sorter.GetSorted();
            Assert.IsTrue(sorted.SameArray(array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddRangeByHalf() {
            var sorter = new BobbleSorter<int>(InitArray1Half1);
            sorter.AddRange(Initarray1Half2);
            var sorted = sorter.GetSorted();
            Assert.IsTrue(sorted.SameArray(array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddItemsAll() {
            var sorter = new BobbleSorter<int>();
            foreach (var item in InitArray1) {
                sorter.AddItem(item);
            }

            var sorted = sorter.GetSorted();
            Assert.IsTrue(sorted.SameArray(array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddItemsByHalf() {
            var sorter = new BobbleSorter<int>(InitArray1Half1);
            foreach (var item in Initarray1Half2) {
                sorter.AddItem(item);
            }

            var sorted = sorter.GetSorted();
            Assert.IsTrue(sorted.SameArray(array1SortedAsc));
        }

        [TestCategory("Sorting.Heap")]
        [TestMethod]
        public void TestHeapSorting1() {
            var sorter = new HeapSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Quick")]
        [TestMethod]
        public void TestQuickSorting1() {
            var sorter = new QuickSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSortingSpecial() {
            var sorter = new ShellSorter<int>(ShellSorterTest);
            Assert.IsTrue(ShellSorterResult.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSorting1() {
            var sorter = new ShellSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSorting2() {
            var sorter = new ShellSorter<int>(InitArray2);
            Assert.IsTrue(array2SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSorting3() {
            var sorter = new ShellSorter<int>(InitArray3);
            Assert.IsTrue(array3SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Selection")]
        [TestMethod]
        public void TestSelectionSorting1() {
            var sorter = new SelectionSorter<int>(InitArray1);
            var sortedSelection = sorter.GetSorted();
            Assert.IsTrue(array1SortedAsc.SameArray(sortedSelection));
        }

        [TestCategory("Sorting.Smooth")]
        [TestMethod]
        public void TestSmoothSorting1() {
            var sorter = new SmoothSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Insertion")]
        [TestMethod]
        public void TestInsertionSorting1() {
            var sorter = new InsertionSorter<int>(InitArray1);
            var result = sorter.GetSorted();
            Assert.IsTrue(array1SortedAsc.SameArray(result));
        }

        [TestCategory("Sorting.All")]
        [TestMethod]
        public void TestAllSorting() {
            var data = getRandomArray();
            var expectedData = new int[0];
            var sortersList = GetSorters<int>();
            foreach (var sorter in sortersList) {
                sorter.AddRange(data);
                var sortedResult = sorter.GetSorted();
                if (expectedData.Length != 0) {
                    Assert.IsTrue(expectedData.SameArray(sortedResult));
                } else {
                    expectedData = sortedResult;
                }
            }
        }

        private IList<SorterBase<T>> GetSorters<T>() where T : IComparable {
            return new List<SorterBase<T>> {
                new BobbleSorter<T>(),
                new QuickSorter<T>(),
                new ShellSorter<T>(),
                new SelectionSorter<T>()
            };
        }

        private int[] getRandomArray() {
            var rnd = new Random();
            var size = rnd.Next(20, 100);
            var ret = new int[size];
            for (int idx = 0; idx < size; idx++) {
                ret[idx] = rnd.Next(int.MaxValue);
            }
            return ret;
        }
    }
}