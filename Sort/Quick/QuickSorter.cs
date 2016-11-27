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

        private void QuickSort(T[] elements, int leftBorder, int rightBorder) {
            int leftIndex = leftBorder, rightIndex = rightBorder;
            // It's the base element - we try to sort all the items on the left and right parts
            // of this item.
            var pivot = elements[(leftBorder + rightBorder)/2];

            while (leftIndex <= rightIndex) {
                while (elements[leftIndex].CompareTo(pivot) < 0) {
                    leftIndex++;
                }

                while (elements[rightIndex].CompareTo(pivot) > 0) {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex) {
                    if (leftIndex < rightIndex) {
                        Swap(elements, leftIndex, rightIndex);
                    }
                    leftIndex++;
                    rightIndex--;
                }
            }

            // Recursive calls
            if (leftBorder < rightIndex) {
                QuickSort(elements, leftBorder, rightIndex);
            }

            if (leftIndex < rightBorder) {
                QuickSort(elements, leftIndex, rightBorder);
            }
        }
    }
}