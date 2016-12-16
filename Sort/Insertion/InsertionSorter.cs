namespace Algorithm.Sort.Insertion {
    #region Usings

    using System;
    using Common;

    #endregion

    /// <summary>
    /// Performs the sorting using insertion algorithm.
    /// Complexity:
    ///     Best: O(n)
    ///     Average: O(n^2)
    ///     Worst: O(n^2)
    /// Method Description
    /// Main cursor moves from the beginning of the array to the end. Every time when
    /// the current value is less than previous one, it should be moved left to it's
    /// corresponding place. To avoid swapping like the bubble method does, algorithm
    /// searches for exact place to put the current number and shift all the numbers
    /// to one position right.
    /// Example:
    /// Incoming array: [4,5,8,9,12,6,83,14]
    /// Starting from the second element we compare it with the previous one.
    /// 
    /// Step 1: index == 2, value == 5. Previous value ==  4. 
    /// 5 is greater 4, go to the next step.
    /// Step 2: index == 3, value == 8, Previous value == 5
    /// 8 is greater 5, go to the next step.
    /// ...
    /// Step 5: index == 6, value = 6. Previous value == 12
    /// 6 is less than 12 - need to insert the value.
    ///     Sub loop
    ///     Save the current value to the temp variable. 
    ///     temp == 6
    ///     Move from the current index down to the 1'st element.
    ///     Step 5.1: index == 5, value == 12. 12 is greater than 6, so copy 12 to index+1 position
    ///         [4,5,8,9,12,12,83,14]
    ///     Step 5.2: index == 4, value == 9. 9 is greater than 6, copy value to the next position
    ///         [4,5,8,9,9,12,83,14]
    ///     Step 5.3: index == 3, value == 8. 8 is greater than 6, copy value to the next position
    ///         [4,5,8,8,9,12,83,14]
    ///     Step 5.4: index == 2, value = 5. 5 is smaller than 6, copy the saved value to the next position
    ///         [4,5,6,8,9,12,83,14]
    /// Step 6: index == 7, value == 83. Previous value == 12.
    /// 83 is greater than 12, go to the next step.
    /// Step 7: index == 8, value == 14. Previous value == 83.
    /// 14 is less than 83 - need to insert the value
    ///     Sub loop
    ///     Save the current value to the temp variable
    ///     temp == 14
    ///     Step 6.1: index == 7, value == 83, 83 is greater than 14. Copy it to the next position
    ///         [4,5,6,8,9,12,83,83]
    ///     Step 6.2: index == 6, value == 12. 12 is smaller than 14. Copy the saved value to the next position
    ///         [4,5,6,8,9,12,14,83]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertionSorter<T> : SorterBase<T> where T : IComparable {
        /// <summary>
        /// Simple primitive constructor.
        /// </summary>
        public InsertionSorter() {
        }

        public InsertionSorter(T[] initData) : base(initData) {
        }

        public override T[] GetSorted() {
            for(var mainIndex = 1; mainIndex < Container.Length; mainIndex++) {
                if(IsSmaller(mainIndex, mainIndex - 1)) {
                    var temp = Container[mainIndex];
                    var i = mainIndex;
                    while(i > 0 && temp.CompareTo(Container[i - 1]) < 0) {
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