namespace AlgorithmSamples.BinaryTreeCommon
{
    /// <summary>
    /// Binary tree allows sorting. Has a reference to the root child node, 
    /// Ascending and Descending sorging properties and method to add the new value.
    /// Method to create the new node should be overwriten.
    /// </summary>
    /// <typeparam name="T">Type of the value to be stored in the tree nodes.</typeparam>
    public abstract class SortableBinaryTree<T> {
        /// <summary>
        /// The root tree node.
        /// </summary>
        protected ISortableNode<T> RootNode;

        /// <summary>
        /// Gets the content of the tree in ascending order.
        /// </summary>
        public T[] SortedAscending => RootNode.SortedAscending;
        /// <summary>
        /// Gets the content of the tree in descending order.
        /// </summary>
        public T[] SortedDescending => RootNode.SortedDescending;

        /// <summary>
        /// Add the new value to the tree. If tree does not have any nodes,
        /// the root node with given value is created.
        /// </summary>
        /// <param name="value">The object to be added to the tree.</param>
        public void AddValue(T value) {
            if (RootNode == null) {
                RootNode = CreateRootNode(value);
            } else {
                RootNode.AddValue(value);
            }
        }
        /// <summary>
        /// Abstract method used to create the root node.
        /// Override it with exact <see cref="ISortableNode{T}"/> implementation class.
        /// </summary>
        /// <param name="value">The value object to be stored in the root node.</param>
        /// <returns>The new created node of the type which implements <see cref="ISortableNode{T}"/> interface.</returns>
        protected abstract ISortableNode<T> CreateRootNode(T value);
    }
}