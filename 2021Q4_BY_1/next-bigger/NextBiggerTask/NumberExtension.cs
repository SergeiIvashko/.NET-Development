using System;
using System.Collections.Generic;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            int argNumber = number;
            int result;

            // Checking the argument for an exception case.
            if (number < 0)
            {
                throw new ArgumentException($"Value of {nameof(number)} cannot be less zero.");
            }

            // Conversion the int number into an int array.
            var numbers = new Stack<int>(32);
            for (; argNumber > 0; argNumber /= 10)
            {
                numbers.Push(argNumber % 10);
            }

            // The array index variables.
            int i, j;

            // Starting from the end of the array and finding the first digit, which is smaller than previous digit.
            int[] numberArray = numbers.ToArray();
            for (i = numberArray.Length - 1; i > 0; i--)
            {
                if (numberArray[i] > numberArray[i - 1])
                {
                    break;
                }
            }

            // In the case when all digit ordered in descending way the required number is not exist.
            if (i == 0)
            {
                return null;
            }
            
            // Finding the closest smaller digit than the smallest from right side.
            else
            {
                int firstMin = numberArray[i - 1];
                int smallestAfterMin = i;
                if (numberArray.Length - i > 2)
                {
                    for (j = i; j < numberArray.Length - 1; j++)
                    {
                        if (numberArray[j] > firstMin && numberArray[j] <= numberArray[smallestAfterMin])
                        {
                            break;
                        }
                    }
                }
                else
                {
                    j = i;
                }

                // Swapping between themself the smallest digit from the end and the closest to the smallest.
                int exchangeStorage = numberArray[i - 1];
                numberArray[i - 1] = numberArray[j];
                numberArray[j] = exchangeStorage;

                // Sorting digits after the smallest from the end in ascending order.
                if (numberArray.Length - i > 2)
                {
                    Array.Sort(numberArray, i, numberArray.Length - i);
                }

                // Convert the int array to a long number to prevent overflowing int type.
                long resultLong = 0;
                for (i = 0; i < numberArray.Length; i++)
                {
                    resultLong += (long)numberArray[i] * (long)Convert.ToInt32(Math.Pow(10, numberArray.Length - i - 1));
                }

                // Checking case when the resultLong bigger than int.MaxValue.
                if (resultLong > int.MaxValue)
                {
                    return null;
                }
                else
                {
                    result = (int)resultLong;
                    return result;
                }
            }
        }
    }
}
