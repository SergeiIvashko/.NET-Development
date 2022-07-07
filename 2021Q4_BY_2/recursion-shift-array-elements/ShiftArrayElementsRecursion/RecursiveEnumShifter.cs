using System;

namespace ShiftArrayElements
{
    public static class RecursiveEnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static int[] Shift(int[] source, Direction[] directions)
        {
            // #1. Implement the method using recursive local functions and Array.Copy method.
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "The source array cannot be null.");
            }

            if (directions == null)
            {
                throw new ArgumentNullException(nameof(directions), "Direction array cannot be null.");
            }
            else if (directions.Length == 0)
            {
                return source;
            }

            Shift(source, directions, directions.Length - 1);
            return source;
        }

        // Recursive shifting array elements.
        private static void Shift(int[] source, Direction[] directions, int endIndex)
        {
            if (endIndex > 0)
            {
                Shift(source, directions, endIndex - 1);
            }

            int buffer;
            if (directions[endIndex] == Direction.Left)
            {
                buffer = source[0];
                Array.Copy(source, 1, source, 0, source.Length - 1);
                source[^1] = buffer;
            }
            else if (directions[endIndex] == Direction.Right)
            {
                buffer = source[^1];
                Array.Copy(source, 0, source, 1, source.Length - 1);
                source[0] = buffer;
            }
            else
            {
                throw new InvalidOperationException("Direction array contains invalid direction value.");
            }
        }
    }
}
