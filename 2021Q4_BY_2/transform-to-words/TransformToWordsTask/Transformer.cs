using System;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable CA1822

namespace TransformToWordsTask
{
    /// <summary>
    /// Provides transformer methods.
    /// </summary>
    public sealed class Transformer
    {
        /// <summary>
        /// Converts number's digital representation into words.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>Words representation.</returns>
        public string TransformToWords(double number)
        {
            switch (number)
            {
                case double.NaN:
                    {
                        return "NaN";
                    }

                case double.PositiveInfinity:
                    {
                        return "Positive Infinity";
                    }

                case double.NegativeInfinity:
                    {
                        return "Negative Infinity";
                    }

                case double.Epsilon:
                    {
                        return "Double Epsilon";
                    }
            }

            string resultString = string.Format(CultureInfo.InvariantCulture, "{0}", number);
            string[] stringArray = new string[resultString.Length];
            for (int i = 0; i < resultString.Length; i++)
            {
                switch (resultString[i])
                {
                    case '0':
                        {
                            stringArray[i] = "zero";
                            break;
                        }

                    case '1':
                        {
                            stringArray[i] = "one";
                            break;
                        }

                    case '2':
                        {
                            stringArray[i] = "two";
                            break;
                        }

                    case '3':
                        {
                            stringArray[i] = "three";
                            break;
                        }

                    case '4':
                        {
                            stringArray[i] = "four";
                            break;
                        }

                    case '5':
                        {
                            stringArray[i] = "five";
                            break;
                        }

                    case '6':
                        {
                            stringArray[i] = "six";
                            break;
                        }

                    case '7':
                        {
                            stringArray[i] = "seven";
                            break;
                        }

                    case '8':
                        {
                            stringArray[i] = "eight";
                            break;
                        }

                    case '9':
                        {
                            stringArray[i] = "nine";
                            break;
                        }

                    case '-':
                        {
                            stringArray[i] = "minus";
                            break;
                        }

                    case '+':
                        {
                            stringArray[i] = "plus";
                            break;
                        }

                    case '.':
                        {
                            stringArray[i] = "point";
                            break;
                        }

                    case 'E':
                        {
                            stringArray[i] = "E";
                            break;
                        }
                }
            }

            resultString = string.Join(" ", stringArray);
            CultureInfo invC = CultureInfo.InvariantCulture;
            resultString = char.ToUpper(resultString[0], invC) + resultString[1..];
            return resultString;
        }
    }
}
