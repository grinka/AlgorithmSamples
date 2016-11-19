using System;
using AlgorithmSamples.BinaryTreeCommon;

namespace AlgorithmSamples.BinaryTreeSort {
    /// <summary>
    /// Contains the binary tree of the comparable items. Allows ascending and descending sotring
    /// of the unbalanced tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> where T : IComparable {
        private ISortableNode<T> _root;

        public void AddValue(T value) {
            if(_root == null) {
                _root = new Node<T>(value);
            }
            else {
                _root.AddValue(value);
            }
        }

        public T[] SortedAscending => _root.SortedAscending;
        public T[] SortedDescending => _root.SortedDescending;

        public override string ToString() {
            return _root.ToString();
        }
    }
}