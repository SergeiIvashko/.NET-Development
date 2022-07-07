using System;

namespace LookingForArrayElementsRecursion
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
            // #1. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch cannot be null.");
            }

            if (elementsToSearchFor == null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor), "elementsToSearchFor cannot be null.");
            }

            if (arrayToSearch.Length == 0 || elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            int number = 0;

            if (elementsToSearchFor.Length > 1)
            {
                number = GetIntegersCount(arrayToSearch, elementsToSearchFor[.. ^1]);
            }

            // Counting number of occurrences of the specified element of elementToSearchFor array in arrayToSearch.
            number = GetIntegersCount(arrayToSearch, elementsToSearchFor[^1], ref number);
            return number;
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
            // #2. Implement the method using recursion.
            if (arrayToSearch == null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "arrayToSearch cannot be null.");
            }

            if (elementsToSearchFor == null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor), "elementsToSearchFor cannot be null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be less than zero.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count cannot be less than zero.");
            }

            if ((startIndex + count) > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count cannot be greater than arrayToSearch.Length");
            }

            if (arrayToSearch.Length == 0 || elementsToSearchFor.Length == 0 || count == 0)
            {
                return 0;
            }

            int number = 0;
            if (elementsToSearchFor.Length > 1)
            {
                number = GetIntegersCount(arrayToSearch, elementsToSearchFor[.. ^1], startIndex, count);
            }

            // Counting number of occurrences of the specified element of elementToSearchFor array in arrayToSearch.
            number = GetIntegersCount(arrayToSearch[startIndex .. (startIndex + count)], elementsToSearchFor[^1], ref number);
            return number;
        }

        // Counting number of occurrences of the specified element of elementToSearchFor array in arrayToSearch.
        private static int GetIntegersCount(int[] arrayToSearch, int elementToSearchFor, ref int number)
        {
            if (arrayToSearch[^1] == elementToSearchFor)
            {
                number++;
            }

            if (arrayToSearch.Length > 1)
            {
                number = GetIntegersCount(arrayToSearch[.. ^1], elementToSearchFor, ref number);
            }

            return number;
        }
    }
}
