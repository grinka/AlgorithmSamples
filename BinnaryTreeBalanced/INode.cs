namespace AlrogithmSamples.BinaryTreeBalanced {
    public interface INode<T> {
        void AddValue(T value);
        void AddValues(T[] values);
        T[] SortedAscending { get; }
        T[] SortedDescending { get; }
        int Size { get; }
        bool IsEmpty { get; }
    }
}