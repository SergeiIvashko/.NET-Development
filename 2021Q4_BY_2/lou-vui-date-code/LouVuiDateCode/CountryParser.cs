using System;
using System.Collections.Generic;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            // #5. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode) || string.IsNullOrWhiteSpace(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode), "factoryLocationCode should not be null, be equal to zero-length or consist white spaces");
            }

            List<Country> result = new List<Country>();
            int countyCodeIndex = (int)Enum.Parse(typeof(CountryCode), factoryLocationCode.ToUpper(CultureInfo.CurrentCulture));
            if (countyCodeIndex == (int)CountryCode.FL || countyCodeIndex == (int)CountryCode.SD)
            {
                result.Add(Country.France);
                result.Add(Country.USA);
            }
            else if (countyCodeIndex == (int)CountryCode.LW)
            {
                result.Add(Country.France);
                result.Add(Country.Spain);
            }
            else if (countyCodeIndex <= (int)CountryCode.VX)
            {
                result.Add(Country.France);
            }
            else if (countyCodeIndex == (int)CountryCode.LP || countyCodeIndex == (int)CountryCode.OL)
            {
                result.Add(Country.Germany);
            }
            else if (countyCodeIndex > (int)CountryCode.OL && countyCodeIndex <= (int)CountryCode.TD)
            {
                result.Add(Country.Italy);
            }
            else if (countyCodeIndex > (int)CountryCode.TD && countyCodeIndex <= (int)CountryCode.UB)
            {
                result.Add(Country.Spain);
            }
            else if (countyCodeIndex == (int)CountryCode.DI || countyCodeIndex == (int)CountryCode.FA)
            {
                result.Add(Country.Switzerland);
            }
            else
            {
                result.Add(Country.USA);
            }

            return result.ToArray();
        }
    }
}
