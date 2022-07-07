using System;
using System.Collections.Generic;

namespace SequencesTask
{
    public static class Sequences
    {
        /// <summary>
        /// Find all the contiguous substrings of length length in given string of digits in the order that they appear.
        /// </summary>
        /// <param name="numbers">Source string.</param>
        /// <param name="length">Length of substring.</param>
        /// <returns>All the contiguous substrings of length n in that string in the order that they appear.</returns>
        /// <exception cref="ArgumentException">
        /// Throw if length of substring less and equals zero
        /// -or-
        /// more than length of source string
        /// - or-
        /// source string containing a non-digit character
        /// - or
        /// source string is null or empty or white space.
        /// </exception>
        public static string[] GetSubstrings(string numbers, int length)
        {
            if (string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
            {
                throw new ArgumentException("Numbers string cannot be null or empty.", nameof(numbers));
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!char.IsDigit(numbers[i]))
                {
                    throw new ArgumentException("Numbers cannot contain any non digit characters.", nameof(numbers));
                }
            }

            if (length <= 0 || length > numbers.Length)
            {
                throw new ArgumentException("Length cannot be equal zero or negative, or be qreater than numbers string length.", nameof(length));
            }

            int startIndex = 0;
            List<string> result = new List<string>();
            while (true)
            {
                result.Add(numbers.Substring(startIndex, length));
                startIndex++;
                if (startIndex + length > numbers.Length)
                {
                    break;
                }
            }

            return result.ToArray();
        }
    }
}
