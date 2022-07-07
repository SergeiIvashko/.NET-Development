using System;

namespace VowelCountTask
{
    public static class StringHelper
    {
        /// <summary>
        /// Calculates the count of vowels in the source string.
        ///  'a', 'e', 'i', 'o', and 'u' are vowels. 
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <returns>Count of vowels in the given string.</returns>
        /// <exception cref="ArgumentException">Thrown when source string is null or empty.</exception>
        public static int GetCountOfVowel(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("Source variable cannot be null or empty.", nameof(source));
            }

            int currentCharIncrement = 0;
            int numberOfVowels = 0;
            do
            {
                if (source[currentCharIncrement] == 'a' || source[currentCharIncrement] == 'e' || source[currentCharIncrement] == 'i' ||
                    source[currentCharIncrement] == 'o' || source[currentCharIncrement] == 'u')
                {
                    numberOfVowels++;
                }

                currentCharIncrement++;
            }
            while (currentCharIncrement < source.Length);

            return numberOfVowels;
        }
    }
}
