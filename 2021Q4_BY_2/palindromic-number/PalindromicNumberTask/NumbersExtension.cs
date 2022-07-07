using System;

namespace PalindromicNumberTask
{
    /// <summary>
    /// Provides static method for working with integers.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Determines if a number is a palindromic number, see https://en.wikipedia.org/wiki/Palindromic_number.
        /// </summary>
        /// <param name="number">Verified number.</param>
        /// <returns>true if the verified number is palindromic number; otherwise, false.</returns>
        /// <exception cref="ArgumentException"> Thrown when source number is less than zero. </exception>
        public static bool IsPalindromicNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number cannot be less than zero", nameof(number));
            }

            int leftDigit;
            if (number >= 1000000000)
            {
                leftDigit = number / 1000000000;
                number %= 1000000000;
            }
            else if (number >= 100000000)
            {
                leftDigit = number / 100000000;
                number %= 100000000;
            }
            else if (number >= 10000000)
            {
                leftDigit = number / 10000000;
                number %= 10000000;
            }
            else if (number >= 1000000)
            {
                leftDigit = number / 1000000;
                number %= 1000000;
            }
            else if (number >= 100000)
            {
                leftDigit = number / 100000;
                number %= 100000;
            }
            else if (number >= 10000)
            {
                leftDigit = number / 10000;
                number %= 10000;
            }
            else if (number >= 1000)
            {
                leftDigit = number / 1000;
                number %= 1000;
            }
            else if (number >= 100)
            {
                leftDigit = number / 100;
                number %= 100;
            }
            else if (number >= 10)
            {
                leftDigit = number / 10;
                number %= 10;
            }
            else
            {
                return true;
            }

            if (number == 0)
            {
                return false;
            }

            int rightDigit = number % 10;
            number /= 10;

            if (rightDigit == leftDigit && number == 0)
            {
                return true;
            }
            else if (rightDigit != leftDigit)
            {
                return false;
            }

            return IsPalindromicNumber(number);
        }
    }
}
