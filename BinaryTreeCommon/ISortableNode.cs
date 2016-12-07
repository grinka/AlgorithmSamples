namespace AlgorithmSamples.BinaryTree.Common {
    /// <summary>
    /// Node to be used with sorting binary tree.
    /// </summary>
    /// <typeparam name="T">Type of the object to be stored with the node.</typeparam>
    public interface ISortableNode<T> {
        /// <summary>
        /// Sort the node and it's child in ascending order. Return the result in one-dimensional array.
        /// </summary>
        T[] SortedAscending { get; }

        /// <summary>
        /// Sort the node and it's child in descending order. Return the result in one-dimensional array.
        /// </summary>
        T[] SortedDescending { get; }

        /// <summary>
        /// Add the value to the corresponding node child.
        /// </summary>
        /// <param name="value"></param>
        void AddValue(T value);

        /// <summary>
        /// Gets the Node size - quantity of the node's descendants.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Gets the flag indicating whatever node is empty - has no descendants.
        /// </summary>
        bool IsEmpty { get; }
    }
}