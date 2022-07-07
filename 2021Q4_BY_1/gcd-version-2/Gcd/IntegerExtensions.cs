using System;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Converting a, b to absolute values.
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);

            // Implementing Euclidian algoritm.
            while (absA != 0 && absB != 0)
            {
                if (absA > absB)
                {
                    absA %= absB;
                }
                else
                {
                    absB %= absA;
                }
            }

            return absA | absB;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Calculating GCD for a, b.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
            }
            else
            {
                gcdAB = GetGcdByEuclidean(a, b);
            }

            // Calculating GCD for GCD(a, b) and absolute value of c.
            int absC = Math.Abs(c);
            return GetGcdByEuclidean(gcdAB, absC);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            // Checking the array for all zero values and any int.MinValue.
            bool allElementsAreZero = true;
            foreach (int element in other)
            {
                if (element != 0)
                {
                    allElementsAreZero = false;
                    break;
                }
            }

            bool anyElementAreIntMinValue = false;
            foreach (int element in other)
            {
                if (element == int.MinValue)
                {
                    anyElementAreIntMinValue = true;
                    break;
                }
            }

            if (a == 0 && b == 0 && allElementsAreZero)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || anyElementAreIntMinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Calculating GCD for a, b.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
            }
            else
            {
                gcdAB = GetGcdByEuclidean(a, b);
            }

            // Converting negative values of the array to absolute values and calculating GCD(GCD(a, b), other[i]).
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] < 0)
                {
                    other[i] = Math.Abs(other[i]);
                }
            }

            for (int i = 0; i <= other.Length - 1; i++)
            {
                if (gcdAB == 0 && other[i] == 0)
                {
                    gcdAB = 0;
                }
                else
                {
                    gcdAB = GetGcdByEuclidean(gcdAB, other[i]);
                }
            }

            return gcdAB;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Converting a, b to absolute values.
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);

            // GCD for the equal values is any of the values, e.g. a.
            if (absA == absB)
            {
                return absA;
            }

            // If one of the values is zero GCD is the another value.
            if (absA == 0)
            {
                return absB;
            }

            if (absB == 0)
            {
                return absA;
            }

            // Both values are even GCD = 2*GCD(a/2, b/2).
            int k;
            for (k = 0; ((absA | absB) & 1) == 0; ++k)
            {
                absA >>= 1;
                absB >>= 1;
            }

            // One value - even. The another - odd. GCD = GCD(a/2, b) or GCD (a, b/2).
            while ((absA & 1) == 0)
            {
                // Dividing by 2.
                absA >>= 1;
            }

            do
            {
                while ((absB & 1) == 0)
                {
                    // Dividing by 2.
                    absB >>= 1;
                }

                if (absA > absB)
                {
                    int tempStorage = absA;
                    absA = absB;
                    absB = tempStorage;
                }

                absB -= absA;
            }
            while (absB != 0);

            // For both even values GCD multiply on k-value. For odd - on 1.
            return absA << k;
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // If a, b are zero GCD(a, b) = 0. If not implementing the GCD(a, b) method.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
            }
            else
            {
                gcdAB = GetGcdByStein(a, b);
            }

            // Converting c-value to absolute value and calculating GCD(GCD(a, b), c).
            int absC = Math.Abs(c);
            return GetGcdByStein(gcdAB, absC);
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            // Checking the array for all zero values and any int.MinValue.
            bool allElementsAreZero = true;
            foreach (int element in other)
            {
                if (element != 0)
                {
                    allElementsAreZero = false;
                    break;
                }
            }

            bool anyElementAreIntMinValue = false;
            foreach (int element in other)
            {
                if (element == int.MinValue)
                {
                    anyElementAreIntMinValue = true;
                    break;
                }
            }

            if (a == 0 && b == 0 && allElementsAreZero)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || anyElementAreIntMinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // If a, b are zero GCD(a, b) = 0. If not implementing the GCD(a, b) method.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
            }
            else
            {
                gcdAB = GetGcdByStein(a, b);
            }

            // Converting negative values of the array to absolute values and calculating GCD(GCD(a, b), other[i]).
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] < 0)
                {
                    other[i] = Math.Abs(other[i]);
                }
            }

            for (int i = 0; i <= other.Length - 1; i++)
            {
                if (gcdAB == 0 && other[i] == 0)
                {
                    gcdAB = 0;
                }
                else
                {
                    gcdAB = GetGcdByStein(gcdAB, other[i]);
                }
            }

            return gcdAB;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Converting a, b to absolute values.
            elapsedTicks = 0;
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);

            // Implementing Euclidian algoritm and adding step counter.
            while (absA != 0 && absB != 0)
            {
                if (absA > absB)
                {
                    absA %= absB;
                }
                else
                {
                    absB %= absA;
                }

                ++elapsedTicks;
            }

            return absA | absB;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Calculating GCD for a, b.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
            }
            else
            {
                gcdAB = GetGcdByEuclidean(a, b);
            }

            // Calculating GCG(GCD(a, b), c) via the method with the step counter.
            int absC = Math.Abs(c);
            return GetGcdByEuclidean(out elapsedTicks, gcdAB, absC);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            // Checking the array for all zero values and any int.MinValue.
            bool allElementsAreZero = true;
            foreach (int element in other)
            {
                if (element != 0)
                {
                    allElementsAreZero = false;
                    break;
                }
            }

            bool anyElementAreIntMinValue = false;
            foreach (int element in other)
            {
                if (element == int.MinValue)
                {
                    anyElementAreIntMinValue = true;
                    break;
                }
            }

            if (a == 0 && b == 0 && allElementsAreZero)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || anyElementAreIntMinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Calculating GCD for a, b.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
                elapsedTicks = 1;
            }
            else
            {
                // Implemenig the method with the step counter.
                gcdAB = GetGcdByEuclidean(out elapsedTicks, a, b);
            }

            // Converting negative values of the array to absolute values and calculating GCD(GCD(a, b), other[i]) with the step counter.
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] < 0)
                {
                    other[i] = Math.Abs(other[i]);
                }
            }

            for (int i = 0; i <= other.Length - 1; i++)
            {
                if (gcdAB == 0 && other[i] == 0)
                {
                    gcdAB = 0;
                    ++elapsedTicks;
                }
                else
                {
                    gcdAB = GetGcdByEuclidean(out elapsedTicks, gcdAB, other[i]);
                }
            }

            return gcdAB;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Two numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // Converting a, b to absolute values.
            int absA = Math.Abs(a);
            int absB = Math.Abs(b);
            elapsedTicks = 0;

            // GCD for the equal values is any of the values, e.g. a.
            if (absA == absB)
            {
                elapsedTicks = 1;
                return absA;
            }

            // If one of the values is zero GCD is the another value.
            if (absA == 0)
            {
                elapsedTicks = 1;
                return absB;
            }

            if (absB == 0)
            {
                elapsedTicks = 1;
                return absA;
            }

            // Both values are even GCD = 2*GCD(a/2, b/2). elapsedTicks counts every turn of the loop.
            int k;
            for (k = 0; ((absA | absB) & 1) == 0; ++k)
            {
                absA >>= 1;
                absB >>= 1;
                ++elapsedTicks;
            }

            // One value - even. The another - odd. GCD = GCD(a/2, b) or GCD (a, b/2). elapsedTicks counts every turn of the loop.
            while ((absA & 1) == 0)
            {
                absA >>= 1;
                ++elapsedTicks;
            }

            do
            {
                while ((absB & 1) == 0)
                {
                    absB >>= 1;
                    ++elapsedTicks;
                }

                if (absA > absB)
                {
                    int tempStorage = absA;
                    absA = absB;
                    absB = tempStorage;
                }

                absB -= absA;
            }

            // For both even values GCD multiply on k-value. For odd - on 1.
            while (absB != 0);
            return absA << k;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // If a, b are zero GCD(a, b) = 0. If not implementing the GCD(a, b) method with the step counter.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
                elapsedTicks = 1;
            }
            else
            {
                gcdAB = GetGcdByStein(out elapsedTicks, a, b);
            }

            // Converting c-value to absolute value and calculating GCD(GCD(a, b), c) with the step counter.
            int absC = Math.Abs(c);
            return GetGcdByStein(out elapsedTicks, gcdAB, absC);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            // Checking the array for all zero values and any int.MinValue.
            bool allElementsAreZero = true;
            foreach (int element in other)
            {
                if (element != 0)
                {
                    allElementsAreZero = false;
                    break;
                }
            }

            bool anyElementAreIntMinValue = false;
            foreach (int element in other)
            {
                if (element == int.MinValue)
                {
                    anyElementAreIntMinValue = true;
                    break;
                }
            }

            if (a == 0 && b == 0 && allElementsAreZero)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || anyElementAreIntMinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            // If a, b are zero GCD(a, b) = 0. If not implementing the GCD(a, b) method.
            int gcdAB;
            if (a == 0 && b == 0)
            {
                gcdAB = 0;
                elapsedTicks = 1;
            }
            else
            {
                // In other way implementing GCG(a, b) with the step counter.
                gcdAB = GetGcdByStein(out elapsedTicks, a, b);
            }

            // Converting negative values of the array to absolute values and calculating GCD(GCD(a, b), other[i]) with the step counter.
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] < 0)
                {
                    other[i] = Math.Abs(other[i]);
                }
            }

            for (int i = 0; i <= other.Length - 1; i++)
            {
                if (gcdAB == 0 && other[i] == 0)
                {
                    gcdAB = 0;
                    ++elapsedTicks;
                }
                else
                {
                    gcdAB = GetGcdByStein(out elapsedTicks, gcdAB, other[i]);
                }
            }

            return gcdAB;
        }
    }
}
