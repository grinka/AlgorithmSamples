using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Insertion {
    public class InsertionSorter<T> : SorterBase<T> where T : IComparable {
        public InsertionSorter() {}

        public InsertionSorter(T[] initData) : base(initData) {}

        public override T[] GetSorted() {
            for (var mainIndex = 1; mainIndex < Container.Length; mainIndex++) {
                if (IsSmaller(mainIndex, mainIndex - 1)) {
                    var temp = Container[mainIndex];
                    var i = mainIndex;
                    while (i > 0 && temp.CompareTo(Container[i - 1]) < 0) {
                        Container[i] = Container[i - 1];
                        i--;
                    }
                    Container[i] = temp;
                }
            }
            return Container;
        }
    }
}