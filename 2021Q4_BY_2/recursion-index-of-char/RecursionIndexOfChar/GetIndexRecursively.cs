using System;

namespace RecursionIndexOfChar
{
    public static class GetIndexRecursively
    {
        public static int GetIndexOfChar(string str, char value)
        {
            // #1. Analyze the implementation of "GetLastIndexOfChar(string, char)" method, and implement the method using recursion.
            // The method should return the position of a "value" char in the "str" string. If "str" string has no "value" char then returns -1.
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "str string cannot be null.");
            }

            return GetIndexOfChar(str, value, 0);
        }

        public static int GetIndexOfChar(string str, char value, int startIndex, int count)
        {
            // #2. Analyze the implementation of "GetLastIndexOfChar(string, char, int, int)" method, and implement the method using recursion.
            // The method should return the position of a "value" char in the "str" string. If "str" string has no "value" char then returns -1.
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "str string cannot be null.");
            }

            if (string.IsNullOrEmpty(str) || count == 0)
            {
                return -1;
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > str.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater or equals str.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex + count > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > str.Length");
            }

            return GetIndexOfChar(str[startIndex .. (startIndex + count)], value, startIndex);
        }

        private static int GetIndexOfChar(string str, char value, int index)
        {
            if (string.IsNullOrEmpty(str))
            {
                return -1;
            }

            if (str[0] == value)
            {
                return index;
            }

            index += 1;
            return GetIndexOfChar(str[1 ..], value, index);
        }
    }
}
