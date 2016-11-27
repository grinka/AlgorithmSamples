using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Sort.Merge;
using Algorithm.Sort.Shell;

namespace SortingTestConsole {
    class Program {
        static void Main(string[] args) {
            var sorter = new MergeSorter<int>(new int[] { 2, 1, 5, 3, 4, 1, 2, 12 });
            var ret = sorter.GetSorted();

            //var ret = new int[8];
            //MergeSort(new int[] {2, 1, 5, 3, 4, 1, 2, 12}, ret, 0, 7);
            Console.WriteLine(
                ret.Aggregate<int, string>(string.Empty, (item, str) => str + "," + item.ToString()));
            Console.ReadKey();
        }

/** 
                                 * Merge sort (descending order)
                                 * @param array array to be sorted
                                 * @param aux auxiliary array of the same size as array
                                 * @param left first index, which can be touched
                                 * @param right last index, which can be touched
                                 */

        public static void MergeSort(int[] array, int[] aux, int left, int right) {
            if (left == right) return;
            int middleIndex = (left + right)/2;
            MergeSort(array, aux, left, middleIndex);
            MergeSort(array, aux, middleIndex + 1, right);
            Merge(array, aux, left, right);

            for (int i = left; i <= right; i++) {
                array[i] = aux[i];
            }
        }

        /**
         * Merge procedure for merge sort
         * @param array array to be merged
         * @param aux auxiliary array of the same size as array
         * @param left first index, which can be touched
         * @param right last index, which can be touched
         */

        private static void Merge(int[] array, int[] aux, int left, int right) {
            int middleIndex = (left + right)/2;
            int leftIndex = left;
            int rightIndex = middleIndex + 1;
            int auxIndex = left;
            while (leftIndex <= middleIndex && rightIndex <= right) {
                if (array[leftIndex] >= array[rightIndex]) {
                    aux[auxIndex] = array[leftIndex++];
                } else {
                    aux[auxIndex] = array[rightIndex++];
                }
                auxIndex++;
            }
            while (leftIndex <= middleIndex) {
                aux[auxIndex] = array[leftIndex++];
                auxIndex++;
            }
            while (rightIndex <= right) {
                aux[auxIndex] = array[rightIndex++];
                auxIndex++;
            }
        }
    }
}