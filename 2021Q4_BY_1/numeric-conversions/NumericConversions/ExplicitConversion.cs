namespace NumericConversions
{
    public static class ExplicitConversion
    {
        public static int LongToInt(long longValue)
        {
            return (int)longValue;
        }

        // #9: Add a static method here with name "FloatToInt" that gets "floatValue" parameter ("float" type) and returns the parameter value that is explicitly converted to "int" type.
        public static int FloatToInt(float floatValue)
        {
            return (int)floatValue;
        }

        // #10: Add a static method here with name "DoubleToInt" that gets "doubleValue" parameter ("double" type) and returns the parameter value that is explicitly converted to "int" type.
        public static int DoubleToInt(double doubleValue)
        {
            return (int)doubleValue;
        }

        // #11: Add a static method here with name "DecimalToInt" that gets "decimalValue" parameter ("decimal" type) and returns the parameter value that is explicitly converted to "int" type.
        public static int DecimalToInt(decimal decimalValue)
        {
            return (int)decimalValue;
        }

        // #12: Add a static method here with name "FloatToLong" that gets "floatValue" parameter ("float" type) and returns the parameter value that is explicitly converted to "long" type.
        public static long FloatToLong(float floatValue)
        {
            return (long)floatValue;
        }

        // #13: Add a static method here with name "DoubleToLong" that gets "doubleValue" parameter ("double" type) and returns the parameter value that is explicitly converted to "long" type.
        public static long DoubleToLong(double doubleValue)
        {
            return (long)doubleValue;
        }

        // #14: Add a static method here with name "DecimalToLong" that gets "decimalValue" parameter ("decimal" type) and returns the parameter value that is explicitly converted to "long" type.
        public static long DecimalToLong(decimal decimalValue)
        {
            return (long)decimalValue;
        }

        // #15: Add a static method here with name "ShortToByte" that gets "shortValue" parameter ("short" type) and returns the parameter value that is explicitly converted to "byte" type.
        public static byte ShortToByte(short shortValue)
        {
            return (byte)shortValue;
        }

        // #16: Add a static method here with name "IntToByte" that gets "intValue" parameter ("int" type) and returns the parameter value that is explicitly converted to "byte" type.
        public static byte IntToByte(int intValue)
        {
            return (byte)intValue;
        }

        // #17: Add a static method here with name "IntToShort" that gets "intValue" parameter ("int" type) and returns the parameter value that is explicitly converted to "short" type.
        public static short IntToShort(int intValue)
        {
            return (short)intValue;
        }
    }
}
