using System;

namespace Numbers
{
    /// <summary>
    /// Specifies comparison signs: less than, more than and equals.
    /// </summary>
    [Flags]
    public enum ComparisonSigns
    {
        /// <summary>
        /// The first digit is less than the second digit.
        /// </summary>
        LessThan = 1,

        /// <summary>
        /// The second digit is more than the first digit.
        /// </summary>
        MoreThan = 2,

        /// <summary>
        /// The first and the second digits are equal.
        /// </summary>
        Equals = 4,
    }
}
