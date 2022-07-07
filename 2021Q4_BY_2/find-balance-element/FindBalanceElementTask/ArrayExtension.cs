using System;

namespace FindBalanceElementTask
{
    /// <summary>
    /// Class for operations with arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Finds an index of element in an integer array for which the sum of the elements
        /// on the left and the sum of the elements on the right are equal.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>The index of the balance element, if it exists, and null otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty.</exception>
        public static int? FindBalanceElement(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            // Array with length less than three elements cannot have balance element.
            else if (array.Length < 3)
            {
                return null;
            }

            int? balanceIndex = null;

            // Calculating total array sum for the following
            // calculations of the right part sum.
            long totalSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                totalSum += array[i];
            }

            long leftPartSum = 0;
            long subtractionSum;
            long rightSum;
            for (int i = 0; i < array.Length - 1; i++)
            {
                leftPartSum += array[i];
                subtractionSum = leftPartSum + array[i + 1];

                // Sum of the right part of the array relative to
                // supposed balanced element.
                rightSum = totalSum - subtractionSum;
                if (leftPartSum == rightSum)
                {
                    balanceIndex = i + 1;
                    break;
                }
            }

            return balanceIndex;
        }
    }
}
