using System;

namespace DartsGame
{
    public static class Darts
    {
        /// <summary>
        /// Calculates the earned points in a single toss of a Darts game.
        /// </summary>
        /// <param name="x">x-coordinate of dart.</param>
        /// <param name="y">y-coordinate of dart.</param>
        /// <returns>The earned points.</returns>
        public static int GetScore(double x, double y)
        {
            double circleRadius = Math.Sqrt((x * x) + (y * y));

            return _ = circleRadius switch
            {
                _ when circleRadius <= 1 => 10,
                _ when circleRadius <= 5 => 5,
                _ when circleRadius <= 10 => 1,
                _ => 0,
            };
        }
    }
}
