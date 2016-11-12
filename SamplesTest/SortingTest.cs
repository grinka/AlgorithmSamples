using System;
using System.Linq;
using AlgorithmSamples.BinaryTreeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTest
{
    [TestClass]
    public class SortingTest
    {
        [TestMethod]
        public void TestBinaryTreeMethodAsc1()
        {
            var tree = new BinaryTree< int >( );
            tree.AddValue( 1 );
            tree.AddValue( 12 );
            tree.AddValue( 7 );
            var ret = tree.SortAsc;
            ret.Aggregate<int, string>(string.Empty, ( item, s ) => $"{s} {item}" );
        }
    }
}
