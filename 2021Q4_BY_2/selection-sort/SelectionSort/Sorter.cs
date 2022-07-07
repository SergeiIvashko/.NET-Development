using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace SelectionSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[] array)
        {
            // #1. Implement the method using a loop statements.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            for (int outerIndex = 0; outerIndex < array.Length; outerIndex++)
            {
                int outerIndexMinValue = outerIndex;

                // Inner loop of the selection sorting algorithm.
                for (int innerIndex = outerIndex + 1; innerIndex < array.Length; innerIndex++)
                {
                    if (array[innerIndex] < array[outerIndexMinValue])
                    {
                        outerIndexMinValue = innerIndex;
                    }
                }

                // Swapping elements of the array if in the inner loop has been found element with minimum value.
                if (outerIndexMinValue != outerIndex)
                {
                    int buffer = array[outerIndex];
                    array[outerIndex] = array[outerIndexMinValue];
                    array[outerIndexMinValue] = buffer;
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[] array)
        {
            // #2. Implement the method using recursion algorithm.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // Start point for the recursion method.
            RecursiveSelectionSort(array, 0);
        }

        public static void RecursiveSelectionSort(int[] array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // Recursion will stop when it reaches the last array index.
            if (index < array.Length - 1)
            {
                // Implementation of the inner loop of the selection sorting algorithm.
                // The swap method relocate current element and element with min value
                // that has been found inside FoundMinValue.
                Swap(array, index, FindMinValue(array, index));

                // The next step of the recursion increasing index by 1 unit.
                RecursiveSelectionSort(array, index + 1);
            }
        }

        public static int FindMinValue(int[] array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            int min = index - 1;

            // The method is reaching the array end and then will start returning values.
            if (index < array.Length - 1)
            {
                min = FindMinValue(array, index + 1);
            }

            if (array[index] < array[min])
            {
                min = index;
            }

            return min;
        }

        // Swapping elements of the array.
        public static void Swap(int[] array, int leftIndex, int rightIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            int buffer = array[leftIndex];
            array[leftIndex] = array[rightIndex];
            array[rightIndex] = buffer;
        }
    }
}
