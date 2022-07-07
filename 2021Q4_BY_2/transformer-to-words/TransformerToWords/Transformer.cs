using System;
using System.Globalization;

namespace TransformerToWords
{
    /// <summary>
    /// Implements transformer class.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms each element of source array into its 'word format'.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of 'word format' of elements of source array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <example>
        /// new[] { 2.345, -0.0d, 0.0d, 0.1d } => { "Two point three four five", "Minus zero", "Zero", "Zero point one" }.
        /// </example>
#pragma warning disable CA1822 // Mark members as static
        public string[] Transform(double[] source)
#pragma warning restore CA1822 // Mark members as static
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "Array cannot be null.");
            }
            else if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            // The array to storing digits from source in "word format".
            string[] resultArray = new string[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                // Handling System.Double fields.
                if (double.IsNaN(source[i]) || source[i] == double.Epsilon || source[i] == double.MinValue || 
                    source[i] == double.MaxValue || double.IsNegativeInfinity(source[i]) ||
                    double.IsPositiveInfinity(source[i]))
                {
                    resultArray[i] = source[i] switch
                    {
                        double.NaN => "Not a Number",
                        double.Epsilon => "Double Epsilon",
                        double.MinValue => "Minus one point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight",
                        double.MaxValue => "One point seven nine seven six nine three one three four eight six two three one five seven E plus three zero eight",
                        double.NegativeInfinity => "Negative Infinity",
                        double.PositiveInfinity => "Positive Infinity",
                        _ => throw new ArgumentException("Source is not one of fields of System.Double", nameof(source))
                    };
                }

                // Hadnling ordinar numbers.
                else
                {
                    // Represtenting the number in sting format.
                    string sourceString = string.Format(CultureInfo.CurrentCulture, "{0}", source[i]);

                    // Buffer array to storing "word format" digits.
                    string[] buffer = new string[sourceString.Length];

                    // "Word format" source array.
                    string[] wordsArray = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                    for (int index = 0; index < sourceString.Length; index++)
                    {
                        // Numbers from 0 to 9.
                        if ((byte)sourceString[index] >= 48 && (byte)sourceString[index] <= 57)
                        {
                            buffer[index] = wordsArray[(byte)sourceString[index] - 48];
                        }
                        else if (sourceString[index] == '-')
                        {
                            buffer[index] = "minus";
                        }

                        // '.' or ',' depends on CultureInfo.
                        else if (sourceString[index] == '.' || sourceString[index] == ',')
                        {
                            buffer[index] = "point";
                        }
                        else if (sourceString[index] == 'e' || sourceString[index] == 'E')
                        {
                            buffer[index] = "E";
                        }
                        else if (sourceString[index] == '+')
                        {
                            buffer[index] = "plus";
                        }
                        else
                        {
                            throw new ArgumentException("Source string consists not acceptable sign.", nameof(source));
                        }
                    }

                    sourceString = string.Join(" ", buffer);
                    sourceString = char.ToUpper(sourceString[0], CultureInfo.CurrentCulture) + sourceString[1..];
                    resultArray[i] = sourceString;
                }
            }

            return resultArray;
        }
    }
}
