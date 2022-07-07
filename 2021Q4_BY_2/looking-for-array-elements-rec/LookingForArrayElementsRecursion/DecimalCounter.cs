using System;

#pragma warning disable S2368

namespace LookingForArrayElementsRecursion
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            // #5. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch cannot be null.");
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges), "ranges cannot be null.");
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            // Checking nested arrays in the ranges for null value and invalid length.
            CheckRanges(ranges);

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int number = 0;
            if (arrayToSearch.Length > 1)
            {
                number += GetDecimalsCount(arrayToSearch[.. ^1], ranges);
            }

            // Checking if the arrayToSearch element value in the ranges.
            number += GetDecimalInRanges(arrayToSearch[^1], ranges);
            return number;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            // #6. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch cannot be null.");
            }

            if (ranges == null)
            {
                throw new ArgumentNullException(nameof(ranges), "ranges cannot be null.");
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            if (ranges[^1] == null)
            {
                throw new ArgumentNullException(nameof(ranges), "No one nested array in the ranges cannot be null.");
            }
            else if (ranges[^1].Length != 2 && ranges[^1].Length != 0)
            {
                throw new ArgumentException("Nested arrays in the ranges cannot have more or less than two values.", nameof(ranges));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be less than zero.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be less than zero.");
            }

            if ((startIndex + count) > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count cannot be greater than arrayToSearch.Length.");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            // Checking if the arrayToSearch element value in the ranges.
            int number = 0;
            if (count >= 1)
            {
                number += GetDecimalsCount(arrayToSearch, ranges, startIndex, --count);
                number += GetDecimalInRanges(arrayToSearch[startIndex + count], ranges);
            }

            return number;
        }

        // Checking if the arrayToSearch element value in the ranges.
        private static int GetDecimalInRanges(decimal valueToSearch, decimal[][] ranges)
        {
            if (ranges.Length == 0)
            {
                return 0;
            }

            if (ranges[^1] == null)
            {
                throw new ArgumentNullException(nameof(ranges), "No one nested array in the ranges cannot be null.");
            }

            if (ranges[^1].Length != 2 && ranges[^1].Length != 0)
            {
                throw new ArgumentException("Nested arrays in the ranges cannot have more or less than two values.", nameof(ranges));
            }

            if (ranges[^1].Length != 0 && valueToSearch >= ranges[^1][0] && valueToSearch <= ranges[^1][1])
            {
                return 1;
            }

            return GetDecimalInRanges(valueToSearch, ranges[..^1]);
        }

        // Checking nested arrays in the ranges for null value and invalid length.
        private static void CheckRanges(decimal[][] ranges)
        {
            if (ranges[^1] == null)
            {
                throw new ArgumentNullException(nameof(ranges), "No one nested array in the ranges cannot be null.");
            }

            if (ranges[^1].Length != 2 && ranges[^1].Length != 0)
            {
                throw new ArgumentException("Nested arrays in the ranges cannot have more or less than two values.", nameof(ranges));
            }

            if (ranges.Length > 1)
            {
                CheckRanges(ranges[..^1]);
            }
        }
    }
}
