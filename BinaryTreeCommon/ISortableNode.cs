namespace AlgorithmSamples.BinaryTreeCommon
{
    interface ISortableNode<T>
    {
        T[] SortedAscending { get; }
        T[] SortedDescending { get; }
        void AddValue( T value );
    }
}