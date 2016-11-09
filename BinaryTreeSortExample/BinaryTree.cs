using System;

namespace BinaryTreeSortExample
{
    public class BinaryTree<T> where T : IComparable
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
                _root.AttachValue( value );
            }
        }

        public override string ToString( )
        {
            return _root.ToString( );
        }
    }
}
