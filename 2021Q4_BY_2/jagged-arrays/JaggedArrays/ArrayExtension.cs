using System;

#pragma warning disable S2368

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingBySum(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            }

            // Getting an array with the nested arrays sums.
            int?[] keysArray = GetSum(source);

            // Sorting arrays in ascending order.
            AscendingOrder(source, keysArray);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingBySum(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            }

            // Getting an array with the nested arrays sums.
            int?[] keysArray = GetSum(source);

            // Sorting arrays in descending order.
            DescendingOrder(source, keysArray);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingByMax(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            }

            // Getting an array with the nested arrays max values.
            int?[] keysArray = GetMax(source);

            // Sorting arrays in ascending order.
            AscendingOrder(source, keysArray);
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingByMax(this int[][] source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            }

            // Getting an array with the nested arrays max values.
            int?[] keysArray = GetMax(source);

            // Sorting arrays in descending order.
            DescendingOrder(source, keysArray);
        }

        // The method gets the sums of the nested source arrays and returns an array with them. 
        private static int?[] GetSum(int[][] source)
        {
            int?[] temp = new int?[source.Length];
            int sum;
            for (int i = 0; i < source.Length; i++)
            {
                sum = 0;
                if (source[i] is null)
                {
                    temp[i] = null;
                }
                else
                {
                    for (int j = 0; j < source[i].Length; j++)
                    {
                        sum += source[i][j];
                    }
                }

                temp[i] = sum;
            }

            return temp;
        }

        // The method gets the maximum values of the nested source arrays and returns an array with them. 
        private static int?[] GetMax(int[][] source)
        {
            int?[] temp = new int?[source.Length];
            int? max;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] is null)
                {
                    temp[i] = null;
                }
                else
                {
                    max = source[i][0];
                    for (int j = 1; j < source[i].Length; j++)
                    {
                        if (max < source[i][j])
                        {
                            max = source[i][j];
                        }
                    }

                    temp[i] = max;
                }
            }

            return temp;
        }

        // The method implements the insertion sorting in ascending order.
        private static void AscendingOrder(int[][] source, int?[] keysArray)
        {
            for (int generalIndex = 1; generalIndex < keysArray.Length; generalIndex++)
            {
                int? buffer = keysArray[generalIndex];
                int[] tempArray = source[generalIndex];

                for (int leftPartIndex = generalIndex - 1; leftPartIndex >= 0; leftPartIndex--)
                {
                    if (buffer > keysArray[leftPartIndex] || keysArray[leftPartIndex] is null)
                    {
                        break;
                    }

                    keysArray[leftPartIndex + 1] = keysArray[leftPartIndex];
                    source[leftPartIndex + 1] = source[leftPartIndex];

                    keysArray[leftPartIndex] = buffer;
                    source[leftPartIndex] = tempArray;
                }
            }
        }

        // The method implements the insertion sorting in descending order.
        private static void DescendingOrder(int[][] source, int?[] keysArray)
        {
            for (int generalIndex = 1; generalIndex < keysArray.Length; generalIndex++)
            {
                int? buffer = keysArray[generalIndex];
                int[] tempArray = source[generalIndex];

                for (int leftPartIndex = generalIndex - 1; leftPartIndex >= 0; leftPartIndex--)
                {
                    if (buffer <= keysArray[leftPartIndex] || buffer is null)
                    {
                        break;
                    }

                    keysArray[leftPartIndex + 1] = keysArray[leftPartIndex];
                    source[leftPartIndex + 1] = source[leftPartIndex];

                    keysArray[leftPartIndex] = buffer;
                    source[leftPartIndex] = tempArray;
                }
            }
        }
    }
}
