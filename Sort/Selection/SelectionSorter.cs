using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Selection {
    /// <summary>
    /// Implement the selection sorting algorithm.
    /// Asymptotic complexity is O(n2).
    /// Main idea: on the each iteration step - find the smallest element of the range. Swap it
    /// with the most left element of the range. Perform the next iteration step with the range, starting
    /// from the second element of the current.
    /// </summary>
    /// <typeparam name="T">Type of the values to be sorted.</typeparam>
    public class SelectionSorter<T> : SorterBase<T> where T : IComparable {
        /// <summary>
        /// Base constructor. Initializes the empty class with empty data container.
        /// </summary>
        public SelectionSorter() {}

        /// <summary>
        /// Base constructor. Initializes the container with initial data array.
        /// </summary>
        /// <param name="initArray">Data array, contains all the elements for initializing.</param>
        public SelectionSorter(T[] initArray) : base(initArray) {}

        /// <inheritdoc cref="ISorter{T}.GetSorted"/>
        public override T[] GetSorted() {
            for (var mainIndex = 0; mainIndex < Container.Length - 1; mainIndex++) {
                var minIndex = mainIndex;
                for (var reducedArrayIndex = mainIndex + 1;
                    reducedArrayIndex < Container.Length;
                    reducedArrayIndex++) {
                    if (IsSmaller(reducedArrayIndex, minIndex)) {
                        minIndex = reducedArrayIndex;
                    }
                }
                if (minIndex != mainIndex) {
                    Swap(Container, mainIndex, minIndex);
                }
            }
            return Container;
        }
    }
}