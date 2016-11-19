﻿using System;

namespace AlgorithmSamples.BinaryTreeSort
{
    public class NonComparableTree< T >
    {
        private NonComparableNode< T > _rootNode;
        private readonly Func< T, IComparable > _compareFunc;

        public NonComparableTree( Func< T, IComparable > compareFunc )
        {
            _compareFunc = compareFunc;
        }

        public void AddValue( T value )
        {
            if ( _rootNode == null )
            {
                _rootNode = new NonComparableNode< T >( value, _compareFunc );
            }
            else
            {
                _rootNode.AddValue( value );
            }
        }
    }
}