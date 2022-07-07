using System;
using System.IO;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class WritingToString
    {
        public static void WriteString(StringWriter stringWriter, string contentToWrite)
        {
            // #3-1. Implement the method by writing the string content to the StringWriter with StringWriter.Write method.
            stringWriter.Write(contentToWrite);
        }

        public static void WriteChar(StringWriter stringWriter, char charToWrite)
        {
            // #3-2. Implement the method by writing the character to the StringWriter.
            stringWriter.Write(charToWrite);
        }

        public static void WriteInteger(StringWriter stringWriter, int integerToWrite)
        {
            // #3-3. Implement the method by writing the integer to the StringWriter.
            stringWriter.Write(integerToWrite);
        }

        public static void WriteIntegerWithNewLine(StringWriter stringWriter, int integerToWrite)
        {
            // #3-4. Implement the method by writing the integer followed by line terminator to the StringWriter with StringWriter.WriteLine method.
            stringWriter.WriteLine(integerToWrite);
        }

        public static void WriteFloat(StringWriter stringWriter, float floatToWrite)
        {
            // #3-5. Implement the method by writing the float number to the StringWriter.
            stringWriter.Write(floatToWrite);
        }

        public static void WriteFloatWithNewLine(StringWriter stringWriter, float floatToWrite)
        {
            // #3-6. Implement the method by writing the float number followed by line terminator to the StringWriter.
            stringWriter.WriteLine(floatToWrite);
        }

        public static void WriteBooleansWithNewLines(StringWriter stringWriter, bool firstBoolean, bool secondBoolean, bool thirdBoolean)
        {
            // #3-7. Implement the method by writing the three booleans to the StringWriter with StringWriter.Write(bool) and StringWriter.WriteLine(bool) methods.
            stringWriter.WriteLine(firstBoolean);
            stringWriter.WriteLine(secondBoolean);
            stringWriter.Write(thirdBoolean);
        }

        public static void WriteCharBuffer(StringWriter stringWriter, char[] buffer)
        {
            // #3-8. Implement the method by writing the block of characters to the StringWriter with StringWriter.Write method.
            for (int i = 2; i <= 4; i++)
            {
                stringWriter.Write(buffer[i]);
            }
        }

        public static void WriteCharBufferWithNewLines(StringWriter stringWriter, char[] buffer)
        {
            // #3-9. Implement the method by writing the block of characters to the StringWriter with StringWriter.WriteLine method.
            for (int i = 1; i < buffer.Length - 1; i++)
            {
                if (i == buffer.Length - 2)
                {
                    stringWriter.WriteLine(buffer[i]);
                }
                else
                {
                    stringWriter.Write(buffer[i]);
                }
            }
        }
    }
}
