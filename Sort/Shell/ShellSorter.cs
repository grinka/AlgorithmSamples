using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm.Sort.Common;

namespace Algorithm.Sort.Shell {
    public class ShellSorter<T> : SorterBase<T> where T : IComparable {
        public ShellSorter() {}

        public ShellSorter(T[] initArray) : base(initArray) {}

        public override T[] GetSorted() {
            throw new NotImplementedException();
        }
    }
}