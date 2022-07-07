using System;

namespace RelocationElementsTask
{
    /// <summary>
    /// Class for operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Moves all of the elements with set value to the end, preserving the order of the other elements.
        /// </summary>
        /// <param name="source"> Source array. </param>
        /// <param name="value">Source value.</param>
        /// <exception cref="ArgumentNullException">Thrown when source array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty.</exception>
        public static void MoveToTail(int[] source, int value)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Source array cannot be null.");
            }
            else if (source.Length == 0)
            {
                throw new ArgumentException("Source array cannot be empty.", nameof(source));
            }

            int lastPosition = source.Length - 1;
            for (int currentPosition = source.Length - 1; currentPosition >= 0; currentPosition--)
            {
                if (source[currentPosition] == value)
                {
                    // The outer loop will continue from current position and will not affected by relocation operations.
                    int initialPosition = currentPosition;
                    while (initialPosition <= lastPosition - 1)
                    {
                        ShiftPosition(ref source[initialPosition], ref source[initialPosition + 1]);
                        initialPosition++;
                    }

                    // Every case of relocation of elements chop length of operable part of the array by one position.
                    lastPosition--;
                }
            }
        }

        // Shifting elements between themselves.
        private static void ShiftPosition(ref int a, ref int b)
        {
            int buffer = a;
            a = b;
            b = buffer;
        }
    }
}
