using System;

namespace AlgorithmSamples.BinaryTreeSort
{
    internal class Node< T > : INode< T > where T : IComparable
    {
        #region Local fields

        private readonly T _value;
        private Node< T > _leftChild;
        private Node< T > _rightChild;

        #endregion

        #region Constructors
        public Node( T value )
        {
            _value = value;
        }
        #endregion

        #region Public Properties

        public bool IsLeaf => _leftChild == null && _rightChild == null;

        public int Size => (_leftChild?.Size ?? 0) + 1 + (_rightChild?.Size ?? 0);

        public bool IsEmpty => IsLeaf;

        public T[] SortedAscending => SortedAsc( this );

        public T[] SortedDescending => SortedDesc( this );

        #endregion

        private T[] GetSorted( Node< T > firstPart, Node< T > secondPart, Func< Node< T >, T[] > sortedFunc )
        {
            var returnValue = new T[Size];
            var idx = 0;
            if ( firstPart != null )
            {
                var firstPartArray = sortedFunc( firstPart );
                firstPartArray.CopyTo( returnValue, idx );
                idx += firstPartArray.Length;
            }
            returnValue[ idx++ ] = _value;
            sortedFunc( secondPart )?.CopyTo( returnValue, idx );
            return returnValue;
        }

        private static T[] SortedAsc( Node< T > node ) => node?.GetSorted( node._leftChild, node._rightChild, SortedAsc );

        private static T[] SortedDesc( Node< T > node ) => node?.GetSorted( node._rightChild, node._leftChild, SortedDesc );

        public void AddValue( T value )
        {
            if ( _value.CompareTo( value ) >= 0 )
            {
                if ( _leftChild == null )
                {
                    _leftChild = new Node< T >( value );
                }
                else
                {
                    _leftChild.AddValue( value );
                }
            }
            else
            {
                if ( _rightChild == null )
                {
                    _rightChild = new Node< T >( value );
                }
                else
                {
                    _rightChild.AddValue( value );
                }
            }
        }
    }
}