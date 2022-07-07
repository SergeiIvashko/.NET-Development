using System;
using System.Globalization;
using System.Text;

namespace LanguageGame
{
    public static class Translator
    {
        /// <summary>
        /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
        /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
        /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
        ///   placed at the end of the word sequence. Then, "ay" is added.
        /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
        /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
        /// </summary>
        /// <param name="phrase">Source phrase.</param>
        /// <returns>Phrase in Pig Latin.</returns>
        /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
        /// <example>
        /// "apple" -> "appleyay"
        /// "Eat" -> "Eatyay"
        /// "explain" -> "explainyay"
        /// "Smile" -> "Ilesmay"
        /// "Glove" -> "Oveglay".
        /// </example>
        public static string TranslateToPigLatin(string phrase)
        {
            if (string.IsNullOrEmpty(phrase) || string.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentException("Phrase cannot be null or empty.");
            }

            char[] separators = new char[] { ' ', '.', ',', '-', ':', ';', '!' };
            char[] vowels = new char[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

            // Decomposing phrase to chars for the next composing as the Pig Latin phrase with the same punctuation.
            char[] phraseCharArray = phrase.ToCharArray();

            // Create a string array that includes each word from the phrase.
            string[] words = phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string buffer;

            // In-place changing words array to the Pig Latin words.
            for (int i = 0; i < words.Length; i++)
            {
                // If a word starts with a vowel.
                if (words[i].IndexOfAny(vowels) == 0)
                {
                    buffer = words[i] + "yay";
                    words[i] = buffer;
                }

                // If a word does not contain any vowel.
                else if (words[i].IndexOfAny(vowels) == -1)
                {
                    buffer = words[i] + "ay";
                    words[i] = buffer;
                }

                // If a word starts with a consonant.
                else
                {
                    // A word starts with an uppercase.
                    if (char.IsUpper(words[i][0]))
                    {
                        buffer = char.ToUpper(words[i][words[i].IndexOfAny(vowels)], CultureInfo.InvariantCulture) + 
                            words[i][(words[i].IndexOfAny(vowels) + 1) ..] + char.ToLower(words[i][0], CultureInfo.InvariantCulture) + 
                            words[i][1..words[i].IndexOfAny(vowels)] + "ay";
                        words[i] = buffer;
                    }

                    // A word starts with an lowercase.
                    else
                    {
                        buffer = words[i][words[i].IndexOfAny(vowels) ..] + words[i][0..words[i].IndexOfAny(vowels)] + "ay";
                        words[i] = buffer;
                    }
                }
            }

            // Index of words array.
            int wordsIndex = 0;

            // Index of phraseCharArray.
            int index = 0;
            StringBuilder result = new StringBuilder();

            // Composing phrase with the Pig Latin words.
            while (index < phraseCharArray.Length)
            {
                // Inserting the Pig Lating word when a char is letter of apostrophe.
                if (IsLetterOrQuote(phraseCharArray[index]))
                {
                    result.Append(words[wordsIndex]);

                    // Increasing wordsIndex to the next Pig Latin word.
                    wordsIndex++;

                    // Skipping remaining letters of the word.
                    while (IsLetterOrQuote(phraseCharArray[index]))
                    {
                        index++;

                        // If the letter the last letter in the phrase.
                        if (index >= phraseCharArray.Length)
                        {
                            break;
                        }
                    }
                }

                // If a sign not a letter or an apostrophe inserting char from phraseCharArray.
                else
                {
                    result.Append(phraseCharArray[index]);
                    index++;
                }
            }

            return result.ToString();
        }

        // Check if a sign is a letter or an apostrophe.
        private static bool IsLetterOrQuote(char a)
        {
            if (char.IsLetter(a) || char.Equals(a, '’') || char.Equals(a, '\''))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
