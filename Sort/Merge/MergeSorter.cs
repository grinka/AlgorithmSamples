using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Merge {
    public class MergeSorter<T> : SorterBase<T> where T : IComparable {
        public MergeSorter() {}

        public MergeSorter(T[] initArray) : base(initArray) {}

        public override T[] GetSorted() {
            MergeSort(new T[Container.Length], 0, Container.Length - 1);
            return Container;
        }

        /** 
         * Merge sort (descending order)
         * @param Container Container to be sorted
         * @param aux auxiliary array of the same size as Container
         * @param left first index, which can be touched
         * @param right last index, which can be touched
         */

        public void MergeSort(T[] aux, int left, int right) {
            if (left == right) return;
            int middleIndex = (left + right)/2;
            MergeSort(aux, left, middleIndex);
            MergeSort(aux, middleIndex + 1, right);
            Merge(aux, left, right);

            for (int i = left; i <= right; i++)
            {
                Container[i] = aux[i];
            }
        }

        /**
         * Merge procedure for merge sort
         * @param Container Container to be merged
         * @param aux auxiliary array of the same size as Container
         * @param left first index, which can be touched
         * @param right last index, which can be touched
         */

        private void Merge(T[] aux, int left, int right) {
            int middleIndex = (left + right)/2;
            int leftIndex = left;
            int rightIndex = middleIndex + 1;
            int auxIndex = left;
            while (leftIndex <= middleIndex && rightIndex <= right) {
                if (IsBiggerOrEqual(leftIndex, rightIndex)) {
                    aux[auxIndex] = Container[leftIndex++];
                } else {
                    aux[auxIndex] = Container[rightIndex++];
                }
                auxIndex++;
            }
            while (leftIndex <= middleIndex) {
                aux[auxIndex] = Container[leftIndex++];
                auxIndex++;
            }
            while (rightIndex <= right) {
                aux[auxIndex] = Container[rightIndex++];
                auxIndex++;
            }
        }
    }
}