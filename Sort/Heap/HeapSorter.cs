using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Heap {
    public class HeapSorter<T> : SorterBase<T> where T : IComparable {
        private int _heapSize;

        public HeapSorter() {}

        public HeapSorter(T[] initArray) : base(initArray) {}

        /// <inheritdoc cref="SorterBase{T}.GetSorted"/>
        public override T[] GetSorted() {
            BuildHeap();
            for (var i = Container.Length - 1; i >= 0; i--) {
                Swap(Container, 0, i);
                _heapSize--;
                Heapify(0);
            }

            return Container;
        }

        /// <summary>
        /// Initially build the heap from the array.
        /// Uses same array - it will be changed. No additional memory needed.
        /// </summary>
        private void BuildHeap() {
            _heapSize = Container.Length - 1;
            for (var i = _heapSize/2; i >= 0; i--) {
                Heapify(i);
            }
        }

        /// <summary>
        /// Heapify the given item and it's "children" elements.
        /// </summary>
        /// <param name="index"></param>
        private void Heapify(int index) {
            var left = 2*index;
            var right = left + 1;
            var largest = index;

            if (left <= _heapSize && IsBigger(left, index)) {
                largest = left;
            }

            if (right <= _heapSize && IsBigger(right, largest)) {
                largest = right;
            }

            if (largest != index) {
                Swap(Container, index, largest);
                Heapify(largest);
            }
        }
    }
}