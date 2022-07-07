using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace InsertionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with insertion sort algorithm.
        /// </summary>
        public static void InsertionSort(this int[] array)
        {
            // #1. Implement the method using a loop statements.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            for (int generalIndex = 1; generalIndex < array.Length; generalIndex++)
            {
                int buffer = array[generalIndex];
                for (int leftPartIndex = generalIndex - 1; leftPartIndex >= 0; leftPartIndex--)
                {
                    if (buffer > array[leftPartIndex])
                    {
                        break;
                    }

                    array[leftPartIndex + 1] = array[leftPartIndex];
                    array[leftPartIndex] = buffer;
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive insertion sort algorithm.
        /// </summary>
        public static void RecursiveInsertionSort(this int[] array)
        {
            // #2. Implement the method using recursion algorithm.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            RecursiveInsertionSort(array, array.Length - 1);
        }

        // Outer loop of the insertion sort algorithm.
        // It goes to to 1st element and start returing.
        private static void RecursiveInsertionSort(int[] array, int lastIndex)
        {
            if (lastIndex > 0)
            {
                RecursiveInsertionSort(array, lastIndex - 1);
                RelocateToProperPosition(array, array[lastIndex], lastIndex - 1);
            }
        }

        // Relocating element to the array sorted part proper position.
        private static void RelocateToProperPosition(int[] array, int buffer, int nextToLastIndex)
        {
            // Just append element to the array sorted part.
            if (buffer >= array[nextToLastIndex])
            {
                array[nextToLastIndex + 1] = buffer;
            }
            else if (nextToLastIndex > 0)
            {
                // Swapping next to last and last element of the array for the current step.
                array[nextToLastIndex + 1] = array[nextToLastIndex];

                // Inner loop of the insertion sort algorithm.
                // Swapping element till it will take proper position in the array sorted part.
                RelocateToProperPosition(array, buffer, nextToLastIndex - 1);
            }

            // Swapping 0 and 1st element of the array.
            else
            {
                array[nextToLastIndex + 1] = array[nextToLastIndex];
                array[nextToLastIndex] = buffer;
            }
        }
    }
}
