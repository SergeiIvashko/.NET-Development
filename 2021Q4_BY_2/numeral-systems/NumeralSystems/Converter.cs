using System;

namespace NumeralSystems
{
    public static class Converter
    {
        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the octal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the octal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveOctal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can not be less than zero.", nameof(number));
            }

            return GetDecHexOct(number, 8);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the decimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the decimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveDecimal(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can not be less than zero.", nameof(number));
            }

            return GetDecHexOct(number, 10);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in the hexadecimal numeral systems.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The equivalent string representation of the number in the hexadecimal numeral systems.</returns>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveHex(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can not be less than zero.", nameof(number));
            }

            return GetDecHexOct(number, 16);
        }

        /// <summary>
        /// Gets the value of a positive integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        /// <exception cref="ArgumentException">Thrown if number is less than zero.</exception>
        public static string GetPositiveRadix(this int number, int radix)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can not be less than zero.", nameof(number));
            }

            if (radix == 8 || radix == 10 || radix == 16)
            {
                return GetDecHexOct(number, radix);
            }
            else
            {
                throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.", nameof(radix));
            }
        }

        /// <summary>
        /// Gets the value of a signed integer to its equivalent string representation in a specified radix.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <param name="radix">Base of the numeral systems.</param>
        /// <returns>The equivalent string representation of the number in a specified radix.</returns>
        /// <exception cref="ArgumentException">Thrown if radix is not equal 8, 10 or 16.</exception>
        public static string GetRadix(this int number, int radix)
        {
            if (radix == 8 || radix == 16)
            {
                return GetDecHexOct(number, radix);
            }
            else if (radix == 10)
            {
                if (number >= 0)
                {
                    return GetDecHexOct(number, radix);
                }
                else
                {
                    return string.Concat("-", GetDecHexOct(number, radix));
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(radix)} is 8, 10 and 16 only.", nameof(radix));
            }
        }

        // Getting decimal, octal or hexadecimal equivalent string representation of integer number.
        private static string GetDecHexOct(this int number, int radix)
        {
            // Converting signed integer to its unsigned representation.
            uint uNumber = (uint)number;

            // Creation of an array with max number of members which represent transformable number.
            char[] resultCharArray = new char[11];

            // Zero number case handling. 
            if (uNumber == 0)
            {
                resultCharArray[10] = '0';
            }
            else
            {
                for (int i = 0; i < resultCharArray.Length; i++)
                {
                    uint quotient = uNumber / (uint)radix;
                    uint charValue = uNumber - (quotient * (uint)radix);
                    uNumber = quotient;

                    // Transformation numerical representation of the number to chars.
                    resultCharArray[10 - i] = (charValue < 10) ?
                        (char)(charValue + '0') :
                        (char)(charValue + 'A' - 10);
                }
            }

            return new string(resultCharArray).TrimStart('0').PadLeft(1, '0');
        }
    }
}
