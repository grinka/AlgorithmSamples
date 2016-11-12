using System;

namespace AlgorithmSamples.BinaryTreeSort
{
    internal interface INode<T> where T : IComparable
    {
        void AddValue( T value );
        T[] SortedAscending { get; }
        T[] SortedDescending { get; }
        int Size { get; }
        bool IsEmpty { get; }
    }
}
