using System;
using System.Linq;
using AlgorithmSamples.BinaryTreeSort;

namespace AlgorithmSamples.BinaryTreeSort
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
            Console.WriteLine( tree.SortedAscending.Aggregate< int, string >( string.Empty,
                ( current, item ) => $"{current}, {item}" ) );
            Console.ReadKey( );
        }
    }
}