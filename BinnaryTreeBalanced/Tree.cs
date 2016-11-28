using System;

namespace AlrogithmSamples.BinaryTreeBalanced
{
    public class Tree<T>
    {
        private Func< T, IComparable > _compareFunc;

        public Tree( Func< T, IComparable > compareFunc )
        {
            _compareFunc = compareFunc;
        }
    }
}
