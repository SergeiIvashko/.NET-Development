using System;

namespace WorkingWithStrings
{
    public static class SplittingStrings
    {
        /// <summary>
        /// Splits a comma-separated string into substrings that are based on the comma character, and return an array whose elements contain the substrings.
        /// </summary>
        public static string[] SplitCommaSeparatedString(string str)
        {
            return str.Split(',');
        }

        /// <summary>
        /// Splits a colon-separated string into substrings that are based on the colon character, and return an array whose elements contain the substrings.
        /// </summary>
        public static string[] SplitColonSeparatedString(string str)
        {
            // #5-1. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            return str.Split(':');
        }

        /// <summary>
        /// Splits a comma-separated string into substrings that are based on the comma character, and return an array whose elements contain the substrings.
        /// </summary>
        public static string[] SplitCommaSeparatedStringMaxTwoElements(string str)
        {
            // #5-2. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            return str.Split(',', 2);
        }

        /// <summary>
        /// Splits a colon-separated string into substrings that are based on the colon character, and return an array whose elements contain the substrings.
        /// </summary>
        public static string[] SplitColonSeparatedStringMaxThreeElements(string str)
        {
            // #5-3. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            return str.Split(':', 3);
        }

        /// <summary>
        /// Splits a hyphen-separated string into substrings that are based on the hyphen character, and return an array whose elements contain the substrings.
        /// </summary>
        public static string[] SplitHyphenSeparatedStringMaxThreeElementsRemoveEmptyStrings(string str)
        {
            // #5-4. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            return str.Split('-', 3, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits a separated string that is separated with colon and comma characters into substrings, and return an array whose elements contain the substrings.
        /// </summary>
        public static string[] SplitColonAndCommaSeparatedStringMaxFourElementsRemoveEmptyStrings(string str)
        {
            // #5-5. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            char[] wordSeparator = { ':', ',' };
            return str.Split(wordSeparator, 4, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits a sentence into substrings, and return an array whose elements contain only words.
        /// </summary>
        public static string[] GetOnlyWords(string str)
        {
            // #5-6. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            char[] wordSeparator = { ':', '.', ',', '\t', '!', '?', '-', ';', ' ' };
            return str.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Splits a CSV (comma-separated values) string into substrings that are based on the comma character, and return an array of the CSV line elements.
        /// </summary>
        public static string[] GetDataFromCsvLine(string str)
        {
            // #5-7. Analyze unit tests for the method, and add the method implementation.
            // Use String.Split method: https://docs.microsoft.com/en-us/dotnet/api/system.string.split
            char[] wordSeparator = { ' ', ',' };
            return str.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
