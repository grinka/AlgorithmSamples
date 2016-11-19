using System;
using AlgorithmSamples.BinaryTreeCommon;

namespace AlgorithmSamples.BinaryTreeSort
{
    internal class Node< T > : SortableBinaryTreeNode< T > where T : IComparable
    {
        #region Constructors
        public Node( T value ) : base(value)
        {
        }
        #endregion

        public override void AddValue( T value )
        {
            if ( Value.CompareTo( value ) >= 0 )
            {
                if ( LeftChild == null )
                {
                    LeftChild = new Node< T >( value );
                }
                else
                {
                    LeftChild.AddValue( value );
                }
            }
            else
            {
                if ( RightChild == null )
                {
                    RightChild = new Node< T >( value );
                }
                else
                {
                    RightChild.AddValue( value );
                }
            }
        }
    }
}