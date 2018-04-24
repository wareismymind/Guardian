using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validation for the <see cref="sbyte"/> type.
    /// </summary>
    public static class NumericSbyteExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<sbyte> IsPositive(this Argument<sbyte> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan<sbyte>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<sbyte> IsNegative(this Argument<sbyte> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan<sbyte>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<sbyte> IsNotPositive(this Argument<sbyte> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan<sbyte>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<sbyte> IsNotNegative(this Argument<sbyte> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan<sbyte>(0);
        }
    }
}

