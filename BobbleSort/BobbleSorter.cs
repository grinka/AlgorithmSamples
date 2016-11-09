using System;

namespace AlgorithmSamples.BobbleSort
{
    public class BobbleSorter< T > where T : IComparable
    {
        private T[] _container;

        public BobbleSorter( )
        {
            _container = new T[0];
        }

        public BobbleSorter( T[] initArray )
        {
            _container = new T[initArray.Length];
            initArray.CopyTo( _container, 0 );
        }

        public void AddItem( T item )
        {
            var storeArray = new T[_container.Length + 1];
            storeArray[ _container.Length ] = item;
            _container = storeArray;
        }

        public void AddRange( T[] range )
        {
            var storeArray = new T[_container.Length + range.Length];
            range.CopyTo( storeArray, _container.Length );
            _container = storeArray;
        }

        public T[] GetSorted( )
        {
            var foundFlag = true;
            var sorted = new T[_container.Length];
            _container.CopyTo( sorted, 0 );

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
            return _container;
        }
    }
}