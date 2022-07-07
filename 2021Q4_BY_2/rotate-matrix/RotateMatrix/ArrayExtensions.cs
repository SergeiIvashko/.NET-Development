using System;

namespace RotateMatrix
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Rotates the image clockwise by 90° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate90DegreesClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            // Defining limit points of the array.
            int xMin = 0;

            // Length of the rows.
            int xMax = matrix.GetLength(1) - 1;
            int yMin = 0;

            // Length of the columns.
            int yMax = matrix.GetLength(0) - 1;
            do
            {
                // Shifting clockwise elements of the matrix starting from the corner points and so on to the right corner.
                for (int count = 0; xMin + count < xMax; count++)
                {
                    ArrayExtensions.ClockwiseShift90(ref matrix[yMin, xMin + count], ref matrix[yMin + count, xMax], ref matrix[yMax, xMax - count], ref matrix[yMax - count, xMin]);
                }

                // Every step of the loop chopping limit rows and columns of the matrix until the center point or zero elements loop.
                xMin++;
                xMax--;
                yMin++;
                yMax--;
            }
            while (xMin < xMax);
        }

        /// <summary>
        /// Rotates the image counterclockwise by 90° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate90DegreesCounterClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            // Defining limit points of the array.
            int xMin = 0;

            // Length of the rows.
            int xMax = matrix.GetLength(1) - 1;
            int yMin = 0;

            // Length of the columns.
            int yMax = matrix.GetLength(0) - 1;
            do
            {
                // Shifting counterclockwise elements of the matrix starting from the corner points and so on to the right corner.
                for (int count = 0; xMin + count < xMax; count++)
                {
                    ArrayExtensions.CounterClockwiseShift90(ref matrix[yMin, xMin + count], ref matrix[yMin + count, xMax], ref matrix[yMax, xMax - count], ref matrix[yMax - count, xMin]);
                }

                // Every step of the loop chopping limit rows and columns of the matrix until the center point or zero elements loop.
                xMin++;
                xMax--;
                yMin++;
                yMax--;
            }
            while (xMin < xMax);
        }

        /// <summary>
        /// Rotates the image clockwise by 180° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate180DegreesClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            // Defining limit points of the array.
            int xMin = 0;

            // Length of the rows.
            int xMax = matrix.GetLength(1) - 1;
            int yMin = 0;

            // Length of the columns.
            int yMax = matrix.GetLength(0) - 1;
            do
            {
                // Diagonal shifting from the upper left element to bottom right element of the matrix
                // and upper right one to bottom left one starting from the corner points and so on to the right corner.
                for (int count = 0; xMin + count < xMax; count++)
                {
                    ArrayExtensions.ShiftElements(ref matrix[yMin, xMin + count], ref matrix[yMax, xMax - count]);
                    ArrayExtensions.ShiftElements(ref matrix[yMin + count, xMax], ref matrix[yMax - count, xMin]);
                }

                // Every step of the loop chopping limit rows and columns of the matrix until the center point or zero elements loop.
                xMin++;
                xMax--;
                yMin++;
                yMax--;
            }
            while (xMin < xMax);
        }

        /// <summary>
        /// Rotates the image counterclockwise by 180° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate180DegreesCounterClockwise(this int[,] matrix)
        {
            // The method perform the same operation as Rotate180DegreesClockwise.
            matrix.Rotate180DegreesClockwise();
        }

        /// <summary>
        /// Rotates the image clockwise by 270° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate270DegreesClockwise(this int[,] matrix)
        {
            matrix.Rotate90DegreesCounterClockwise();
        }

        /// <summary>
        /// Rotates the image counterclockwise by 270° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate270DegreesCounterClockwise(this int[,] matrix)
        {
            // The method perform the same operation as Rotate90DegreesClockwise.
            matrix.Rotate90DegreesClockwise();
        }

        /// <summary>
        /// Rotates the image clockwise by 360° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate360DegreesClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            // There is no need to do anything with the matrix.
        }

        /// <summary>
        /// Rotates the image counterclockwise by 360° in place.
        /// </summary>
        /// <param name="matrix">Two-dimension square matrix that presents an image.</param>
        /// <exception cref="ArgumentNullException">Throw when source matrix is null.</exception>
        public static void Rotate360DegreesCounterClockwise(this int[,] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            // There is no need to do anything with the matrix.
        }

        // Shifting four selected elements clockwise.
        private static void ClockwiseShift90(ref int a, ref int b, ref int c, ref int d)
        {
            int buffer = d;
            d = c;
            c = b;
            b = a;
            a = buffer;
        }

        // Shifting four selected elements counterclockwise.
        private static void CounterClockwiseShift90(ref int a, ref int b, ref int c, ref int d)
        {
            int buffer = a;
            a = b;
            b = c;
            c = d;
            d = buffer;
        }

        // Shifting two elements between themselves.
        private static void ShiftElements(ref int a, ref int b)
        {
            int buffer = a;
            a = b;
            b = buffer;
        }
    }
}
