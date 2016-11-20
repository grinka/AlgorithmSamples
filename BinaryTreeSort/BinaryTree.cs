using System;
using AlgorithmSamples.BinaryTreeCommon;

namespace AlgorithmSamples.BinaryTreeSort {
    /// <summary>
    /// Contains the binary tree of the comparable items. Allows ascending and descending sotring
    /// of the unbalanced tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : SortableBinaryTree<T> where T : IComparable {
        protected override ISortableNode<T> CreateRootNode(T value) {
            return new Node<T>(value);
        }
    }
}