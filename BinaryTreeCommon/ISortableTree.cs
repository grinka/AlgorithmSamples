namespace AlgorithmSamples.BinaryTree.Common
{
    public interface ISortableTree<T> {
        /// <summary>
        /// Gets the content of the tree in ascending order.
        /// </summary>
        T[] SortedAscending { get; }
        /// <summary>
        /// Gets the content of the tree in descending order.
        /// </summary>
        T[] SortedDescending { get; }

        /// <summary>
        /// Add the new value to the tree. If tree does not have any nodes,
        /// the root node with given value is created.
        /// </summary>
        /// <param name="value">The object to be added to the tree.</param>
        void Insert(T value);

        /// <summary>
        /// Add the group of values value to the tree. If tree does not have any nodes,
        /// the root node is created.
        /// </summary>
        /// <param name="values">The array of the objects to be added to the tree.</param>
        void Insert(T[] values);
    }
}
