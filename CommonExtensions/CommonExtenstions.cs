using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonExtensions {
    public static class ListExtensions {
        public static void AddRange<T>(this IList<T> list, IList<T> addList) {
            foreach (var addItem in addList) {
                list.Add(addItem);
            }
        }

        public static bool IsBigger<T>(this T[] array, int idx1, int idx2) where T : IComparable {
            return array[idx1].CompareTo(array[idx2]) > 0;
        }

        public static bool IsBiggerOrEqual<T>(this T[] array, int idx1, int idx2)
            where T : IComparable {
            return array[idx1].CompareTo(array[idx2]) >= 0;
        }

        public static bool IsEqual<T>(this T[] array, int idx1, int idx2) where T : IComparable {
            return array[idx1].CompareTo(array[idx2]) == 0;
        }

        public static bool IsSmaller<T>(this T[] array, int idx1, int idx2) where T : IComparable {
            return array[idx1].CompareTo(array[idx2]) < 0;
        }

        public static bool SameArray<T>(this T[] array, T[] otherArray) where T : IComparable {
            if (array.Length != otherArray.Length) {
                return false;
            }
            return !array.Where(((item, idx) => item.CompareTo(otherArray[idx]) != 0)).Any();
        }
    }
}