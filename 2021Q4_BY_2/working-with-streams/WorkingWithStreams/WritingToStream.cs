using System;
using System.IO;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace WorkingWithStreams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            // #5-1. Implement the method by reading an integer from the StreamReader and writing it to the outputStream with StreamWriter.Write() method.
            while (streamReader.Peek() >= 0)
            {
                outputWriter.Write(streamReader.Read());
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            // #5-2. Implement the method by reading a character from the StreamReader and writing it to the outputStream with StreamWriter.Write() method.
            while (streamReader.Peek() >= 0)
            {
                outputWriter.Write(Convert.ToChar(streamReader.Read()));
                outputWriter.Flush();
            }
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            // #5-3. Implement the method by reading an integer from the StreamReader and writing it as a hex string to the outputStream with StreamWriter.Write() method that writes a formatted string. Use StreamReader.Peek method for checking whether there are more characters in the underlying string.
            while (contentReader.Peek() >= 0)
            {
                outputWriter.Write("{0:X2}", contentReader.Read());
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            // #5-4. Implement the method by reading a line from the StreamReader and writing it with line numbers to the outputWriter with StreamWriter.Write() method that writes a formatted string.
            int i = 1;
            while (contentReader.Peek() >= 0)
            {
                outputWriter.WriteLine("{0:D3} {1}", i++, contentReader.ReadLine());
                outputWriter.Flush();
            }
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            // #5-5. Implement the method by reading the content and words, removing words from the content, and writing the updated content to the outputWriter. Use StreamReader.Peek method for checking whether there are more characters in the underlying string.
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            while (contentReader.Peek() >= 0)
            {
                sb.Append(contentReader.ReadLine());
            }

            while (wordsReader.Peek() >= 0)
            {
                sb.Replace(wordsReader.ReadLine(), string.Empty);
            }

            outputWriter.Write(sb.ToString());
            outputWriter.Flush();
        }
    }
}
