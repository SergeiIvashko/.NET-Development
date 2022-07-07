using System;

namespace Calculations
{
    public static class Calculator
    {
        /// <summary>
        /// Calculate the following sum 1/1 + 1/2 + 1/3 + ... + 1/n, where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumOne(int n)
        {
            double sum = 1.0;
            for (int i = 2; i <= n; i++)
            {
                sum += 1 / (double)i;
            }

            return sum;
        }
        
        /// <summary>
        /// Calculate the following sum
        /// 1/(1*2) - 1/(2*3) + 1/(3*4) + ... + (-1)^(n+1) / (n * (n + 1)), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumTwo(int n)
        {
            double sum = 1.0 / (1.0 * 2.0);
            int numerator = 1;
            for (int i = 2; i <= n; i++)
            {
                numerator *= -1;
                sum += numerator / (i * (i + 1.0));
            }

            return sum;
        }
        
        /// <summary>
        /// Calculate the following sum
        /// 1/1^5 + 1/2^5 + 1/3^5 + ... + 1/n^5, where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumThree(int n)
        {
            double sum = 1.0;
            for (int i = 2; i <= n; i++)
            {
                sum += 1 / Math.Pow(i, 5);
            }

            return sum;
        }
        
        /// <summary>
        /// Calculate the following sum
        /// 1/(3 * 3) + 1/(5 * 5) + 1/(7 * 7) + ... + 1/((2 * n + 1) * (2 * n + 1)), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumFour(int n)
        {
            double sum = 1.0 / (3.0 * 3.0);
            for (int i = 2; i <= n; i++)
            {
                sum += 1 / (((2.0 * i) + 1.0) * ((2.0 * i) + 1.0));
            }

            return sum;
        }

        /// <summary>
        /// Calculate the following product
        /// (1 + 1/(1 * 1)) * (1 + 1/(2 * 2)) * (1 + 1/(3 * 3)) * ... * (1 + 1/(n * n)), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Product of elements.</returns>
        public static double GetProductOne(int n)
        {
            double sum = 1.0 + (1.0 / (1.0 * 1.0));
            for (double i = 2.0; i <= n; i++)
            {
                sum *= 1.0 + (1.0 / (i * i));
            }

            return sum;
        }
        
        /// <summary>
        /// Calculate the following sum
        /// -1/3 + 1/5 - 1/7 + ... + (-1)^n / (2 * n + 1), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumFive(int n)
        {
            double sum = -1.0 / 3.0;
            int numerator = -1;
            for (int i = 2; i <= n; i++)
            {
                numerator *= -1;
                sum += numerator / ((2.0 * i) + 1.0);
            }

            return sum;
        }

        /// <summary>
        /// Calculate the following sum
        /// 1!/1 + 2!/(1+1/2) + 3!/(1+1/2+1/3) + ... + 1*2*...* n/ (1+1/2+1/3+...+1/n), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumSix(int n)
        {
            double sum = 1.0;
            double numerator = 1.0;
            double denominator = 1.0;
            for (int i = 2; i <= n; i++)
            {
                numerator *= i;
                denominator += 1.0 / i;
                sum += numerator / denominator;
            }

            return sum;
        }

        /// <summary>
        /// Calculate the following sum
        /// Sqrt(2 + Sqrt(2 + ... + Sqrt(2))), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumSeven(int n)
        {
            double result = 0.0;
            double nestedMember = Math.Sqrt(2.0);
            for (int i = 2; i <= n; i++)
            {
                result = Math.Sqrt(2.0 + nestedMember);
                nestedMember = result;
            }

            return result;
        }
        
        /// <summary>
        /// Calculate the following sum
        /// 1/sin(1) + 1/(sin(1)+sin(2)) + ...+  1/(sin(1)+sin(2)+...+sin(n)), where n > 0.
        /// </summary>
        /// <param name="n">Number of elements.</param>
        /// <returns>Sum of elements.</returns>
        public static double GetSumEight(int n)
        {
            double denominator = 0.0;
            double sum = 0.0;
            for (int angle = 1; angle <= n; angle++)
            {
                denominator += Math.Sin(Math.PI * angle / 180.0);
                sum += 1 / denominator;
            }

            return sum;
        }
    }
}
