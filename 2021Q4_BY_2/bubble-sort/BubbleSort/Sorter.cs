using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace BubbleSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with bubble sort algorithm.
        /// </summary>
        public static void BubbleSort(this int[] array)
        {
            // #1. Implement the method using a loop statements.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // Each step of the loop exclude one element from the array end
            // which will have maximum value.
            for (int outerIndex = 0; outerIndex < array.Length - 1; ++outerIndex)
            {
                // From the array beginning to last element of the step  sort array elements
                // by comparing them between themselves and swapping the if previous one larger than next one.
                for (int innerIndex = 0; innerIndex < array.Length - outerIndex - 1; ++innerIndex)
                {
                    if (array[innerIndex] > array[innerIndex + 1])
                    {
                        int buffer = array[innerIndex];
                        array[innerIndex] = array[innerIndex + 1];
                        array[innerIndex + 1] = buffer;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive bubble sort algorithm.
        /// </summary>
        public static void RecursiveBubbleSort(this int[] array)
        {
            // #2. Implement the method using recursion algorithm.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // Start point of the recursive method.
            RecursiveBubbleSort(array, 0);
        }

        private static void RecursiveBubbleSort(int[] array, int maxIndex)
        {
            if (maxIndex < array.Length)
            {
                // Dive to the end of the array and returning
                // excluding the last array element which will will have maximum value.
                RecursiveBubbleSort(array, maxIndex + 1);

                // Sort array elements starting from the array beginning and returning to the maxIndex element.
                SortElements(array, maxIndex);
            }
        }

        // Sorting array elements by comparing them between themselves on each step.
        private static void SortElements(int[] array, int maxIndex)
        {
            if (maxIndex > 0)
            {
                SortElements(array, maxIndex - 1);
                if (array[maxIndex - 1] > array[maxIndex])
                {
                    int buffer = array[maxIndex - 1];
                    array[maxIndex - 1] = array[maxIndex];
                    array[maxIndex] = buffer;
                }
            }
        }
    }
}
