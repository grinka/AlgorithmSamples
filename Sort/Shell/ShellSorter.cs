using System;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Shell {
    public class ShellSorter<T> : SorterBase<T> where T : IComparable {
        public ShellSorter() {}

        public ShellSorter(T[] initArray) : base(initArray) {}

        public override T[] GetSorted() {
            int j = 0;
            int increment = (Container.Length)/2;
            while (increment > 0) {
                for (int index = increment; index < Container.Length; index++) {
                    j = index;
                    var temp = Container[index];
                    while ((j >= increment) && Container[j - increment].CompareTo(temp) > 0) {
                        Container[j] = Container[j - increment];
                        j = j - increment;
                    }
                    Container[j] = temp;
                }
                if (increment/2 != 0)
                    increment = increment/2;
                else if (increment == 1)
                    increment = 0;
                else
                    increment = 1;
            }
            return Container;
        }
    }
}