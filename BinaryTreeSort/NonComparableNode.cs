using System;
using AlgorithmSamples.BinaryTree.Common;

namespace AlgorithmSamples.BinaryTreeSort {
    public class NonComparableNode<T> : SortableBinaryTreeNode<T> {
        private readonly Func<T, IComparable> _compareFunc;

        public NonComparableNode(T value, Func<T, IComparable> compareFunc) : base(value) {
            _compareFunc = compareFunc;
        }

        public override void AddValue(T value) {
            if (_compareFunc(Value).CompareTo(_compareFunc(value)) >= 0) {
                if (LeftChild == null) {
                    LeftChild = new NonComparableNode<T>(value, _compareFunc);
                } else {
                    LeftChild.AddValue(value);
                }
            } else {
                if (RightChild == null) {
                    RightChild = new NonComparableNode<T>(value, _compareFunc);
                } else {
                    RightChild.AddValue(value);
                }
            }
        }
    }
}