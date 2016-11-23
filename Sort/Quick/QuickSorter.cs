using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Quick {
    public class QuickSorter<T> : SorterBase<T> where T : IComparable {
        public QuickSorter() {}

        public QuickSorter(T[] initArray) : base(initArray) {}

        public override T[] GetSorted() {
            var sorted = new T[Container.Length];
            Container.CopyTo(sorted, 0);
            QuickSort(sorted, 0, sorted.Length - 1);
            return sorted;
        }

        private void QuickSort(T[] elements, int leftIndex, int rightIndex) {
            int i = leftIndex, j = rightIndex;
            var pivot = elements[(leftIndex + rightIndex)/2];

            while (i <= j) {
                while (elements[i].CompareTo(pivot) < 0) {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0) {
                    j--;
                }

                if (i <= j) {
                    Swap(elements, i, j);

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (leftIndex < j) {
                QuickSort(elements, leftIndex, j);
            }

            if (i < rightIndex) {
                QuickSort(elements, i, rightIndex);
            }
        }
    }
}