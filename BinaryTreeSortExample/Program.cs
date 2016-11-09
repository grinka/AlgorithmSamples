using System;

namespace BinaryTreeSortExample
{
    class Program
    {
        static void Main( string[] args )
        {
            var tree = new BinaryTree< int >( );
            tree.AddValue( 1 );
            tree.AddValue( 2 );
            tree.AddValue( 15 );
            tree.AddValue( 5 );
            tree.AddValue( 4 );
            Console.WriteLine( tree.ToString( ) );
            Console.ReadKey( );
        }
    }
}