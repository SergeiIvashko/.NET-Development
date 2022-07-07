namespace CreatingMethods
{
    public static class MethodsWithRefParameters
    {
        public static bool ReturnParameterValueAndSetParameterToDefaultValue(ref bool boolValue)
        {
            bool value = boolValue;
            boolValue = default(bool);
            return value;
        }

        // #17. Add a static method here with name "ReturnParameterValueAndSetParameterToDefaultValue" that gets "charValue" parameter ("char" type) with ref keyword. The method should return value of "charValue" parameter and set the "charValue" parameter to default value (use "default" operator).
        public static char ReturnParameterValueAndSetParameterToDefaultValue(ref char charValue)
        {
            char value = charValue;
            charValue = default(char);
            return value;
        }

        // #18. Add a static method here with name "ReturnParameterValueAndSetParameterToDefaultValue" that gets "floatValue" parameter ("float" type) with ref keyword. The method should return value of "floatValue" parameter and set the "floatValue" parameter to default value (use "default" operator).
        public static float ReturnParameterValueAndSetParameterToDefaultValue(ref float floatValue)
        {
            float value = floatValue;
            floatValue = default;
            return value;
        }

        // #19. Add a static method here with name "ReturnParameterValueAndSetParameterToDefaultValue" that gets "intValue" parameter ("int" type) with ref keyword. The method should return value of "intValue" parameter and set the "intValue" parameter to default value (use "default" operator).
        public static int ReturnParameterValueAndSetParameterToDefaultValue(ref int intValue)
        {
            int value = intValue;
            intValue = default;
            return value;
        }

        // #20. Add a static method here with name "ReturnParameterValueAndSetParameterToDefaultValue" that gets "longValue" parameter ("long" type) with ref keyword. The method should return value of "longValue" parameter and set the "longValue" parameter to default value (use "default" operator).
        public static long ReturnParameterValueAndSetParameterToDefaultValue(ref long longValue)
        {
            long value = longValue;
            longValue = default;
            return value;
        }
    }
}
