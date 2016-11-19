using System;

namespace AlgorithmSamples.BinaryTreeCommon
{
    public class SortableBinaryTreeNode<T> : ISortableNode<T>
    {
        #region Local fields
        protected T Value;
        public int Size => (LeftChild?.Size ?? 0) + 1 + (RightChild?.Size ?? 0);
        protected SortableBinaryTreeNode< T > LeftChild;
        protected SortableBinaryTreeNode< T > RightChild;
        public bool IsEmpty => LeftChild == null && RightChild == null;
        #endregion

        protected SortableBinaryTreeNode( T value )
        {
            Value = value;
        }

        private T[] GetSorted(SortableBinaryTreeNode<T> firstPart, SortableBinaryTreeNode<T> secondPart, Func<SortableBinaryTreeNode<T>, T[]> sortedFunc)
        {
            var returnValue = new T[Size];
            var idx = 0;
            if (firstPart != null)
            {
                var firstPartArray = sortedFunc(firstPart);
                firstPartArray.CopyTo(returnValue, idx);
                idx += firstPartArray.Length;
            }
            returnValue[idx++] = Value;
            sortedFunc(secondPart)?.CopyTo(returnValue, idx);
            return returnValue;
        }

        private static T[] SortedAsc(SortableBinaryTreeNode<T> node) => node?.GetSorted(node.LeftChild, node.RightChild, SortedAsc);

        private static T[] SortedDesc(SortableBinaryTreeNode<T> node) => node?.GetSorted(node.RightChild, node.LeftChild, SortedDesc);

        public T[] SortedAscending => SortedAsc(this);

        public T[] SortedDescending => SortedDesc(this);

        public void AddValue( T value )
        {
            Value = value;
        }
    }
}