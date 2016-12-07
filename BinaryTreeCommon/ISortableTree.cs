namespace AlgorithmSamples.BinaryTree.Common
{
    interface ISortableTree<T> {
        T[] SortedAscending { get; }
        T[] SortedDescending { get; }

        void Insert(T value);
        void Insert(T[] values);
    }
}
