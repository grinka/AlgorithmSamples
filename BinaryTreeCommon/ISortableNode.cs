namespace AlgorithmSamples.BinaryTreeCommon
{
    public interface ISortableNode<T>
    {
        T[] SortedAscending { get; }
        T[] SortedDescending { get; }
        void AddValue( T value );
        int Size { get; }
        bool IsEmpty { get; }
    }
}