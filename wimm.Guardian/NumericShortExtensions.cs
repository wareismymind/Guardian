using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validation for the <see cref="short"/> type.
    /// </summary>
    public static class NumericShortExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<short> IsPositive(this Argument<short> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan<short>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<short> IsNegative(this Argument<short> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan<short>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<short> IsNotPositive(this Argument<short> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan<short>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<short> IsNotNegative(this Argument<short> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan<short>(0);
        }
    }
}

