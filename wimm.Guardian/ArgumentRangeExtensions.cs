using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validations for numeric <see cref="Argument{T}"/> types.
    /// </summary>
    public static class ArgumentRangeExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not less than <paramref name="value"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsLessThan<T, TValue>(
            this Argument<T> target, TValue value) where T : IComparable<TValue>
        {
            target.Require(nameof(target)).Argument().IsNotNull();
            value.Require(nameof(value)).Argument().IsNotNull();

            return
                target.IfNot(
                    v => v.IsLessThan(value),
                    (a) =>
                    {
                        throw new ArgumentOutOfRangeException(
                            a.Name, $"Must be less than {value}.");
                    });
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than <paramref name="value"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotLessThan<T, TValue>(
            this Argument<T> target, TValue value) where T : IComparable<TValue>
        {
            target.Require(nameof(target)).Argument().IsNotNull();
            value.Require(nameof(value)).Argument().IsNotNull();

            return
                target.If(
                    v => v.IsLessThan(value),
                    (a) =>
                    {
                        throw new ArgumentOutOfRangeException(
                            a.Name, $"Must not be less than {value}.");
                    });
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not greater than <paramref name="value"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsGreaterThan<T, TValue>(
            this Argument<T> target, TValue value) where T : IComparable<TValue>
        {
            target.Require(nameof(target)).Argument().IsNotNull();
            value.Require(nameof(value)).Argument().IsNotNull();

            return
                target.IfNot(
                    v => v.IsGreaterThan(value),
                    (a) =>
                    {
                        throw new ArgumentOutOfRangeException(
                            a.Name, $"Must be greater than {value}.");
                    });
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than <paramref name="value"/>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotGreaterThan<T, TValue>(
            this Argument<T> target, TValue value) where T : IComparable<TValue>
        {
            target.Require(nameof(target)).Argument().IsNotNull();
            value.Require(nameof(value)).Argument().IsNotNull();

            return
                target.If(
                    v => v.IsGreaterThan(value),
                    (a) =>
                    {
                        throw new ArgumentOutOfRangeException(
                            a.Name, $"Must not be greater than {value}.");
                    });
        }

        private static bool IsLessThan<T>(this IComparable<T> target, T value)
        {
            return target.CompareTo(value) < 0;
        }

        private static bool IsGreaterThan<T>(this IComparable<T> target, T value)
        {
            return target.CompareTo(value) > 0;
        }
    }
}
