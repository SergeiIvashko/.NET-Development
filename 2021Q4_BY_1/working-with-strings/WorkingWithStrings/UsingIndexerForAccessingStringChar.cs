using System;

namespace WorkingWithStrings
{
    public static class UsingIndexerForAccessingStringChar
    {
        /// <summary>
        /// Gets the first character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetFirstChar(string str)
        {
            return str[0];
        }

        /// <summary>
        /// Gets the second character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetSecondChar(string str)
        {
            // #3-1. Analyze unit tests for the method, and add the method implementation.
            // Use index to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[1];
        }

        /// <summary>
        /// Gets the third character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetThirdChar(string str)
        {
            // #3-2. Analyze unit tests for the method, and add the method implementation.
            // Use index to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[2];
        }

        /// <summary>
        /// Gets the last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetLastChar(string str)
        {
            // #3-3. Analyze unit tests for the method, and add the method implementation.
            // Use index from end operator to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[^1];
        }

        /// <summary>
        /// Gets the next to last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNextToLastChar(string str)
        {
            // #3-4. Analyze unit tests for the method, and add the method implementation.
            // Use index from end operator to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[^2];
        }

        /// <summary>
        /// Gets the third character from the end of the <paramref name="str"/> string.
        /// </summary>
        public static char GetThirdCharFromEnd(string str)
        {
            // #3-5. Analyze unit tests for the method, and add the method implementation.
            // Use index from end operator to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[^3];
        }

        /// <summary>
        /// Gets the n-th character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNthChar(string str, int n)
        {
            // #3-6. Analyze unit tests for the method, and add the method implementation.
            // Use index to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[n - 1];
        }

        /// <summary>
        /// Gets the n-th character from the end of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNthCharFromEnd(string str, int n)
        {
            // #3-7. Analyze unit tests for the method, and add the method implementation.
            // Use index from end operator to access a string character: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return str[^n];
        }

        /// <summary>
        /// Gets the last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetLastCharUsingLength(string str)
        {
            // #3-8. Analyze unit tests for the method, and add the method implementation.
            // Use String.Length property to get a string length: https://docs.microsoft.com/en-us/dotnet/api/system.string.length
            return str[str.Length - 1];
        }

        /// <summary>
        /// Gets the next to last character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNextToLastCharUsingLength(string str)
        {
            // #3-9. Analyze unit tests for the method, and add the method implementation.
            // Use String.Length property to get a string length: https://docs.microsoft.com/en-us/dotnet/api/system.string.length
            return str[str.Length - 2];
        }

        /// <summary>
        /// Gets the fifth character from the end of the <paramref name="str"/> string.
        /// </summary>
        public static char GetFifthCharFromEndUsingLength(string str)
        {
            // #3-10. Analyze unit tests for the method, and add the method implementation.
            // Use String.Length property to get a string length: https://docs.microsoft.com/en-us/dotnet/api/system.string.length
            return str[str.Length - 5];
        }

        /// <summary>
        /// Gets the n-th character of the <paramref name="str"/> string.
        /// </summary>
        public static char GetNthCharFromEndUsingLength(string str, int n)
        {
            // #3-11. Analyze unit tests for the method, and add the method implementation.
            // Use String.Length property to get a string length: https://docs.microsoft.com/en-us/dotnet/api/system.string.length
            return str[str.Length - n];
        }

        /// <summary>
        /// Gets special code characters from <paramref name="serialNumber"/>.
        /// </summary>
        public static void GetSpecialCodes(string serialNumber, out char expectedCode1, out char expectedCode2, out char expectedCode3)
        {
            // #3-12. Analyze unit tests for the method, and add the method implementation.
            expectedCode1 = serialNumber[1];
            expectedCode2 = serialNumber[^8];
            expectedCode3 = serialNumber[^4];
        }
    }
}
