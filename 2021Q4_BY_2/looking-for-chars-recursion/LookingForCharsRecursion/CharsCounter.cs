using System;

namespace LookingForCharsRecursion
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string str, char[] chars)
        {
            // #1. Implement the method using recursive algorithm.
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "str string cannot be null.");
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars), "chars array cannot be null.");
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            int number = 0;

            // Going around all letters in the chars array recursively.
            if (chars.Length > 1)
            {
                number = GetCharsCount(str, chars[..^1]);
            }

            // Number of encounting the letters in the str string.
            number = GetCharsCount(str, chars[^1], ref number);
            return number;
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            // #2. Implement the method using recursive algorithm.
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "str string cannot be null.");
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars), "chars array cannot be null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be less than zero.");
            }
            else if (startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be greater than endIndex.");
            }

            if (endIndex > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex cannot be greater than str.Length.");
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            int number = 0;

            // Going around all letters in the chars array recursively.
            if (chars.Length > 1)
            {
                number = GetCharsCount(str[startIndex .. (endIndex + 1)], chars[.. ^1]);
            }

            // Number of encounting the letters in the str string.
            number = GetCharsCount(str[startIndex .. (endIndex + 1)], chars[^1], ref number);
            return number;
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            // #3. Implement the method using recursive algorithm.
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "str string cannot be null.");
            }

            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars), "chars array cannot be null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be less than zero.");
            }
            else if (startIndex > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be greater than str.Length.");
            }

            if (startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex cannot be greater than endIndex.");
            }

            if (endIndex > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex cannot be greater than str.Length.");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "limit cannot be less than zero.");
            }

            if (str.Length == 0 || chars.Length == 0 || limit == 0)
            {
                return 0;
            }

            int number = 0;

            // Going around all letters in the chars array recursively.
            if (chars.Length > 1)
            {
                number = GetCharsCount(str[startIndex .. (endIndex + 1)], chars[.. ^1]);
            }

            // Number of encounting the letters in the str string while that is less than the limit.
            if (number < limit)
            {
                number = GetCharsCount(str[startIndex.. (endIndex + 1)], chars[^1], ref number);
            }

            // If number of encounting is greater than the limit return the limit.
            if (number > limit)
            {
                number = limit;
            }

            return number;
        }

        // Counting quantity of the specified letter in str string.
        private static int GetCharsCount(string str, char letter, ref int number)
        {
            if (str[0] == letter)
            {
                number += 1;
            }

            if (str.Length > 1)
            {
                GetCharsCount(str[1..], letter, ref number);
            }

            return number;
        }
    }
}
