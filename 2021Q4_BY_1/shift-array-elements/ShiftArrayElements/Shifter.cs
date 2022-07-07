using System;

namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (see README.md for detailed instructions).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <returns>An array with shifted elements.</returns>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static int[] Shift(int[] source, int[] iterations)
        {
            // #2. Implement the method using "for" statements and Array.Copy method.
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Method throws ArgumentNullException in case the source array is null");
            }

            if (iterations is null)
            {
                throw new ArgumentNullException(nameof(iterations), "Method throw ArgumentNullException in case the iterations array is null");
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                // Left shifting.
                if (i == 0 || i % 2 == 0)
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        int temp = source[0];
                        Array.Copy(source, 1, source, 0, source.Length - 1);
                        source[^1] = temp;
                    }
                }

                // Right shifting.
                else if (i % 2 != 0)
                {
                    for (int j = 0; j < iterations[i]; j++)
                    {
                        int temp = source[^1];
                        Array.Copy(source, 0, source, 1, source.Length - 1);
                        source[0] = temp;
                    }
                }
            }

            return source;
       }
    }
}
