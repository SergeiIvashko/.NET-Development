using System;
using System.Collections.Generic;

namespace FilterTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(int[] source, int digit)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source array cannot be null.");
            }
            else if (source.Length == 0)
            {
                throw new ArgumentException("Source array cannot be empty", nameof(source));
            }

            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "Required digit cannot be greater than 9");
            }

            List<int> resultList = new List<int>();

            // Comparing every number of the source array.
            for (int i = 0; i < source.Length; i++)
            {
                if (IsSourceContainDigit(source[i], digit))
                {
                    resultList.Add(source[i]);
                }
            }

            return resultList.ToArray();
        }

        // Defining do source number contain the required digit or not.
        private static bool IsSourceContainDigit(int number, int digit)
        {
            // Only absolute value of the number is important for the matching.
            number = Math.Abs(number);
            List<int> numberList = new List<int>();

            // Adding the number value to list by digits.
            do
            {
                numberList.Add(number % 10);
                number /= 10;
            }
            while (number > 1);

            // Comparing digits from the list with required digit.
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] == digit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
