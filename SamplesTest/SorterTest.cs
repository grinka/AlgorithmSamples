using System;
using System.CodeDom;
using Algorithm.Sort.Bobble;
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
            Assert.IsTrue(EqualArrays(sorted, array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddRangeAll() {
            var sorter = new BobbleSorter<int>();
            sorter.AddRange(InitArray1);
            var sorted = sorter.GetSorted();
            Assert.IsTrue(EqualArrays(sorted, array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddRangeByHalf() {
            var sorter = new BobbleSorter<int>(InitArray1Half1);
            sorter.AddRange(Initarray1Half2);
            var sorted = sorter.GetSorted();
            Assert.IsTrue(EqualArrays(sorted, array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddItemsAll() {
            var sorter = new BobbleSorter<int>();
            foreach (var item in InitArray1) {
                sorter.AddItem(item);
            }

            var sorted = sorter.GetSorted();
            Assert.IsTrue(EqualArrays(sorted, array1SortedAsc));
        }

        [TestCategory("Sorting.Bobble")]
        [TestMethod]
        public void TestBobbleSorting1_AddItemsByHalf() {
            var sorter = new BobbleSorter<int>(InitArray1Half1);
            foreach (var item in Initarray1Half2) {
                sorter.AddItem(item);
            }

            var sorted = sorter.GetSorted();
            Assert.IsTrue(EqualArrays(sorted, array1SortedAsc));
        }

        private bool EqualArrays(int[] a1, int[] a2) {
            if (a1.Length != a2.Length) {
                return false;
            }
            for (var idx = 0; idx < a1.Length; idx++) {
                if (a1[idx] != a2[idx]) {
                    return false;
                }
            }
            return true;
        }
    }
}