using System;

namespace LookingForChars
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
            // #1. Implement the method using "for" statement.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), "Str string should not be null");
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars), "Chars array should not be null");
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            int numberOfChars = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    numberOfChars += str[j] == chars[i] ? 1 : 0;
                }
            }

            return numberOfChars;
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences
        /// of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            // #2. Implement the method using "while" statement.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), "Str string should not be null");
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars), "Chars array should not be null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index should be greater than zero");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index should be less than str.Length");
            }

            if (endIndex < startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "End index should be greater than start index");
            }

            if (endIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "End index should be less than str.Length");
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            int numberOfChars = 0;
            int charsIndex = 0;
            int strIndex;
            while (charsIndex < chars.Length)
            {
                strIndex = 0;
                while (strIndex < str.Length)
                {
                    if (chars[charsIndex] == str[strIndex] && strIndex >= startIndex && strIndex <= endIndex)
                    {
                        numberOfChars++;
                    }

                    strIndex++;
                }

                charsIndex++;
            }

            return numberOfChars;
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns
        /// the number of occurrences of all characters within the range of elements in the <see cref="string"/>
        /// that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            // #3. Implement the method using "do..while" statements.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), "Str string should not be null");
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars), "Chars array should not be null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex should not be less than zero");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex should not be greater than str.Length");
            }

            if (endIndex < startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex should not be less than startIndex");
            }

            if (endIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex), "endIndex should not be greater than str.Length");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit shoul not be less than zero");
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            int numberOfChars = 0;
            int charsIndex = 0;
            int strIndex;
            do
            {
                strIndex = startIndex;
                do
                {
                    numberOfChars += chars[charsIndex] == str[strIndex] ? 1 : 0;
                    if (numberOfChars == limit)
                    {
                        return numberOfChars;
                    }

                    strIndex++;
                }
                while (strIndex <= endIndex);

                charsIndex++;
            }
            while (charsIndex < chars.Length);

            return numberOfChars;
        }
    }
}
