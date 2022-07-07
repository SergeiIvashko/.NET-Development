using System;

#pragma warning disable CA1814
#pragma warning disable S2368

namespace SpiralMatrixTask
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Fills the matrix with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix size.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Thrown when matrix size less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size of matrix '{size}' cannot be less or equal zero.", nameof(size));
            }

            int[,] matrix = new int[size, size];

            // Value of the array elements.
            int value = 1;

            // Start row index.
            int xMin = 0;

            // Max row index.
            int xMax = size - 1;

            // Start column index.
            int yMin = 0;

            // Max column index.
            int yMax = size - 1;
            do
            {
                // Filling in an upper row of the array.
                for (int i = 0; xMin + i <= xMax; i++)
                {
                    matrix[yMin, xMin + i] = value++;
                }

                // Filling in a right column of the array and chopping an upper row of the matrix.
                yMin++;
                for (int i = 0; yMin + i <= yMax; i++)
                {
                    matrix[yMin + i, xMax] = value++;
                }

                // Filling in a bottom row of the array and chopping a right column of the matrix.
                xMax--;
                for (int i = 0; xMax - i >= xMin; i++)
                {
                    matrix[yMax, xMax - i] = value++;
                }

                // Filling in a left column of the array and chopping a bottom row of the matrix.
                yMax--;
                for (int i = 0; yMax - i >= yMin; i++)
                {
                    matrix[yMax - i, xMin] = value++;
                }

                // Chopping a left column of the matrix.
                xMin++;

                // Every step of the loop make the matrix narrower by left and right columns
                // and upper and bottom rows.
            }

            // The loop will end when value is equal to volume of the matrix.
            while (value - 1 != size * size);

            return matrix;
        }
    }
}
