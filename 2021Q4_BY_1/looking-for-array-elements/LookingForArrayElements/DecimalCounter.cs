using System;

#pragma warning disable S2368

namespace LookingForArrayElements
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
            // #5. Implement the method using "do..while" statements.
            // Index of ranges array.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Method throws ArgumentNullException in case array to search is null.");
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges), "Method throws ArgumentNullException in case array of ranges is null.");
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            int rangesIndex = 0;
            do
            {
                if (ranges[rangesIndex] is null)
                {
                    throw new ArgumentNullException(nameof(ranges), "Method throws ArgumentNullException in case one of the ranges is null.");
                }
            }
            while (rangesIndex++ < ranges.Length - 1);

            rangesIndex = 0;
            do
            {
                if (ranges[rangesIndex].Length > 2)
                {
                    throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.", nameof(ranges));
                }
            }
            while (rangesIndex++ < ranges.Length - 1);

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            int currentIncrement = 0;

            // arrayToSearch index.
            int i = 0;

            // Second level of ranges index.
            int j = 0;

            // incrementVerification index.
            int k;

            // Verification parameter for counting proper members of arrayToSearch.
            bool incrementVerification;
            do
            {
                if (ranges[j].Length != 0)
                {
                    do
                    {
                        if (arrayToSearch[i] >= ranges[j][0] && arrayToSearch[i] <= ranges[j][1])
                        {
                            incrementVerification = true;
                            k = 0;

                            do
                            {
                                if (k < j && arrayToSearch[i] >= ranges[k][0] && arrayToSearch[i] <= ranges[k][1])
                                {
                                    incrementVerification = false;
                                    break;
                                }
                            }
                            while (k++ < j);

                            if (incrementVerification)
                            {
                                currentIncrement++;
                            }
                        }

                        i++;
                    }
                    while (i < arrayToSearch.Length);

                    i = 0;
                }
            }
            while (j++ < ranges.Length - 1);

            return currentIncrement;
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
            // #6. Implement the method using "for" statement.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Method throws ArgumentNullException in case array to search is null.");
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges), "Method throws ArgumentNullException in case array of ranges is null.");
            }

            if (ranges.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] is null)
                {
                    throw new ArgumentNullException(nameof(ranges), "Method throws ArgumentNullException in case one of the ranges is null.");
                }
            }

            if (ranges[0].Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].Length > 2)
                {
                    throw new ArgumentException("Method throws ArgumentException in case the length of one of the ranges is less or greater than 2.", nameof(ranges));
                }
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Method throws ArgumentOutOfRangeException in case start index is negative.");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Method throws ArgumentOutOfRangeException in case count is less than zero.");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
            }

            // Verification parameter for counting proper members of arrayToSearch.
            bool incrementVerification;
            int currentIncrement = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].Length != 0)
                {
                    for (int j = startIndex; j < startIndex + count; j++)
                    {
                        if (arrayToSearch[j] >= ranges[i][0] && arrayToSearch[j] <= ranges[i][1])
                        {
                            incrementVerification = true;
                            for (int k = 0; k < i; k++)
                            {
                                if (arrayToSearch[j] >= ranges[k][0] && arrayToSearch[j] <= ranges[k][1])
                                {
                                    incrementVerification = false;
                                    break;
                                }
                            }

                            if (incrementVerification)
                            {
                                currentIncrement++;
                            }
                        }
                    }
                }
            }

            return currentIncrement;
        }
    }
}
