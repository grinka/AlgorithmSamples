using System;

namespace SimpleAlgorithms {
    public class SimpleBinarySearch<T> where T : IComparable {
        public static int FindElementInArray(T element, T[] data) {
            var leftBorder = 0;
            var rightBorder = data.Length - 1;
            if(element.CompareTo(data[leftBorder]) == 0) {
                return leftBorder;
            }
            if(element.CompareTo(data[rightBorder]) == 0) {
                return rightBorder;
            }
            while(leftBorder < rightBorder - 1) {
                // first process the margin cases
                if(element.CompareTo(data[leftBorder]) < 0) {
                    return -1;
                }
                if(element.CompareTo(data[rightBorder]) > 0) {
                    return -1;
                }
                var middleIndex = rightBorder - (rightBorder - leftBorder) / 2;
                switch(element.CompareTo(data[middleIndex])) {
                    case -1:
                        rightBorder = middleIndex;
                        break;
                    case 1:
                        leftBorder = middleIndex;
                        break;
                    default:
                        return middleIndex;
                }
            }
            return -1; // element not found
        }
    }
}