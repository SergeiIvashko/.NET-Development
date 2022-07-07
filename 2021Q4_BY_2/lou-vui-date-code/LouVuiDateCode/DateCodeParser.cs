using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // #6. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode), "dateCode string should not be null, be equal to zero-length or consist white spaces.");
            }

            if (dateCode.Length < 3 || dateCode.Length > 4)
            {
                throw new ArgumentException("dateCode contains not acceptable number of signs.", nameof(dateCode));
            }

            string manufacturingYearString = dateCode[..2];
            string manufacturingMonthString = dateCode[2..];
            manufacturingYear = 1900u + uint.Parse(manufacturingYearString, CultureInfo.CurrentCulture);

            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentException("manufacturingYear does not fit the required time period of the dateCode format.", nameof(manufacturingYear));
            }

            manufacturingMonth = uint.Parse(manufacturingMonthString, CultureInfo.CurrentCulture);

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentException("manufacturingMonth is out of range of 12 months.", nameof(manufacturingMonth));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // #7. Analyze unit tests for the method, and add the method implementation.
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode), "dateCode string should not be null, be equal to zero-length or consist white spaces.");
            }

            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("dateCode contains not acceptable number of signs.", nameof(dateCode));
            }

            string manufacturingTimeString = dateCode[..^2];
            ParseEarly1980Code(manufacturingTimeString, out manufacturingYear, out manufacturingMonth);
            factoryLocationCode = dateCode[^2..];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            // #8. Analyze unit tests for the method, and add the method implementation.
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode), "dateCode string should not be null, be equal to zero-length or consist white spaces.");
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("dateCode contains not acceptable number of signs.", nameof(dateCode));
            }

            string manufacturingYearString = string.Concat(dateCode[^3], dateCode[^1]);
            if (char.GetNumericValue(dateCode[^3]) == 9.0)
            {
                manufacturingYear = 1900 + uint.Parse(manufacturingYearString, CultureInfo.CurrentCulture);
            }
            else if (char.GetNumericValue(dateCode[^3]) == 0.0 && char.GetNumericValue(dateCode[^1]) <= 6.0)
            {
                manufacturingYear = 2000 + uint.Parse(manufacturingYearString, CultureInfo.CurrentCulture);
            }
            else
            {
                throw new ArgumentException("manufacturingYear does not fit the required time period of the dateCode format.", nameof(manufacturingYear));
            }

            string manufacturingMonthString = string.Concat(dateCode[^4], dateCode[^2]);
            manufacturingMonth = uint.Parse(manufacturingMonthString, CultureInfo.CurrentCulture);
            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentException("manufacturingMonth is out of range of 12 months.", nameof(manufacturingMonth));
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            // #9. Analyze unit tests for the method, and add the method implementation.
            // Use CountryParser.GetCountry method to get a list of countries by a factory code.
            if (string.IsNullOrEmpty(dateCode) || string.IsNullOrWhiteSpace(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode), "dateCode string should not be null, be equal to zero-length or consist white spaces.");
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("dateCode contains not acceptable number of signs.", nameof(dateCode));
            }

            string manufacturingYearString = string.Concat(dateCode[^3], dateCode[^1]);
            manufacturingYear = 2000u + uint.Parse(manufacturingYearString, CultureInfo.CurrentCulture);
            if (manufacturingYear < 2007)
            {
                throw new ArgumentException("manufacturingYear does not fit the required time period of the dateCode format.", nameof(manufacturingYear));
            }

            string manufacturingWeekString = string.Concat(dateCode[^4], dateCode[^2]);
            manufacturingWeek = uint.Parse(manufacturingWeekString, CultureInfo.CurrentCulture);
            if (manufacturingWeek < 1 || manufacturingWeek > ISOWeek.GetWeeksInYear((int)manufacturingYear))
            {
                throw new ArgumentException("manufacturingWeek is out of range of ISO weeks for the year.");
            }

            factoryLocationCode = dateCode[..2];
            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
        }
    }
}
