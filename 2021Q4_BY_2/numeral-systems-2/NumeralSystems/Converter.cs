using System;

namespace NumeralSystems
{
    /// <summary>
    /// Converts a string representations of a numbers to its integer equivalent.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-octal alphabetic characters).
        /// Valid octal alphabetic characters: 0,1,2,3,4,5,6,7.
        /// </exception>
        public static int ParsePositiveFromOctal(this string source)
        {
            int octNumber = GetIntFromOctDecHex(ParseOctal(source), 8);

            // Handle negative int value.
            if (octNumber < 0)
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number in the octal numeral system.", nameof(source));
            }

            return octNumber;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-decimal alphabetic characters).
        /// Valid decimal alphabetic characters: 0,1,2,3,4,5,6,7,8,9.
        /// </exception>
        public static int ParsePositiveFromDecimal(this string source)
        {
            int decNumber = GetIntFromOctDecHex(ParseDec(source), 10);

            // Handle negative int value.
            if (decNumber < 0)
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number in decimal numeral system.", nameof(source));
            }

            return decNumber;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid symbols (non-hex alphabetic characters).
        /// Valid hex alphabetic characters: 0,1,2,3,4,5,6,7,8,9,A(or a),B(or b),C(or c),D(or d),E(or e),F(or f).
        /// </exception>
        public static int ParsePositiveFromHex(this string source)
        {
            int hexNumber = GetIntFromOctDecHex(ParseHex(source), 16);

            // Handle negative int value.
            if (hexNumber < 0)
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number in hex numeral system.", nameof(source));
            }

            return hexNumber;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source string presents a negative number
        /// - or
        /// contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParsePositiveByRadix(this string source, int radix)
        {
            int number;
            switch (radix)
            {
                case 8:
                    {
                        number = GetIntFromOctDecHex(ParseOctal(source), 8);
                        break;
                    }

                case 10:
                    {
                        number = GetIntFromOctDecHex(ParseDec(source), 10);
                        break;
                    }

                case 16:
                    {
                        number = GetIntFromOctDecHex(ParseHex(source), 16);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.", nameof(radix));
                    }
            }

            if (number < 0)
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number.", nameof(source));
            }

            return number;
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A signed decimal value.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown if source contains invalid for given numeral system symbols
        /// -or-
        /// the radix is not equal 8, 10 or 16.
        /// </exception>
        public static int ParseByRadix(this string source, int radix)
        {
            int number;
            switch (radix)
            {
                case 8:
                    {
                        number = GetIntFromOctDecHex(ParseOctal(source), 8);
                        break;
                    }

                case 10:
                    {
                        // Checking minus sign, chopping string and marking source as negative number.
                        bool isNegative = false;
                        if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
                        {
                            throw new ArgumentException($"{nameof(source)} does not represent a positive number in decimal numeral system.", nameof(source));
                        }
                        else if (source[0] == '-')
                        {
                            isNegative = true;
                            source = source[1..];
                        }

                        number = isNegative ? -1 * GetIntFromOctDecHex(ParseDec(source), 10) : GetIntFromOctDecHex(ParseDec(source), 10);
                        break;
                    }

                case 16:
                    {
                        number = GetIntFromOctDecHex(ParseHex(source), 16);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.", nameof(radix));
                    }
            }

            return number;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the octal numeral system.</param>
        /// <param name="value">A positive decimal value.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromOctal(this string source, out int value)
        {
            bool result = false;
            try
            {
                value = GetIntFromOctDecHex(ParseOctal(source), 8);
            }
            catch (ArgumentException)
            {
                value = 0;
                return result;
            }

            return result = value > 0 || result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the decimal numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the decimal numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive value of decimal number.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromDecimal(this string source, out int value)
        {
            try
            {
                value = GetIntFromOctDecHex(ParseDec(source), 10);
            }
            catch (ArgumentException)
            {
                value = 0;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the hex numeral system.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive value of decimal number.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        public static bool TryParsePositiveFromHex(this string source, out int value)
        {
            bool result = false;
            try
            {
                value = GetIntFromOctDecHex(ParseHex(source), 16);
            }
            catch (ArgumentException)
            {
                value = 0;
                return result;
            }

            return result = value > 0 || result;
        }

        /// <summary>
        /// Converts the string representation of a positive number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a positive number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive value of decimal number.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParsePositiveByRadix(this string source, int radix, out int value)
        {
            if (radix == 8 || radix == 10 || radix == 16)
            {
                try
                {
                    value = ParsePositiveByRadix(source, radix);
                }
                catch (ArgumentException)
                {
                    value = 0;
                    return false;
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.", nameof(radix));
            }

            return true;
        }

        /// <summary>
        /// Converts the string representation of a signed number in the octal, decimal or hex numeral system to its 32-bit signed integer equivalent.
        /// A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="source">The string representation of a signed number in the the octal, decimal or hex numeral system.</param>
        /// <param name="radix">The radix.</param>
        /// <returns>A positive decimal value.</returns>
        /// <param name="value">A positive value of decimal number.</param>
        /// <returns>true if s was converted successfully; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown the radix is not equal 8, 10 or 16.</exception>
        public static bool TryParseByRadix(this string source, int radix, out int value)
        {
            if (radix == 8 || radix == 10 || radix == 16)
            {
                try
                {
                    value = ParseByRadix(source, radix);
                }
                catch (ArgumentException)
                {
                    value = 0;
                    return false;
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.", nameof(radix));
            }

            return true;
        }

        // Parsing string representation of octal number into int array. 
        private static int[] ParseOctal(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number in the octal numeral system.", nameof(source));
            }

            int index;
            int[] octalNumberArray = new int[source.Length];
            for (index = 0; index < source.Length; index++)
            {
                // Digits 0..7
                if (source[index] >= 48 && source[index] < 56)
                {
                    octalNumberArray[index] = (int)source[index] - 48;
                }
                else
                {
                    throw new ArgumentException($"{nameof(source)} does not represent a positive number in the octal numeral system.", nameof(source));
                }
            }

            return octalNumberArray;
        }

        // Parsing string representation of decimal number into int array. 
        private static int[] ParseDec(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number in decimal numeral system.", nameof(source));
            }

            int index;
            int[] decNumberArray = new int[source.Length];
            for (index = 0; index < source.Length; index++)
            {
                // Digits 0..9.
                if (source[index] >= 48 && source[index] <= 57)
                {
                    decNumberArray[index] = (int)source[index] - 48;
                }
                else
                {
                    throw new ArgumentException($"{nameof(source)} does not represent a positive number in decimal numeral system.", nameof(source));
                }
            }

            return decNumberArray;
        }

        // Parsing string representation of hexadecimal number into int array. 
        private static int[] ParseHex(this string source)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException($"{nameof(source)} does not represent a positive number in hex numeral system.", nameof(source));
            }

            int index;
            int[] hexNumberArray = new int[source.Length];
            for (index = 0; index < source.Length; index++)
            {
                // Digits 0..9.
                if (source[index] >= 48 && source[index] <= 57)
                {
                    hexNumberArray[index] = (int)source[index] - 48;
                }

                // Capital letters A..F.
                else if (source[index] >= 65 && source[index] <= 70)
                {
                    hexNumberArray[index] = (int)source[index] - 55;
                }

                // Small letters a..f.
                else if (source[index] >= 97 && source[index] <= 102)
                {
                    hexNumberArray[index] = (int)source[index] - 87;
                }
                else
                {
                    throw new ArgumentException($"{nameof(source)} does not represent a positive number in hex numeral system.", nameof(source));
                }
            }

            return hexNumberArray;
        }

        // Transforming int array to int number according to the radix.
        private static int GetIntFromOctDecHex(this int[] numberArray, int radix)
        {
            uint result = 0;

            // Return index to the last array position.
            int index = numberArray.Length - 1;

            // Calculating int representation of octal number.
            while (index >= 0)
            {
                result += (uint)(numberArray[index] * Math.Pow(radix, (numberArray.Length - 1) - index--));
            }

            return (int)result;
        }
    }
}
