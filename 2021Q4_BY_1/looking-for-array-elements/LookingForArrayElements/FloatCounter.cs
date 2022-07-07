using System;

namespace LookingForArrayElements
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
            // #3. Implement the method using "for" statement.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Method throws ArgumentNullException in case an array to search is null.");
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart), "Method throws Argumen  tNullException in case an array of range starts is null.");
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd), "Method throws ArgumentNullException in case an array of range ends is null.");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
            }

            for (int i = 0; i < rangeStart.Length; i++)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
                }
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (rangeStart.Length == 0)
            {
                return 0;
            }

            int currentIncrement = 0;
            for (int i = 0; i < rangeStart.Length; i++)
            {
                for (int j = 0; j < arrayToSearch.Length; j++)
                {
                    if (arrayToSearch[j] >= rangeStart[i] && arrayToSearch[j] <= rangeEnd[i])
                    {
                        currentIncrement++;
                    }
                }
            }

            return currentIncrement;
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
            // #4. Implement the method using "do..while" statements.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Method throws ArgumentNullException in case an array to search is null.");
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart), "Method throws Argumen  tNullException in case an array of range starts is null.");
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd), "Method throws ArgumentNullException in case an array of range ends is null.");
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException("Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
            }

            for (int rangeIndex = 0; rangeIndex < rangeStart.Length; rangeIndex++)
            {
                if (rangeStart[rangeIndex] > rangeEnd[rangeIndex])
                {
                    throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
                }
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Method throws ArgumentOutOfRangeException in case start index is negative.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Method throws ArgumentOutOfRangeException in case count is less than zero.");
            }

            if (startIndex > arrayToSearch.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
            }

            if (rangeStart.Length == 0 && rangeEnd.Length == 0)
            {
                return 0;
            }

            int currentIncrement = 0;
            int i = 0;
            int j = startIndex;

            do
            {
                do
                {
                    if (arrayToSearch[j] >= rangeStart[i] && arrayToSearch[j] <= rangeEnd[i])
                    {
                        currentIncrement++;
                    }

                    j++;
                }
                while (j < startIndex + count);

                j = startIndex;
                i++;
            }
            while (i < rangeStart.Length);

            return currentIncrement;
        }
    }
}
