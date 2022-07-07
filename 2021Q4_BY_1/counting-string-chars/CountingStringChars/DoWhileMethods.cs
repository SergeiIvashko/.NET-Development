using System;

namespace CountingStringChars
{
    public static class DoWhileMethods
    {
        /// <summary>
        /// Returns a number of digits in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of digits in a string.</returns>
        public static int GetDigitCount(string str)
        {
            // #5. Analyze the implementation of "GetDigitCountRecursive" methods, and implement the method using the "do..while" loop statement.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), $"Value of variable {str} is null");
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int currentCharIncrement = 0;
            int numberOfDigits = 0;
            do
            {
                numberOfDigits += char.IsDigit(str[currentCharIncrement]) ? 1 : 0;
                currentCharIncrement++;
            }
            while (currentCharIncrement < str.Length);

            return numberOfDigits;
        }

        /// <summary>
        /// Returns a number of letters in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of letters in a string.</returns>
        public static int GetLetterCount(string str)
        {
            // #6. Analyze the implementation of "GetLetterCountRecursive" methods, and implement the method using the "do..while" loop statement.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str), $"Value of {str} is null");
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int currentCharIncrement = 0;
            int numberOfLetters = 0;
            do
            {
                numberOfLetters += char.IsLetter(str[currentCharIncrement]) ? 1 : 0;
                currentCharIncrement++;
            }
            while (currentCharIncrement < str.Length);

            return numberOfLetters;
        }

        /// <summary>
        /// Returns a number of digits in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of digits in a string.</returns>
        public static int GetDigitCountRecursive(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return GetDigitCountRecursive(str, str.Length, 0);
        }

        /// <summary>
        /// Returns a number of letters in a string.
        /// </summary>
        /// <param name="str">A <see cref="string"/> to search.</param>
        /// <returns>A number of letters in a string.</returns>
        public static int GetLetterCountRecursive(string str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            return GetLetterCountRecursive(str, str.Length, 0);
        }

        private static int GetDigitCountRecursive(string str, int charsLeft, int counter)
        {
            if (charsLeft > 0)
            {
                return GetDigitCountRecursive(str, charsLeft - 1, char.IsDigit(str[^charsLeft]) ? counter + 1 : counter);
            }

            return counter;
        }

        private static int GetLetterCountRecursive(string str, int charsLeft, int counter)
        {
            if (charsLeft > 0)
            {
                return GetLetterCountRecursive(str, charsLeft - 1, char.IsLetter(str[^charsLeft]) ? counter + 1 : counter);
            }

            return counter;
        }
    }
}
