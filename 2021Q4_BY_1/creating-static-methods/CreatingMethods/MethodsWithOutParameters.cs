namespace CreatingMethods
{
    public static class MethodsWithOutParameters
    {
        public static void ReturnValues(out bool trueValue, out bool falseValue)
        {
            trueValue = true;
            falseValue = false;
        }

        // #13. Add a static method here with name "ReturnValues" that gets "lowerCaseA" and "upperCaseA" parameters ("char" type) with out parameter modifier. The method should return 'a' and 'A' values.
        public static void ReturnValues(out char lowerCaseA, out char upperCaseA)
        {
            lowerCaseA = 'a';
            upperCaseA = 'A';
        }

        // #14. Add a static method here with name "ReturnValues" that gets "minFloatValue" and "maxFloatValue" parameters ("float" type) with out parameter modifier. The method should return float min and max values.
        public static void ReturnValues(out float minFloatValue, out float maxFloatValue)
        {
            minFloatValue = float.MinValue;
            maxFloatValue = float.MaxValue;
        }

        // #15. Add a static method here with name "ReturnValues" that gets "minIntValue" and "maxIntValue" parameters ("int" type) with out parameter modifier. The method should return int min and max values.
        public static void ReturnValues(out int minIntValue, out int maxIntValue)
        {
            minIntValue = int.MinValue;
            maxIntValue = int.MaxValue;
        }

        // #16. Add a static method here with name "ReturnValues" that gets "minLongValue" and "maxLongValue" parameters ("long" type) with out parameter modifier. The method should return long min and max values.
        public static void ReturnValues(out long minLongValue, out long maxLongValue)
        {
            minLongValue = long.MinValue;
            maxLongValue = long.MaxValue;
        }
    }
}
