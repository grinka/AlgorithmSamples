namespace AlgorithmSamples.BinaryTreeCommon {
    using System;

    /// <summary>
    /// Implements the ISortableNode interface - allows to get the sorted list of descendants.
    /// </summary>
    /// <typeparam name="T">Type of the objects to be stored by a node.</typeparam>
    public class SortableBinaryTreeNode<T> : ISortableNode<T> {
        #region Local fields

        /// <summary>
        /// The value to be stored by the node.
        /// </summary>
        protected T Value;

        /// <inheritdoc cref="ISortableNode{T}.IsEmpty"/>
        public int Size => (LeftChild?.Size ?? 0) + 1 + (RightChild?.Size ?? 0);

        /// <summary>
        /// Reference to the left child node.
        /// </summary>
        protected SortableBinaryTreeNode<T> LeftChild;

        /// <summary>
        /// Reference to the right child node.
        /// </summary>
        protected SortableBinaryTreeNode<T> RightChild;

        /// <inheritdoc cref="ISortableNode{T}.IsEmpty"/>
        public bool IsEmpty => LeftChild == null && RightChild == null;

        #endregion

        /// <summary>
        /// Initializes new node instance with given value of <see cref="T"/>.
        /// </summary>
        /// <param name="value">Object value to be stored by the node.</param>
        protected SortableBinaryTreeNode(T value) {
            Value = value;
        }

        /// <summary>
        /// Gets the sorted list of children nodes including the current one.
        /// Method collect the values from the first part, current node and 
        /// then second part.
        /// If nodes should be sorted in ascending order, the left child is used
        /// as the first and right - as the second. To sort them in descending order,
        /// use the right node as a first and left as a second.
        /// </summary>
        /// <param name="firstPart">First descendant node to gather ordered values.</param>
        /// <param name="secondPart">Second descendant node to gather ordered values.</param>
        /// <param name="sortedFunc">The function to be used to sort descendants. It could be
        /// <see cref="SortedAsc"/> or <see cref="SortedDesc"/>.</param>
        /// <returns></returns>
        private T[] GetSorted(
            SortableBinaryTreeNode<T> firstPart,
            SortableBinaryTreeNode<T> secondPart,
            Func<SortableBinaryTreeNode<T>, T[]> sortedFunc) {
            var returnValue = new T[Size];
            var idx = 0;
            if (firstPart != null) {
                var firstPartArray = sortedFunc(firstPart);
                firstPartArray.CopyTo(returnValue, idx);
                idx += firstPartArray.Length;
            }
            returnValue[idx++] = Value;
            sortedFunc(secondPart)?.CopyTo(returnValue, idx);
            return returnValue;
        }

        /// <summary>
        /// Returns the subtree content (node values) in ascending order.
        /// Private method to be launched in the chain - uses the <see cref="GetSorted"/>
        /// with left child as a first and right child as a second descendant. Propagate
        /// itself as a sorting function for these child nodes.
        /// </summary>
        /// <param name="node">Parent node of the subtree.</param>
        /// <returns>Array of the subtree node values ordered in ascending order.</returns>
        private static T[] SortedAsc(SortableBinaryTreeNode<T> node)
            => node?.GetSorted(node.LeftChild, node.RightChild, SortedAsc);

        /// <summary>
        /// Returns the subtree content (node values) in descending order.
        /// Private method to be launched in the chain - uses the <see cref="GetSorted"/>
        /// with right child as a first and left child as a second descendant. Propagate
        /// itself as a sorting function for these child nodes.
        /// </summary>
        /// <param name="node">Parent node of the subtree.</param>
        /// <returns>Array of the subtree node values ordered in descending order.</returns>
        private static T[] SortedDesc(SortableBinaryTreeNode<T> node)
            => node?.GetSorted(node.RightChild, node.LeftChild, SortedDesc);

        /// <inheritdoc cref="ISortableNode{T}.SortedAscending"/>
        public T[] SortedAscending => SortedAsc(this);

        /// <inheritdoc cref="ISortableNode{T}.SortedDescending"/>
        public T[] SortedDescending => SortedDesc(this);

        /// <inheritdoc cref="ISortableNode{T}.AddValue"/>
        public virtual void AddValue(T value) {
            Value = value;
        }
    }
}