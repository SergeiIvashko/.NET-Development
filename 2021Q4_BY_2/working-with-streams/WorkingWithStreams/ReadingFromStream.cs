using System;
using System.IO;
using System.Text;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            // #4-1. Implement the method by reading all content as a string.
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            // #4-2. Implement the method by reading lines of characters as a string array.
            System.Collections.Generic.List<string> stringList = new System.Collections.Generic.List<string>();
            while (streamReader.Peek() >= 0)
            {
                stringList.Add(streamReader.ReadLine());
            }

            return stringList.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            // #4-3. Implement the method by reading only letters and numbers, and write the characters to a StringBuilder.
            StringBuilder sb = new StringBuilder();
            while (streamReader.Peek() >= 0)
            {
                if (char.IsLetterOrDigit(Convert.ToChar(streamReader.Peek())))
                {
                    sb.Append(Convert.ToChar(streamReader.Read()));
                }
                else
                {
                    break;
                }
            }

            return sb;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            // #4-4. Implement the method by returning an underlying string that sliced into jagged array of characters according to arraySize.
            int jaggedarraySize;
            if (streamReader.BaseStream.Length % arraySize != 0)
            {
                jaggedarraySize = (int)((streamReader.BaseStream.Length / arraySize) + 1);
            }
            else
            {
                jaggedarraySize = (int)(streamReader.BaseStream.Length / arraySize);
            }

            char[][] charArrays = new char[jaggedarraySize][];
            for (int i = 0; i < charArrays.Length; i++)
            {
                charArrays[i] = new char[arraySize];
                for (int j = 0; j < arraySize; j++)
                {
                    if (streamReader.Peek() >= 0)
                    {
                        charArrays[i][j] = Convert.ToChar(streamReader.Read());
                    }
                    else
                    {
                        Array.Resize(ref charArrays[i], j);
                        break;
                    }
                }
            }

            return charArrays;
        }
    }
}
