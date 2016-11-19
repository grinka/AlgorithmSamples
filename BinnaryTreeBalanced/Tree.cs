using System;

namespace AlrogithmSamples.BinnaryTreeBalanced
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
