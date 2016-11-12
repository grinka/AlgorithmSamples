using System;

namespace AlgorithmSamples.BinaryTreeSort
{
    public class BinaryTree< T > where T : IComparable
    {
        private Node< T > _root;

        public void AddValue( T value )
        {
            if ( _root == null )
            {
                _root = new Node< T >( value );
            }
            else
            {
                _root.AddValue( value );
            }
        }

        public T[] SortAsc => _root.SortedAscending;
        public T[] SortDesc => _root.SortedDescending;

        public override string ToString( )
        {
            return _root.ToString( );
        }
    }
}