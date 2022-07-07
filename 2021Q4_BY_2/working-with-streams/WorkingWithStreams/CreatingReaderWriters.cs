using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace WorkingWithStreams
{
    public static class CreatingReaderWriters
    {
        public static StringReader CreateStringReader(string str)
        {
            // #1-1. Implement the method by returning an instantiated object of the StringReader class.
            return new StringReader(str);
        }

        public static StringWriter CreateStringWriter()
        {
            // #1-2. Implement the method by returning an instantiated object of the StringWriter class.
            return new StringWriter();
        }

        public static StringWriter CreateStringWriterThatWritesToStringBuilder(StringBuilder stringBuilder)
        {
            // #1-3. Implement the method by returning an instantiated object of the StringWriter class.
            return new StringWriter(stringBuilder);
        }

        public static StringWriter CreateStringWriterThatWritesCultureSpecificData(CultureInfo cultureInfo)
        {
            // #1-4. Implement the method by returning an instantiated object of the StringWriter class.
            return new StringWriter(cultureInfo);
        }

        public static StreamReader CreateStreamReaderFromStream(Stream stream)
        {
            // #1-5. Implement the method by returning an instantiated object of the StreamReader class.
            return new StreamReader(stream);
        }

        public static StreamWriter CreateStreamWriterToStream(Stream stream)
        {
            // #1-6. Implement the method by returning an instantiated object of the StreamWriter class.
            return new StreamWriter(stream);
        }
    }
}
