﻿using System;
using System.Collections.Generic;

namespace WorkingWithStrings
{
    public static class ConcatenatingStrings
    {
        /// <summary>
        /// Concatenates two specified instances of <see cref="string"/>.
        /// </summary>
        public static string ConcatenateStrings(string str1, string str2)
        {
            return string.Concat(str1, str2);
        }

        /// <summary>
        /// Concatenates three specified instances of <see cref="string"/>.
        /// </summary>
        public static string ConcatenateStrings(string str1, string str2, string str3)
        {
            // #7-1. Analyze unit tests for the method, and add the method implementation.
            // Use String.Concat method to concatenate string: https://docs.microsoft.com/en-us/dotnet/api/system.string.concat
            string str0 = str1;
            str1 = str2;
            str2 = str3;
            return string.Concat(str0, str1, str2);
        }

        /// <summary>
        /// Concatenates four specified instances of <see cref="string"/>.
        /// </summary>
        public static string ConcatenateStrings(string str1, string str2, string str3, string str4)
        {
            // #7-2. Analyze unit tests for the method, and add the method implementation.
            // Use String.Concat method to concatenate string: https://docs.microsoft.com/en-us/dotnet/api/system.string.concat
            string str0 = str1;
            str1 = str2;
            str2 = str3;
            str3 = str4;
            return string.Concat(str0, str1, str2, str3);
        }

        /// <summary>
        /// Concatenates the members of an <see cref="IEnumerable{T}"/> implementation.
        /// </summary>
        public static string ConcatenateStrings(IEnumerable<string> strings)
        {
            // #7-3. Analyze unit tests for the method, and add the method implementation.
            // Use String.Concat method to concatenate string: https://docs.microsoft.com/en-us/dotnet/api/system.string.concat
            return string.Concat(strings);
        }

        /// <summary>
        /// Concatenates the string representations of three specified objects.
        /// </summary>
        public static string ConcatenateValues(string str, int intValue, long longValue)
        {
            // #7-4. Analyze unit tests for the method, and add the method implementation.
            // Use String.Concat method to concatenate string: https://docs.microsoft.com/en-us/dotnet/api/system.string.concat
            return string.Concat(str, intValue, longValue);
        }

        /// <summary>
        /// Concatenates the string representations of four specified objects.
        /// </summary>
        public static string ConcatenateValues(short shortValue, float floatValue, bool boolValue, double doubleValue)
        {
            // #7-5. Analyze unit tests for the method, and add the method implementation.
            // Use String.Concat method to concatenate string: https://docs.microsoft.com/en-us/dotnet/api/system.string.concat
            return string.Concat(shortValue, floatValue, boolValue, doubleValue);
        }

        /// <summary>
        /// Concatenates the members of an <see cref="IEnumerable{T}"/> implementation.
        /// </summary>
        public static string ConcatenateValues(IEnumerable<object> values)
        {
            // #7-6. Analyze unit tests for the method, and add the method implementation.
            // Use String.Concat method to concatenate string: https://docs.microsoft.com/en-us/dotnet/api/system.string.concat
            return string.Concat(values);
        }
    }
}
