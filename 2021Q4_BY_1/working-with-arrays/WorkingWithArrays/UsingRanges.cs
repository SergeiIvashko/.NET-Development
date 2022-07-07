using System;

namespace WorkingWithArrays
{
    public static class UsingRanges
    {
        public static int[] GetArrayWithAllElements(int[] array)
        {
            // #3-1. Add the method implementation. The method should return a new array with all elements from "array" parameter.
            // See "Indices and ranges" documentation page: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/ranges-indexes
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public static int[] GetArrayWithoutFirstElement(int[] array)
        {
            // #3-2. Add the method implementation. The method should return a new array with all elements from "array" parameter except the first one.
            int[] newArray = new int[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
            }

            return newArray;
        }

        public static int[] GetArrayWithoutTwoFirstElements(int[] array)
        {
            // #3-3. Add the method implementation. The method should return a new array with all elements from "array" parameter except the two first elements.
            int[] newArray = new int[array.Length - 2];
            for (int i = 2; i < array.Length; i++)
            {
                newArray[i - 2] = array[i];
            }

            return newArray;
        }

        public static int[] GetArrayWithoutThreeFirstElements(int[] array)
        {
            // #3-4. Add the method implementation. The method should return a new array with all elements from "array" parameter except the three first elements.
            int[] newArray = new int[array.Length - 3];
            for (int i = 3; i < array.Length; i++)
            {
                newArray[i - 3] = array[i];
            }

            return newArray;
        }

        public static int[] GetArrayWithoutLastElement(int[] array)
        {
            // #3-5. Add the method implementation. The method should return a new array with all elements from "array" parameter except the last element.
            int[] newArray = new int[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public static int[] GetArrayWithoutTwoLastElements(int[] array)
        {
            // #3-6. Add the method implementation. The method should return a new array with all elements from "array" parameter except the two last elements.
            int[] newArray = new int[array.Length - 2];
            for (int i = 0; i < array.Length - 2; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public static int[] GetArrayWithoutThreeLastElements(int[] array)
        {
            // #3-7. Add the method implementation. The method should return a new array with all elements from "array" parameter except the three last elements.
            int[] newArray = new int[array.Length - 3];
            for (int i = 0; i < array.Length - 3; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        public static bool[] GetArrayWithoutFirstAndLastElements(bool[] array)
        {
            // #3-8. Add the method implementation. The method should return a new array with all elements from "array" parameter except the first element and the last elements.
            bool[] newArray = new bool[array.Length - 2];
            for (int i = 1; i < array.Length - 1; i++)
            {
                newArray[i - 1] = array[i];
            }

            return newArray;
        }

        public static bool[] GetArrayWithoutTwoFirstAndTwoLastElements(bool[] array)
        {
            // #3-9. Add the method implementation. The method should return a new array with all elements from "array" parameter except the two first elements and the last two elements.
            bool[] newArray = new bool[array.Length - 4];
            for (int i = 2; i < array.Length - 2; i++)
            {
                newArray[i - 2] = array[i];
            }

            return newArray;
        }

        public static bool[] GetArrayWithoutThreeFirstAndThreeLastElements(bool[] array)
        {
            // #3-10. Add the method implementation. The method should return a new array with all elements from "array" parameter except the three first elements and the three last elements.
            bool[] newArray = new bool[array.Length - 6];
            for (int i = 3; i < array.Length - 3; i++)
            {
                newArray[i - 3] = array[i];
            }

            return newArray;
        }
    }
}
