using System;

namespace LookingForArrayElements
{
    public static class IntegersCounter
    {
        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            // #1. Implement the method using "for" statement.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Method throws ArgumentNullException in case an array to search is null.");
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor), "Method throws ArgumentNullException in case an array of elements to for search is null.");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            int currentIncrement = 0;
            for (int i = 0; i < elementsToSearchFor.Length; i++)
            {
                for (int j = 0; j < arrayToSearch.Length; j++)
                {
                    if (elementsToSearchFor[i] == arrayToSearch[j])
                    {
                        currentIncrement++;
                    }
                }
            }

            return currentIncrement;
        }

        /// <summary>
        /// Searches an array of integers for elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>, and returns the number of occurrences of the elements withing the range of elements in the <see cref="Array"/> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of integers to search.</param>
        /// <param name="elementsToSearchFor">One-dimensional, zero-based <see cref="Array"/> that contains integers to search for.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the elements that are in <paramref name="elementsToSearchFor"/> <see cref="Array"/>.</returns>
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            // #2. Implement the method using "while" statement.
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Method throws ArgumentNullException in case an array to search is null.");
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor), "Method throws ArgumentNullException in case an array of elements to for search is null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Method throws ArgumentOutOfRangeException in case start index is negative.");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayToSearch), "Method throws ArgumentOutOfRangeException in case start index is greater than the length of an array to search.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Method throws ArgumentOutOfRangeException in case count is less than zero.");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Method throws ArgumentOutOfRangeException in case the number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
            }

            if (arrayToSearch.Length == 0)
            {
                return 0;
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            // Index for arrayTorSearch.
            int i = 0;

            // Index for elementsToSearchFor.
            int j = startIndex;

            // Number of occurrences.
            int currentIncrement = 0;
            while (i < elementsToSearchFor.Length)
            {
                while (j < startIndex + count)
                {
                    if (elementsToSearchFor[i] == arrayToSearch[j])
                    {
                        currentIncrement++;
                    }

                    j++;
                }

                i++;
                j = startIndex;
            }

            return currentIncrement;
        }
    }
}
