using System;

namespace ShiftArrayElements
{
    public static class EnumShifter
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
            // #1. Implement the method using "for" statements and indexers only (don't use Array.Copy method here).
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Method throws ArgumentNullException in case the source array is null.");
            }

            if (directions is null)
            {
                throw new ArgumentNullException(nameof(directions), "Method throws ArgumentNullException in case the direction array is null.");
            }

            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case Direction.Left:
                        {
                            int j = 0;
                            int temp = source[j];
                            for (j = 0; j < source.Length - 1; j++)
                            {
                                source[j] = source[j + 1];
                            }

                            source[^1] = temp;
                            break;
                        }

                    case Direction.Right:
                        {
                            int temp = source[^1];
                            for (int j = source.Length - 1; j > 0; j--)
                            {
                                source[j] = source[j - 1];
                            }

                            source[0] = temp;

                            break;
                        }

                    default:
                        {
                            throw new InvalidOperationException($"Incorrect {directions} enum value");
                        }
                }    
            }

            return source;
        }
    }
}
