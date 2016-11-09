using System.Collections.Generic;

namespace CommonExtensions
{
    public static class ListExtensions
    {
        public static void AddRange< T >( this IList< T > list, IList< T > addList )
        {
            foreach ( var addItem in addList )
            {
                list.Add( addItem );
            }
        }
    }
}