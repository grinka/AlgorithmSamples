using System;
using System.CodeDom;
using System.Linq;
using Algorithm.Sort.Bobble;
using Algorithm.Sort.Heap;
using Algorithm.Sort.Quick;
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

        private int[] array1SortedAsc = {-4, 1, 1, 3, 4, 6, 7, 8, 12, 28, 55};
        private int[] array2SortedAsc = {5, 14, 28, 45, 66, 666};
        private int[] array3SortedAsc = {1, 2, 4, 4, 6, 6, 15, 23};

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
        public void TestQuickSorting1()
        {
            var sorter = new QuickSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSorting1()
        {
            var sorter = new ShellSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSorting2()
        {
            var sorter = new ShellSorter<int>(InitArray2);
            Assert.IsTrue(array2SortedAsc.SameArray(sorter.GetSorted()));
        }
        [TestCategory("Sorting.Shell")]
        [TestMethod]
        public void TestShellSorting3()
        {
            var sorter = new ShellSorter<int>(InitArray3);
            Assert.IsTrue(array3SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.Smooth")]
        [TestMethod]
        public void TestSmoothSorting1()
        {
            var sorter = new SmoothSorter<int>(InitArray1);
            Assert.IsTrue(array1SortedAsc.SameArray(sorter.GetSorted()));
        }

        [TestCategory("Sorting.All")]
        [TestMethod]
        public void TestAllSorting() {
            var data = getRandomArray();
            var bobbleSorter = new BobbleSorter<int>(data);
            var bobbleSortedResult = bobbleSorter.GetSorted();

            var quickSorter = new QuickSorter<int>(data);
            var quiskSorterResult = quickSorter.GetSorted();

            var shellSorter = new ShellSorter<int>(data);
            var shellSorterResult = shellSorter.GetSorted();

            Assert.IsTrue(bobbleSortedResult.SameArray(quiskSorterResult));
            Assert.IsTrue(quiskSorterResult.SameArray(shellSorterResult));
        }

        private int[] getRandomArray() {
            var rnd = new Random();
            var size = rnd.Next(2, 10);
            var ret = new int[size];
            for (int idx = 0; idx < size; idx++) {
                ret[idx] = rnd.Next(int.MaxValue);
            }
            return ret;
        }
    }
}