using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Quick {
    public class QuickSorter<T> : SorterBase<T> where T : IComparable {
        public QuickSorter() {}

        public QuickSorter(T[] initArray) : base(initArray) {}

        public override T[] GetSorted() {
            throw new NotImplementedException();
        }
    }
}