using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validation for the <see cref="long"/> type.
    /// </summary>
    public static class NumericLongExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<long> IsPositive(this Argument<long> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan<long>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<long> IsNegative(this Argument<long> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan<long>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<long> IsNotPositive(this Argument<long> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan<long>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<long> IsNotNegative(this Argument<long> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan<long>(0);
        }
    }
}

