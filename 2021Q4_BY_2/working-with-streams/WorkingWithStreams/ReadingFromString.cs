using System;
using System.IO;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            // #2-1. Implement the method by reading all content as a string with StringReader.ReadToEnd method.
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            // #2-2. Implement the method by reading a line of characters with StringReader.ReadLine method.
            return stringReader.ReadLine();
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            // #2-3. Implement the method by reading the next character with StringReader.Read method.
            int charNumber = stringReader.Read();
            if (charNumber != -1)
            {
                currentChar = Convert.ToChar(charNumber);
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            // #2-4. Implement the method by returning the next available character with StringReader.Peek method.
            if (stringReader.Peek() != -1)
            {
                currentChar = Convert.ToChar(stringReader.Peek());
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            // #2-5. Implement the method by creating a new array of chars and reading a block of characters to the array.
            char[] buffer = new char[count];
            for (int i = 0; i < count; i++)
            {
                buffer[i] = Convert.ToChar(stringReader.Read());
            }

            return buffer;
        }
    }
}
