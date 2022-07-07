using System;
using System.Collections.Generic;

namespace ShuffleCharacters
{
    public static class StringExtension
    {
        /// <summary>
        /// Shuffles characters in source string according some rule.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="count">The count of iterations.</param>
        /// <returns>Result string.</returns>
        /// <exception cref="ArgumentException">Source string is null or empty or white spaces.</exception>
        /// <exception cref="ArgumentException">Count of iterations is less than 0.</exception>
        public static string ShuffleChars(string source, int count)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Source string should not be null or empty, or contains only white spaces", nameof(source));
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == '\n' || source[i] == '\t' || source[i] == '\r' || source[i] == '\v')
                {
                    throw new ArgumentException("Source string should not contain tabulation characters", nameof(source));
                }
            }

            if (count < 0)
            {
                throw new ArgumentException("Count should not be less than zero", nameof(count));
            }

            if (count == 0)
            {
                return source;
            }

            if (source.Length <= 2)
            {
                return source;
            }

            // ShuffleElement method rearrange int array to condition in which even elements combined at the beginning of the array
            // and odd elements combined at the end of the array.
            static void ShuffleElement(int[] array)
            {
                // The first odd idex from the beginning.
                int forwardIndex = 1;

                // The first even index from the end in case of an even length array and odd length array.
                int backwardIndex = array.Length % 2 == 0 ? array.Length - 2 : array.Length - 1;

                // Outer loop for step over members which was placed in required position as result of implementing the inner loop.
                while (forwardIndex < backwardIndex)
                {
                    int innerForwardIndex = forwardIndex;
                    int innerBackwardIndex = backwardIndex;

                    // Inner loop for movind members of array to according end of the array. In result next to the ends members placed in required position.
                    while (innerForwardIndex < innerBackwardIndex)
                    {
                        // Replacing members from backward end of the array.
                        var tmp = array[innerBackwardIndex];
                        array[innerBackwardIndex] = array[innerBackwardIndex - 1];
                        array[innerBackwardIndex - 1] = tmp;
                        innerBackwardIndex -= 2;

                        // Replacing members from forward end of the array.
                        if (innerForwardIndex < innerBackwardIndex)
                        {
                            tmp = array[innerForwardIndex];
                            array[innerForwardIndex] = array[innerForwardIndex + 1];
                            array[innerForwardIndex + 1] = tmp;
                        }

                        innerForwardIndex += 2;
                    }

                    forwardIndex++;
                    backwardIndex--;
                }
            }

            // Creating int array which represent source string.
            int[] intMaskArray = new int[source.Length];

            // Filling int array by ordinal numbers which in further are source of indexes for rearranging source string.
            for (int i = 0; i < source.Length; i++)
            {
                intMaskArray[i] = i;
            }

            // Calculating number of shuffling operations after which array return into initial condition
            // for shortening number of required operations according to count parameter.
            int repetitionCount = 0;
            do
            {
                repetitionCount++;
                ShuffleElement(intMaskArray);
            }
            while (intMaskArray[1] != 1);

            // Shuffling array via short number of operations equal to count operations.
            for (int i = 1; i <= count % repetitionCount; i++)
            {
                ShuffleElement(intMaskArray);
            }

            // Creating char array for editing source string according to intMaskArray.
            char[] sourceArray = new char[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                sourceArray[i] = source[intMaskArray[i]];
            }

            source = string.Join(string.Empty, sourceArray);
            return source;
        }
    }
}
