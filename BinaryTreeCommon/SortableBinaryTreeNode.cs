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

        private static T[] SortedAsc(SortableBinaryTreeNode<T> node)
            => node?.GetSorted(node.LeftChild, node.RightChild, SortedAsc);

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