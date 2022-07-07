using System;

namespace FindMaximumTask
{
    /// <summary>
    /// Class for operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Finds the element of the array with the maximum value recursively.
        /// </summary>
        /// <param name="array"> Source array. </param>
        /// <returns>The element of the array with the maximum value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static int FindMaximum(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(array));
            }

            return FindMaximum(array, 0, array.Length - 1);
        }

        private static int FindMaximum(int[] array, int leftIndex, int rightIndex)
        {
            if (rightIndex <= leftIndex + 1)
            {
                return Math.Max(array[leftIndex], array[rightIndex]);
            }

            return Math.Max(FindMaximum(array, leftIndex, (leftIndex + rightIndex) / 2), FindMaximum(array, ((leftIndex + rightIndex) / 2) + 1, rightIndex));
        }
    }
}
