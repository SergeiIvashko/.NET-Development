using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            // #1-1. Analyze unit tests for the method, and add the method implementation.
            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "Manufacturing year should be in range from 1980 to 1990.");
            }
            else if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth), "A year consists only 12 months.");
            }

            return string.Concat(manufacturingYear.ToString(CultureInfo.CurrentCulture)[2..], manufacturingMonth.ToString(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            // #1-2. Analyze unit tests for the method, and add the method implementation.
            DateTime lowerLimit = new DateTime(1980, 1, 1, 00, 00, 00);
            DateTime higherLimit = new DateTime(1990, 1, 1, 00, 00, 00);
            if (manufacturingDate.CompareTo(lowerLimit) < 0 || manufacturingDate.CompareTo(higherLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date should be in range from 01/01/1980 to 01/01/1990.");
            }

            return manufacturingDate.ToString("yyM", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            // #2-1. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode string should not be null, be equal to zero-length or consist white spaces.");
            }

            if (!Enum.IsDefined(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)))
            {
                throw new ArgumentException("factoryLocationCode is not valid", nameof(factoryLocationCode));
            }

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "Manufacturing year should be in range from 1980 to 1990.");
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth), "A year consists only 12 months.");
            }

            return string.Concat(
                manufacturingYear.ToString(CultureInfo.CurrentCulture)[2..],
                manufacturingMonth.ToString(CultureInfo.CurrentCulture),
                factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            // #2-2. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode string should not be null, be equal to zero-length or consist white spaces.");
            }

            if (!Enum.IsDefined(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)))
            {
                throw new ArgumentException("factoryLocationCode is not valid", nameof(factoryLocationCode));
            }

            DateTime lowerLimit = new DateTime(1980, 1, 1, 00, 00, 00);
            DateTime higherLimit = new DateTime(1990, 1, 1, 00, 00, 00);
            if (manufacturingDate.CompareTo(lowerLimit) < 0 || manufacturingDate.CompareTo(higherLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date should be in range from 01/01/1980 to 01/01/1990.");
            }

            return string.Concat(manufacturingDate.ToString("yyM", CultureInfo.CurrentCulture), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            // #3-1. Analyze unit tests for the method, and add the method implementation.
            if (manufacturingYear < 1990 || manufacturingYear >= 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "Manufacturing year should be in range from 1990 to 2007.");
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth), "A year consists only 12 months.");
            }

            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode should not be null, be equal to zero-length or consist white spaces.");
            }

            if (!Enum.IsDefined(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)))
            {
                throw new ArgumentException("factoryLocationCode is not valid", nameof(factoryLocationCode));
            }

            return string.Concat(
                factoryLocationCode.ToUpper(CultureInfo.CurrentCulture),
                manufacturingMonth.ToString("D2", CultureInfo.CurrentCulture)[0],
                manufacturingYear.ToString(CultureInfo.CurrentCulture)[2],
                manufacturingMonth.ToString("D2", CultureInfo.CurrentCulture)[1],
                manufacturingYear.ToString(CultureInfo.CurrentCulture)[3]);
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            // #3-2. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode should not be null, be equal to zero-length or consist white spaces");
            }

            if (!Enum.IsDefined(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)))
            {
                throw new ArgumentException("factoryLocationCode is not valid", nameof(factoryLocationCode));
            }

            DateTime lowerLimit = new DateTime(1990, 1, 1, 00, 00, 00);
            DateTime higherLimit = new DateTime(2007, 1, 1, 00, 00, 00);
            if (manufacturingDate.CompareTo(lowerLimit) < 0 || manufacturingDate.CompareTo(higherLimit) >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date should be in range from 01/01/1990 to 01/01/2007.");
            }

            return string.Concat(
                factoryLocationCode.ToUpper(CultureInfo.CurrentCulture),
                manufacturingDate.ToString("MM", CultureInfo.CurrentCulture)[0],
                manufacturingDate.ToString("yy", CultureInfo.CurrentCulture)[0],
                manufacturingDate.ToString("MM", CultureInfo.CurrentCulture)[1],
                manufacturingDate.ToString("yy", CultureInfo.CurrentCulture)[1]);
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            // #4-1. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode should not be null, be equal to zero-length or consist white spaces");
            }

            if (!Enum.IsDefined(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)))
            {
                throw new ArgumentException("factoryLocationCode is not valid", nameof(factoryLocationCode));
            }

            if (manufacturingYear < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear), "Manufacturing year should be in range from 2007 to present time.");
            }

            if (manufacturingWeek < 1 || manufacturingWeek > ISOWeek.GetWeeksInYear((int)manufacturingYear))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek), "Invalid number of weeks in the year.");
            }

            return string.Concat(
                factoryLocationCode.ToUpper(CultureInfo.CurrentCulture),
                manufacturingWeek.ToString("D2", CultureInfo.CurrentCulture)[0],
                manufacturingYear.ToString(CultureInfo.CurrentCulture)[2],
                manufacturingWeek.ToString("D2", CultureInfo.CurrentCulture)[1],
                manufacturingYear.ToString(CultureInfo.CurrentCulture)[3]);
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            // #4-2. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode should not be null, be equal to zero-length or consist white spaces");
            }

            if (!Enum.IsDefined(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)))
            {
                throw new ArgumentException("factoryLocationCode is not valid", nameof(factoryLocationCode));
            }

            if (manufacturingDate.CompareTo(ISOWeek.GetYearStart(2007)) < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate), "Manufacturing date should start from the beginning of 2007 ISO week-numbering year.");
            }

            return string.Concat(
                factoryLocationCode.ToUpper(CultureInfo.CurrentCulture),
                ISOWeek.GetWeekOfYear(manufacturingDate).ToString("D2", CultureInfo.CurrentCulture)[0],
                ISOWeek.GetYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[^2],
                ISOWeek.GetWeekOfYear(manufacturingDate).ToString("D2", CultureInfo.CurrentCulture)[1],
                ISOWeek.GetYear(manufacturingDate).ToString(CultureInfo.CurrentCulture)[^1]);
        }
    }
}
