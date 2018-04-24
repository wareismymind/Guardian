using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validation for the <see cref="double"/> type.
    /// </summary>
    public static class NumericDoubleExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<double> IsPositive(this Argument<double> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan<double>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<double> IsNegative(this Argument<double> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan<double>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<double> IsNotPositive(this Argument<double> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan<double>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<double> IsNotNegative(this Argument<double> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan<double>(0);
        }
    }
}

