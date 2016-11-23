using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Smooth {
    public class SmoothSorter<T> : SorterBase<T> where T : IComparable {
        public SmoothSorter() {}

        public SmoothSorter(T[] initArray) : base(initArray) {}

        public override T[] GetSorted() {
            throw new NotImplementedException();
        }
    }
}