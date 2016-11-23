using System;

namespace Algorithm.Sort.Common {
    public abstract class SorterBase<T> : ISorter<T> where T : IComparable {
        protected T[] Container;

        protected SorterBase() {
            Container = new T[0];
        }

        protected SorterBase(T[] initArray) {
            Container = new T[initArray.Length];
            initArray.CopyTo(Container, 0);
        }

        public void AddItem(T item) {
            var storeArray = new T[Container.Length + 1];
            Container.CopyTo(storeArray, 0);
            storeArray[Container.Length] = item;
            Container = storeArray;
        }

        public void AddRange(T[] range) {
            var storeArray = new T[Container.Length + range.Length];
            Container.CopyTo(storeArray, 0);
            range.CopyTo(storeArray, Container.Length);
            Container = storeArray;
        }

        protected void Swap(T[] array, int a, int b) {
            if (a >= array.Length || a < 0 || b >= array.Length || b < 0) {
                throw new IndexOutOfRangeException();
            }

            if (a == b) {
                return;
            }

            var temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public abstract T[] GetSorted();
    }
}