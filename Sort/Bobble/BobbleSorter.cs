using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Bobble
{
    public class BobbleSorter< T > : SorterBase<T> where T : IComparable
    {
        public BobbleSorter( ) : base()
        {
        }

        public BobbleSorter( T[] initArray ) : base(initArray)
        {
        }

        public override T[] GetSorted( )
        {
            var foundFlag = true;
            var sorted = new T[Container.Length];
            Container.CopyTo( sorted, 0 );

            while ( foundFlag )
            {
                foundFlag = false;
                for ( var index = 0; index < sorted.Length - 1; index++ )
                {
                    if ( sorted[ index ].CompareTo( sorted[ index + 1 ] ) > 0 )
                    {
                        foundFlag = true;
                        var swapValue = sorted[ index ];
                        sorted[ index ] = sorted[ index + 1 ];
                        sorted[ index + 1 ] = swapValue;
                    }
                }
            }
            return sorted;
        }
    }
}