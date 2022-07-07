using System;

namespace ShiftArrayElements
{
    public static class RecursiveShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (odd elements - left direction, even elements - right direction).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            // #2. Implement the method using recursive local functions and indexers only (don't use Array.Copy method here).
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source array cannot be null.");
            }

            if (iterations == null)
            {
                throw new ArgumentNullException(nameof(iterations), "Iterations array cannot be null.");
            }
            
            if (iterations.Length == 0 || source.Length <= 1)
            {
                return source;
            }

            // Iterations array recursion.
            Shift(source, iterations, iterations.Length - 1);
            return source;
        }

        // Recursion method of shifting an array elements.
        private static void Shift(int[] source, int[] iterations, int endIndex)
        {
            // Diving to the first iterations array element.
            if (endIndex > 0)
            {
                Shift(source, iterations, endIndex - 1);
            }

            // Even elements and left shifting.
            if (endIndex % 2 == 0)
            {
                LeftShift(source, iterations[endIndex]);
            }

            // Odd elements and right shifting.
            else
            {
                RightShift(source, iterations[endIndex]);
            }
        }

        // Recursion of left shifting operations quantity.
        private static void LeftShift(int[] source, int iterations)
        {
            if (iterations > 0)
            {
                LeftShift(source, iterations - 1);

                // Left shifting operation performing.
                LeftShift(source, 0, source[1]);
            }
        }

        // Left shifting operation.
        private static void LeftShift(int[] source, int index, int previousValue)
        {
            // To the end of the source array remembering every previous value.
            if (index < source.Length - 1 && source.Length > 2)
            {
                previousValue = source[index + 1];
                LeftShift(source, index + 1, previousValue);
            }

            // The first element swap with the last one.
            if (index == 0)
            {
                int buffer = source[index];
                source[index] = previousValue;
                source[^1] = buffer;
            }

            // The last element of the source array relocate to the previous one.
            else if (index == source.Length - 1)
            {
                source[^2] = source[index];
            }

            // All remaining elements just replace by the previous element value.
            else if (index > 0)
            {
                source[index] = previousValue;
            }
        }

        // Recursion of right shifting operations quantity.
        private static void RightShift(int[] source, int iterations)
        {
            if (iterations > 0)
            {
                RightShift(source, iterations - 1);

                // Right shifting operation performing.
                RightShift(source, source.Length - 1,  source[^2]);
            }
        }

        // Left shifting operation.
        private static void RightShift(int[] source, int index, int previousValue)
        {
            // To the first element of the source array remembering every previous value.
            if (index > 0 && source.Length > 2)
            {
                previousValue = source[index - 1];
                RightShift(source, index - 1, previousValue);
            }

            // The last element swap with the first one.
            if (index == source.Length - 1)
            {
                int buffer = source[index];
                source[index] = previousValue;
                source[0] = buffer;
            }

            // The first element of the source array relocate to the next one.
            else if (index == 0)
            {
                source[1] = source[index];
            }

            // All remaining elements just replace by the previous element value.
            else if (index < source.Length - 1)
            {
                source[index] = previousValue;
            }
        }
    }
}
