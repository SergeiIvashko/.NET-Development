using System;

namespace BinaryRepresentation
{
    public static class BitsManipulation
    {
        /// <summary>
        /// Get binary memory representation of signed long integer.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Binary memory representation of signed long integer.</returns>
        public static string GetMemoryDumpOf(long number)
        {
            long resultDigit;
            char[] result = new char[64];
            for (int i = 63; i >= 0; i--)
            {
                resultDigit = number >> i;
                if ((resultDigit & 1) == 1)
                {
                    result[63 - i] = '1';
                }
                else
                {
                    result[63 - i] = '0';
                }
            }

            return new string(result);
        }
    }
}
