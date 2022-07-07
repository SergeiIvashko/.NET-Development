using System;

namespace CountingStringChars
{
    public static class WhileMethods
    {
        /// <summary>
        /// Returns a number of white space characters in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of white space characters in a string.</returns>
        public static int GetSpaceCount(string str)
        {
            // #3. Analyze the implementation of "GetSpaceCountRecursive" method, and implement the method using the "while" loop statement.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), $"Value of variable {str} is null");
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int currentCharIncrement = 0;
            int numberOfSpaces = 0;
            while (currentCharIncrement < str.Length)
            {
                numberOfSpaces += char.IsWhiteSpace(str[currentCharIncrement]) ? 1 : 0;
                currentCharIncrement++;
            }

            return numberOfSpaces;
        }

        /// <summary>
        /// Returns a number of punctuation marks in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of punctuation marks in a string.</returns>
        public static int GetPunctuationCount(string str)
        {
            // #4. Analyze the implementation of "GetPunctuationCount" method, and implement the method using the "while" loop statement.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), $"Value of {str} is null");
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int currentCharIncrement = 0;
            int numberOfPunctuations = 0;

            while (currentCharIncrement < str.Length)
            {
                numberOfPunctuations += char.IsPunctuation(str[currentCharIncrement]) ? 1 : 0;
                currentCharIncrement++;
            }

            return numberOfPunctuations;
        }

        /// <summary>
        /// Returns a number of white space characters in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of white space characters in a string.</returns>
        public static int GetSpaceCountRecursive(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int result = GetSpaceCountRecursive(str[1..]) + (char.IsWhiteSpace(str[0]) ? 1 : 0);

            return result;
        }

        /// <summary>
        /// Returns a number of punctuation marks in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of punctuation marks in a string.</returns>
        public static int GetPunctuationCountRecursive(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            bool isPunctuation = char.IsPunctuation(str[0]);
            int currentIncrement = isPunctuation ? 1 : 0;
            int result = GetPunctuationCountRecursive(str[1..]) + currentIncrement;

            return result;
        }
    }
}
