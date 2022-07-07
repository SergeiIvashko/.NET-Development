using System;

// ReSharper disable InconsistentNaming
#pragma warning disable SA1611

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[] array)
        {
            // #1. Implement the method using a loop statements.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // There is no need to any sorting when the array has none element or just one.
            else if (array.Length < 2)
            {
                return;
            }

            // Set boundaries of of the array.
            int left = 0;
            int right = array.Length - 1;

            // Temprorary data storage.
            int[] temp = new int[array.Length];

            // The first element of the temporary data array.
            int top = -1;

            // Writing the boundaries to the temp data storage.
            temp[++top] = left;
            temp[++top] = right;

            // Sort entire length of the array and then subarrays, as long as temp array contains valid data.
            while (top >= 0)
            {
                // Set boundaries of the sorted part of the array.
                right = temp[top--];
                left = temp[top--];

                // Setting a pivot element and sorting a range of the array according to it.
                int pivot = PartitionIterative(array, left, right);

                // Setting boundaries of the left subarray if there are two or more
                // elements from the left side of the pivot.
                if (pivot - 1 > left)
                {
                    temp[++top] = left;
                    temp[++top] = pivot - 1;
                }

                // Setting boundaries of the right subarray if there are two or more
                // elements from the right side of the pivot.
                if (pivot + 1 < right)
                {
                    temp[++top] = pivot + 1;
                    temp[++top] = right;
                }
            }
        }

        // Setting pivot element and sort a range of elements of the array according to quick sort algorithm.
        public static int PartitionIterative(int[] array, int left, int right)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // Temporary storage for swapping.
            int buffer;

            // Setting pivot element as the most right one of the range of the array.
            int pivot = array[right];

            // Index of a smaller than pivot element in a row.
            int tempPivot = left - 1;

            // The loop iterate as long as it reach element next to pivot.
            for (int currentIndex = left; currentIndex <= right - 1; currentIndex++)
            {
                // If element is smaller than or equal to the pivot it will relocated
                // to a row from left side of the range of the array.
                if (array[currentIndex] <= pivot)
                {
                    tempPivot++;

                    buffer = array[tempPivot];
                    array[tempPivot] = array[currentIndex];
                    array[currentIndex] = buffer;
                }
            }

            // Swapping the first greater than the pivot element and the pivot.
            buffer = array[tempPivot + 1];
            array[tempPivot + 1] = array[right];
            array[right] = buffer;

            // Setting position of the pivot.
            return tempPivot + 1;
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[] array)
        {
            // #2. Implement the method using recursion algorithm.
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null.");
            }

            // Start point of the recursive method.
            RecursiveQuickSort(array, 0, array.Length - 1);
        }

        // Recursive method of the quick sort algorithm.
        private static void RecursiveQuickSort(int[] array, int left, int right)
        {
            // The method repeating as long as boundaries have at least one element between themselves.
            if (left < right)
            {
                // Setting a pivot element and sorting a range of the array according to it.
                int pivot = PartitionRecursive(array, left, right);

                // Sorting the left subarray.
                RecursiveQuickSort(array, left, pivot - 1);

                // Sorting the right subarray.
                RecursiveQuickSort(array, pivot + 1, right);
            }
        }

        // Setting pivot element and sort a range of elements of the array according to quick sort algorithm
        // in recursive way.
        private static int PartitionRecursive(int[] array, int left, int right)
        {
            // Temporary storage for swapping.
            int buffer;

            // Setting pivot element as the most right one of the range of the array.
            int pivot = array[right];

            // Index of a smaller than pivot element in a row.
            int tempPivot = left - 1;

            // Recursive quick sorting of the subarray.
            Sort(array, left, right - 1, ref tempPivot, pivot);

            // Swapping the first greater than the pivot element and the pivot.
            buffer = array[tempPivot + 1];
            array[tempPivot + 1] = array[right];
            array[right] = buffer;

            // Setting position of the pivot.
            return tempPivot + 1;
        }

        // Recursive quick sorting of the subarray.
        private static void Sort(int[] array, int left, int curIndex, ref int tempPivot, int pivot)
        {
            // Recursive continue as long as the subarray has at least one element.
            if (curIndex >= left)
            {
                Sort(array, left, curIndex - 1, ref tempPivot, pivot);

                // If element is smaller than or equal to the pivot it will relocated
                // to a row from left side of the range of the array.
                if (array[curIndex] <= pivot)
                {
                    tempPivot += 1;

                    int buffer = array[tempPivot];
                    array[tempPivot] = array[curIndex];
                    array[curIndex] = buffer;
                }
            }
        }
    }
}
