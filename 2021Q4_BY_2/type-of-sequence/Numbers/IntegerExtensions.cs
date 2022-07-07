using System;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            if (number < 10 && number > -10)
            {
                return null;
            }

            ComparisonSigns comparisonSigns = 0;
            long leftDigit, rightDigit;

            // From the last digit to the first step by step.
            while (number >= 10 || number <= -10)
            {
                rightDigit = number % 10;
                number /= 10;
                leftDigit = number % 10;
                if ((leftDigit < rightDigit && number > 0) || (leftDigit > rightDigit && number < 0))
                {
                    comparisonSigns |= ComparisonSigns.LessThan;
                }
                else if ((leftDigit > rightDigit && number > 0) || (leftDigit < rightDigit && number < 0))
                {
                    comparisonSigns |= ComparisonSigns.MoreThan;
                }
                else
                {
                    comparisonSigns |= ComparisonSigns.Equals;
                }
            }

            return comparisonSigns;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            if (number < 10 && number > -10)
            {
                return "One digit number.";
            }

            int bitResult = 0;
            long rightDigit, leftDigit;

            // From the last digit to the first step by step.
            while (number >= 10 || number <= -10)
            {
                rightDigit = number % 10;
                number /= 10;
                leftDigit = number % 10;

                // Increasing case.
                if ((leftDigit < rightDigit && number > 0) || (leftDigit > rightDigit && number < 0))
                {
                    bitResult |= 1;
                }

                // Decreasing case.
                else if ((leftDigit > rightDigit && number > 0) || (leftDigit < rightDigit && number < 0))
                {
                    bitResult |= 2;
                }

                // Equality case.
                else
                {
                    bitResult |= 4;
                }
            }

            switch (bitResult)
            {
                case 1:
                    {
                        return "Strictly Increasing.";
                    }

                case 2:
                    {
                        return "Strictly Decreasing.";
                    }

                case 4:
                    {
                        return "Monotonous.";
                    }

                case 5:
                    {
                        return "Increasing.";
                    }

                case 6:
                    {
                        return "Decreasing.";
                    }

                default:
                    {
                        return "Unordered.";
                    }
            }
        }
    }
}
