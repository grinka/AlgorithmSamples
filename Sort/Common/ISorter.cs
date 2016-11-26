using System;

namespace Algorithm.Sort.Common {
    /// <summary>
    /// Performs abstract algorithm of sorting.
    /// </summary>
    /// <typeparam name="T">Type of the values to be sorted.</typeparam>
    public interface ISorter<T> where T : IComparable {
        /// <summary>
        /// Adds one item to the array. The item is added at the tail of the array.
        /// Array size is raised if needed.
        /// </summary>
        /// <param name="item">Value to be added.</param>
        void AddItem(T item);

        /// <summary>
        /// Adds the range of the items to the array. The range is added at the tail
        /// of the array. Array size is raised if needed.
        /// </summary>
        /// <param name="range">The array of items to be added.</param>
        void AddRange(T[] range);

        /// <summary>
        /// Returns the content of the array sorted in ascending order.
        /// </summary>
        /// <returns></returns>
        T[] GetSorted();
    }
}