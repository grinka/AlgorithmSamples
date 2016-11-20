using System;
using System.Linq;

namespace AlgorithmSamples.BinaryTreeSort {
    class Program {
        static void Main( string[] args ) {
            //TestBinaryTree( );
            new Program( ).TestShift( 125 );
        }

        private void TestShift( int d ) {
            Console.WriteLine( d );
            Console.WriteLine( d >> 5 );
            Console.ReadLine( );
        }

        private static void TestBinaryTree( ) {
            var tree = new BinaryTree< int >( );
            tree.AddValue( 1 );
            tree.AddValue( 2 );
            tree.AddValue( 15 );
            tree.AddValue( 5 );
            tree.AddValue( 4 );
            Console.WriteLine( tree.ToString( ) );
            Console.WriteLine( tree.SortedAscending.Aggregate< int, string >(
                string.Empty,
                ( current, item ) => $"{current}, {item}" ) );
            Console.ReadKey( );
        }
    }
}