using System;
using AlgorithmSamples.BinaryTreeCommon;

namespace AlgorithmSamples.BinaryTreeSort {
    /// <summary>
    /// Simple node implementation to be used in the sortable tree.
    /// Contains the comparable value as a data object - so it can be used
    /// directly for sorting.
    /// It's a simple case of <see cref="NonComparableNode{T}"/> 
    /// where compare function is just (x) => x.
    /// </summary>
    /// <typeparam name="T">Type of the data to be stored in the node. 
    /// Should implement the <see cref="IComparable"/> interface to allow the 
    /// sorting.</typeparam>
    internal class Node<T> : SortableBinaryTreeNode<T> where T : IComparable {
        #region Constructors
        public Node(T value) : base(value) {}
        #endregion

        public override void AddValue(T value) {
            if (Value.CompareTo(value) >= 0) {
                if (LeftChild == null) {
                    LeftChild = new Node<T>(value);
                } else {
                    LeftChild.AddValue(value);
                }
            } else {
                if (RightChild == null) {
                    RightChild = new Node<T>(value);
                } else {
                    RightChild.AddValue(value);
                }
            }
        }
    }
}