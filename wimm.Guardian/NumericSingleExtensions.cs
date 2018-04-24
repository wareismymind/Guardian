using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validation for the <see cref="Single"/> type.
    /// </summary>
    public static class NumericSingleExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<Single> IsPositive(this Argument<Single> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan<Single>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<Single> IsNegative(this Argument<Single> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan<Single>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<Single> IsNotPositive(this Argument<Single> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan<Single>(0);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than 0.
        /// </summary>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<Single> IsNotNegative(this Argument<Single> target)
        {
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan<Single>(0);
        }
    }
}

