using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validation for the <see cref="int"/> type.
    /// </summary>
    public static class NumericIntExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<int> IsPositive(this Argument<int> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan<int>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<int> IsNegative(this Argument<int> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan<int>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<int> IsNotPositive(this Argument<int> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan<int>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<int> IsNotNegative(this Argument<int> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan<int>(0);
        }
    }
}

