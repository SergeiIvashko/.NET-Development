using System;

namespace WorkingWithArrays
{
    public static class UsingIndexerForAccessingArrayElement
    {
        public static int GetFirstArrayElement(int[] array)
        {
            // #2-1. Add the method implementation. The method should return a first element of the specified array.
            return array[0];
        }

        public static int GetSecondArrayElement(int[] array)
        {
            // #2-2. Add the method implementation. The method should return a second element of the specified array.
            return array[1];
        }

        public static int GetThirdArrayElement(int[] array)
        {
            // #2-3. Add the method implementation. The method should return a third element of the specified array.
            return array[2];
        }

        public static int GetLastElement(int[] array)
        {
            // #2-4. Add the method implementation. The method should return a last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^1];
        }

        public static int GetNextToLastElement(int[] array)
        {
            // #2-5. Add the method implementation. The method should return a next to last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^2];
        }

        public static int GetNthArrayElement(int[] array, int n)
        {
            // #2-6. Add the method implementation. The method should return a Nth element of the specified array.
            return array[n - 1];
        }

        public static bool GetFirstArrayElement(bool[] array)
        {
            // #2-7. Add the method implementation. The method should return a first element of the specified array.
            return array[0];
        }

        public static bool GetSecondArrayElement(bool[] array)
        {
            // #2-8. Add the method implementation. The method should return a second element of the specified array.
            return array[1];
        }

        public static bool GetSixthArrayElement(bool[] array)
        {
            // #2-9. Add the method implementation. The method should return a sixth element of the specified array.
            return array[5];
        }

        public static bool GetLastElement(bool[] array)
        {
            // #2-10. Add the method implementation. The method should return a last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^1];
        }

        public static bool GetNextToLastElement(bool[] array)
        {
            // #2-11. Add the method implementation. The method should return a next to last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^2];
        }

        public static bool GetNthArrayElement(bool[] array, int n)
        {
            // #2-12. Add the method implementation. The method should return a Nth element of the specified array.
            return array[n - 1];
        }

        public static string GetFirstArrayElement(string[] array)
        {
            // #2-13. Add the method implementation. The method should return a first element of the specified array.
            return array[0];
        }

        public static string GetForthArrayElement(string[] array)
        {
            // #2-14. Add the method implementation. The method should return a forth element of the specified array.
            return array[3];
        }

        public static string GetLastElement(string[] array)
        {
            // #2-15. Add the method implementation. The method should return a last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^1];
        }

        public static string GetNextToLastElement(string[] array)
        {
            // #2-16. Add the method implementation. The method should return a next to last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^2];
        }

        public static char GetFirstArrayElement(char[] array)
        {
            // #2-17. Add the method implementation. The method should return a first element of the specified array.
            return array[0];
        }

        public static char GetSeventhArrayElement(char[] array)
        {
            // #2-18. Add the method implementation. The method should return a seventh element of the specified array.
            return array[6];
        }

        public static char GetLastElement(char[] array)
        {
            // #2-19. Add the method implementation. The method should return a last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^1];
        }

        public static char GetNextToLastElement(char[] array)
        {
            // #2-20. Add the method implementation. The method should return a next to last element of the specified array.
            // Use Array.Length property to get an array length: https://docs.microsoft.com/en-us/dotnet/api/system.array.length
            return array[^2];
        }

        public static double GetFirstArrayElement(double[] array)
        {
            // #2-21. Add the method implementation. The method should return a first element of the specified array.
            return array[0];
        }

        public static double GetSeventhArrayElement(double[] array)
        {
            // #2-22. Add the method implementation. The method should return a seventh element of the specified array.
            return array[6];
        }

        public static double GetLastElement(double[] array)
        {
            // #2-23. Add the method implementation. The method should return a last element of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^1];
        }

        public static double GetNextToLastElement(double[] array)
        {
            // #2-24. Add the method implementation. The method should return a next to last element of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^2];
        }

        public static float GetFirstArrayElement(float[] array)
        {
            // #2-25. Add the method implementation. The method should return a first element of the specified array.
            return array[0];
        }

        public static float GetNinthArrayElement(float[] array)
        {
            // #2-26. Add the method implementation. The method should return a ninth element of the specified array.
            return array[8];
        }

        public static float GetLastElement(float[] array)
        {
            // #2-27. Add the method implementation. The method should return a last element of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^1];
        }

        public static float GetNextToLastElement(float[] array)
        {
            // #2-28. Add the method implementation. The method should return a next to last element of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^2];
        }

        public static decimal GetLastElement(decimal[] array)
        {
            // #2-29. Add the method implementation. The method should return a last element of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^1];
        }

        public static decimal GetNextToLastElement(decimal[] array)
        {
            // #2-29. Add the method implementation. The method should return a next to last element of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^2];
        }

        public static decimal GetThirdElementFromEnd(decimal[] array)
        {
            // #2-30. Add the method implementation. The method should return a third element from the end of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^3];
        }

        public static decimal GetFourthElementFromEnd(decimal[] array)
        {
            // #2-31. Add the method implementation. The method should return a forth element from the end of the specified array.
            // Use index from end operator: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            return array[^4];
        }
    }
}
