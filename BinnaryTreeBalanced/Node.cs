using System;
using AlgorithmSamples.BinaryTree.Common;

namespace AlrogithmSamples.BinaryTreeBalanced
{
    public class Node< T > : SortableBinaryTreeNode< T >, INode< T >
    {
        private readonly Func< T, IComparable > _compareElement;

        public Node( T value, Func< T, IComparable > compareElement ) : base( value )
        {
            _compareElement = compareElement;
        }

        public override void AddValue( T value )
        {
            if ( _compareElement( value ).CompareTo( _compareElement( Value ) ) >= 1 )
            {
                if ( RightChild == null )
                {
                    RightChild = new Node< T >( value, _compareElement );
                }
                else
                {
                    ( ( Node< T > ) RightChild ).AddValue( value );
                }
            }
            else
            {
                if ( LeftChild == null )
                {
                    LeftChild = new Node< T >( value, _compareElement );
                }
                else
                {
                    ( ( Node< T > ) LeftChild ).AddValue( value );
                }
            }
        }

        public void AddValues( T[] values )
        {
            foreach ( var addValue in values )
            {
                this.AddValue( addValue );
            }
        }
    }
}