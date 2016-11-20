using AlgorithmSamples.BinaryTreeCommon;

namespace AlgorithmSamples.BinaryTreeSort {
    using System;

    public class NonComparableBinaryTree<T> : SortableBinaryTree<T> {
        private readonly Func<T, IComparable> _compareFunc;

        public NonComparableBinaryTree(Func<T, IComparable> compareFunc) {
            _compareFunc = compareFunc;
        }

        protected override ISortableNode<T> CreateRootNode(T value) {
            return new NonComparableNode<T>(value, _compareFunc);
        }
    }
}