using System;

namespace Algorithm.Sort.Common {
    public abstract class SorterBase<T> : ISorter<T> where T : IComparable {
        protected T[] Container;

        /// <summary>
        /// Base constructor. Initializes the empty class with empty data container.
        /// </summary>
        protected SorterBase() {
            Container = new T[0];
        }

        /// <summary>
        /// Base constructor. Initializes the container with initial data array.
        /// </summary>
        /// <param name="initArray">Data array, contains all the elements for initializing.</param>
        protected SorterBase(T[] initArray) {
            Container = new T[initArray.Length];
            initArray.CopyTo(Container, 0);
        }

        /// <inheritdoc cref="ISorter{T}.AddItem"/>
        public void AddItem(T item) {
            var storeArray = new T[Container.Length + 1];
            Container.CopyTo(storeArray, 0);
            storeArray[Container.Length] = item;
            Container = storeArray;
        }

        /// <inheritdoc cref="ISorter{T}.AddRange"/>
        public void AddRange(T[] range) {
            var storeArray = new T[Container.Length + range.Length];
            Container.CopyTo(storeArray, 0);
            range.CopyTo(storeArray, Container.Length);
            Container = storeArray;
        }

        /// <summary>
        /// Swaps two elements in the array using their indexes.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="a">Index of the first element to be swapped.</param>
        /// <param name="b">Index of the second element to be swapped.</param>
        protected void Swap(T[] array, int a, int b) {
            if (a >= array.Length || a < 0 || b >= array.Length || b < 0) {
                throw new IndexOutOfRangeException();
            }

            if (a == b) {
                return;
            }

            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        /// <summary>
        /// Returns the value indicating if the item in the container with index <see cref="idx1"/>
        /// is bigger than item in the container with index <see cref="idx2"/>
        /// </summary>
        /// <param name="idx1">Index of the element to be compared.</param>
        /// <param name="idx2">Index of the element to be compared with.</param>
        /// <returns>true if element with first index is bigger than the element with second 
        /// index.</returns>
        protected bool IsBibber(int idx1, int idx2) {
            return Container[idx1].CompareTo(Container[idx2]) > 0;
        }

        /// <summary>
        /// Returns the value indicating if the item in the container with index <see cref="idx1"/>
        /// is bigger than or equal to the item in the container with index <see cref="idx2"/>
        /// </summary>
        /// <param name="idx1">Index of the element to be compared.</param>
        /// <param name="idx2">Index of the element to be compared with.</param>
        /// <returns>true if element with first index is bigger than or equal to the element with 
        /// second index.</returns>
        protected bool IsBibberOrEqual(int idx1, int idx2) {
            return Container[idx1].CompareTo(Container[idx2]) >= 0;
        }

        /// <summary>
        /// Returns the value indicating if the item in the container with index <see cref="idx1"/>
        /// is smaller than the item in the container with index <see cref="idx2"/>
        /// </summary>
        /// <param name="idx1">Index of the element to be compared.</param>
        /// <param name="idx2">Index of the element to be compared with.</param>
        /// <returns>true if element with first index is smaller than the element with 
        /// second index.</returns>
        protected bool IsSmaller(int idx1, int idx2) {
            return Container[idx1].CompareTo(Container[idx2]) < 0;
        }

        /// <summary>
        /// Returns the value indicating if the item in the container with index <see cref="idx1"/>
        /// is equal to the item in the container with index <see cref="idx2"/>
        /// </summary>
        /// <param name="idx1">Index of the element to be compared.</param>
        /// <param name="idx2">Index of the element to be compared with.</param>
        /// <returns>true if element with first index is equal to the element with 
        /// second index.</returns>
        protected bool IsEqual(int idx1, int idx2) {
            return Container[idx1].CompareTo(Container[idx2]) == 0;
        }

        /// <inheritdoc cref="ISorter{T}.GetSorted"/>
        public abstract T[] GetSorted();
    }
}