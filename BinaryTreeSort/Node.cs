using System;

namespace AlgorithmSamples.BinaryTreeSort
{
    internal class Node< T > where T : IComparable
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

        #endregion

        public void AttachValue( T value )
        {
            if ( _value.CompareTo( value ) >= 0 )
            {
                if ( _leftChild == null )
                {
                    _leftChild = new Node< T >( value );
                }
                else
                {
                    _leftChild.AttachValue( value );
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
                    _rightChild.AttachValue( value );
                }
            }
        }

        public override string ToString( )
        {
            return ( _leftChild?.ToString( ) ?? "" )
                   + _value + ", "
                   + ( _rightChild?.ToString( ) ?? "" );
        }
    }
}