using System;

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            // #3. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch cannot be null.");
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart), "rangeStart cannot be null.");
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd), "rangeEnd cannot be null.");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("rangeStart and rangeEnd cannot have different length.");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0)
            {
                return 0;
            }

            // Checking rangeStart and rangeEnd arrays for invalid values.
            CheckRanges(rangeStart, rangeEnd);

            int number = 0;
            if (arrayToSearch.Length > 1)
            {
                number += GetFloatsCount(arrayToSearch[..^1], rangeStart, rangeEnd);
            }
            else if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            // Checking if the arrayToSearch element value in the ranges.
            number += GetFloatInRanges(arrayToSearch[^1], rangeStart, rangeEnd);

            return number;
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            // #4. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch cannot be null.");
            }

            if (rangeStart == null)
            {
                throw new ArgumentNullException(nameof(rangeStart), "rangeStart cannot be null.");
            }

            if (rangeEnd == null)
            {
                throw new ArgumentNullException(nameof(rangeEnd), "rangeEnd cannot be null.");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("rangeStart and rangeEnd cannot have different length.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be less than zero.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count cannot be less than zero.");
            }

            if (rangeStart.Length == 0 || rangeEnd.Length == 0 || count == 0)
            {
                return 0;
            }

            // Checking rangeStart and rangeEnd arrays for invalid values.
            CheckRanges(rangeStart, rangeEnd);

            if (startIndex > arrayToSearch.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be greater than arrayToSearch.Length.");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count cannot be greater than arrayToSearch.Length.");
            }

            // Checking if the arrayToSearch element value in the ranges.
            int number = 0;
            if (count >= 1)
            {
                number += GetFloatsCount(arrayToSearch, rangeStart, rangeEnd, startIndex, --count);
                number += GetFloatInRanges(arrayToSearch[startIndex + count], rangeStart, rangeEnd);
            }

            return number;
        }

        // Checking if the arrayToSearch element value in the ranges.
        private static int GetFloatInRanges(float valueToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (rangeStart.Length != 0 && valueToSearch >= rangeStart[^1] && valueToSearch <= rangeEnd[^1])
            {
                return 1;
            }

            if (rangeStart.Length == 0)
            {
                return 0;
            }

            return GetFloatInRanges(valueToSearch, rangeStart[..^1], rangeEnd[.. ^1]);
        }

        // Checking rangeStart and rangeEnd arrays for invalid values.
        private static void CheckRanges(float[] rangeStart, float[] rangeEnd)
        {
            if (rangeStart[^1] > rangeEnd[^1])
            {
                throw new ArgumentException("rangeStart value cannot be greater than rangeEnd.");
            }

            if (rangeStart.Length > 1)
            {
                CheckRanges(rangeStart[..^1], rangeEnd[.. ^1]);
            }
        }
    }
}
