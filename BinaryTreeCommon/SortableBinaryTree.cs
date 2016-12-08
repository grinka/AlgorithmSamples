namespace AlgorithmSamples.BinaryTree.Common
{
    /// <summary>
    /// Binary tree allows sorting. Has a reference to the root child node, 
    /// Ascending and Descending sorging properties and method to add the new value.
    /// Method to create the new node should be overwriten.
    /// </summary>
    /// <typeparam name="T">Type of the value to be stored in the tree nodes.</typeparam>
    public abstract class SortableBinaryTree<T> : ISortableTree<T> {
        /// <summary>
        /// The root tree node.
        /// </summary>
        protected ISortableNode<T> RootNode;

        /// <inheritdoc cref="ISortableTree{T}.SortedAscending"/>
        public T[] SortedAscending => RootNode.SortedAscending;

        /// <inheritdoc cref="ISortableTree{T}.SortedDescending"/>
        public T[] SortedDescending => RootNode.SortedDescending;

        /// <inheritdoc cref="ISortableTree{T}.Insert(T)"/>
        public void Insert(T[] values) {
            foreach (var value in values) {
                Insert(value);
            }
        }

        /// <inheritdoc cref="ISortableTree{T}.Insert(T)"/>
        public void Insert(T value) {
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