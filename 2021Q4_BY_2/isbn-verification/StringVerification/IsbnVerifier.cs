using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringVerification
{
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 identification number of book.
        /// </summary>
        /// <param name="number">The string representation of book's number.</param>
        /// <returns>true if number is a valid ISBN-10 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentException">Thrown if number is null or empty or whitespace.</exception>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Number should not be null, empty or white spase", nameof(number));
            }

            // Required format of the string: X-XXX-XXXXX-X
            var threeHyphens = new Regex("^\\d-\\d{3}-\\d{5}-(\\u0058$|\\d$)");

            // Required format of the string: X-XXX-XXXXXX
            var twoHyphensBegin = new Regex("^\\d-\\d{3}-(\\u0058$|\\d{6}$)");

            // Required format of the string: XXXX-XXXXX-X
            var twoHyphensEnd = new Regex("^\\d{4}-\\d{5}-(\\u0058$|\\d$)");

            // Required format of the string: XXXXXXXXX-X or XXXXXXXXXX
            var oneOrNoHyphens = new Regex("(^\\d{9}-|^\\d{9})(\\u0058$|\\d$)");

            // Checking if number string matches required input format.
            if (!threeHyphens.IsMatch(number) && !twoHyphensBegin.IsMatch(number) && !twoHyphensEnd.IsMatch(number) && !oneOrNoHyphens.IsMatch(number))
            {
                return false;
            }

            // Removing "-", perlacing "X" on 10 and parcing.
            number = number.Replace("-", string.Empty, StringComparison.Ordinal);
            int[] numberList = number.ToCharArray().Select(i => i == 'X' ? 10 : int.Parse(i.ToString(), CultureInfo.InvariantCulture)).ToArray();

            // Checking the control sum.
            int checkSum = 0;
            for (int i = 0; i < numberList.Length; i++)
            {
                checkSum += (10 - i) * numberList[i];
            }

            if (checkSum % 11 == 0)
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
