using System;
using System.Collections.Generic;

namespace AnagramTask
{
    public class Anagram
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Anagram"/> class.
        /// </summary>
        /// <param name="sourceWord">Source word.</param>
        /// <exception cref="ArgumentNullException">Thrown when source word is null.</exception>
        /// <exception cref="ArgumentException">Thrown when  source word is empty.</exception>
        public Anagram(string sourceWord)
        {
            if (sourceWord == null)
            {
                throw new ArgumentNullException(nameof(sourceWord), "The word cannot be null.");
            }
            else if (string.IsNullOrEmpty(sourceWord))
            {
                throw new ArgumentException("The word cannot be empty.", nameof(sourceWord));
            }
            else
            {
                this.SourceWord = sourceWord;
            }
        }

        // Auto-implemented property immutable everywhere except the constructor for using in FindAnagrams method.
        public string SourceWord { get; }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[] candidates)
        {
            if (candidates is null)
            {
                throw new ArgumentNullException(nameof(candidates), "The list of words cannot be null.");
            }

            // Normalizing of instanse of SourceWord for comparison.
            string subject = this.SourceWord.ToUpperInvariant();

            // Dictionary for storing characters and its quantity.
            Dictionary<char, int> subjectBuffer = new Dictionary<char, int>();
            foreach (char letter in subject)
            {
                if (subjectBuffer.ContainsKey(letter))
                {
                    subjectBuffer[letter]++;
                }
                else
                {
                    subjectBuffer.Add(letter, 1);
                }
            }

            // List for storing anagrams.
            List<string> result = new List<string>();
            foreach (string candidate in candidates)
            {
                // Normalizing of each word in candidates array for comparison.
                string loopCandidate = candidate.ToUpperInvariant();

                // Creating deep clone of subjectBuffer to prevent unwanted changes in it in time of implementing the loop.
                Dictionary<char, int> loopBuffer = new Dictionary<char, int>(subjectBuffer);

                // Identical word are not an anagrams.
                if (loopCandidate.Equals(subject, StringComparison.Ordinal))
                {
                    break;
                }

                // Words with different number of letters are not anagmams too.
                if (subject.Length == loopCandidate.Length)
                {
                    // Finding and excluding from the dictionary letters existing in the both words.
                    foreach (char letter in loopCandidate)
                    {
                        // If candidate does not contain letter from SourceWord, the loop will break.
                        if (!loopBuffer.ContainsKey(letter))
                        {
                            break;
                        }

                        // Otherwise quantity of letters in the dictionary decreasing.
                        // In case when in the dictionary are no more such a letter, the letter will throw out of the dictionary.
                        else if (--loopBuffer[letter] == 0)
                        {
                            loopBuffer.Remove(letter);
                        }
                    }

                    // In case when the the buffer is empty, candidate will add to result list.
                    if (loopBuffer.Count == 0)
                    {
                        result.Add(candidate);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
