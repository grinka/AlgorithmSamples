using System;

namespace SimpleAlgorithms {
    public class MatrixTransposer {
        public static void DisplayArrayAsMatrix(int size, int[] matrixArray) {
            if(matrixArray.Length != size * size) {
                throw new Exception("The array size does not match the matrix definition.");
            }
            for(var row = 0; row < size; row++) {
                for(var col = 0; col < size; col++) {
                    Console.Write("|  {0:D2} ", matrixArray[row * size + col]);
                }
                Console.WriteLine("|");
            }
        }

        public static int[] Transpose(int size, int[] source) {
            if(source.Length != size * size) {
                throw new Exception("The array size does not match the matrix definition.");
            }
            var result = new int[source.Length];
            for(var row = 0; row < size; row++) {
                for(var col = 0; col < row; col++) {
                    result[row * size + col] = source[col * size + row];
                    result[col * size + row] = source[row * size + col];
                }
                result[row * size + row] = source[row * size + row];
            }
            return result;
        }
    }
}