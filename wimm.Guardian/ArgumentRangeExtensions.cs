using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds range validations for comparable <see cref="Argument{T}"/> types.
    /// </summary>
    public static class ArgumentRangeExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not less than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsLessThan<T>(this Argument<T> target, T value) 
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            value.Require(nameof(value)).IsNotNull();

            if (!target.Value.IsLessThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must be less than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotLessThan<T>(this Argument<T> target, T value) 
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            value.Require(nameof(value)).IsNotNull();

            if (target.Value.IsLessThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must not be less than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not greater than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsGreaterThan<T>(this Argument<T> target, T value) 
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            value.Require(nameof(value)).IsNotNull();

            if (!target.Value.IsGreaterThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must be greater than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The value to compare against.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, or <paramref name="value"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotGreaterThan<T>(this Argument<T> target, T value) 
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            value.Require(nameof(value)).IsNotNull();

            if (target.Value.IsGreaterThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must not be greater than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than <paramref name="min"/> or greater than
        /// <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="min">The minimum allowed value for <paramref name="target"/>.</param>
        /// <param name="max">The maximum allowed value for <paramref name="target"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, <paramref name="min"/>, or <paramref name="max"/> is
        /// <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsInRange<T>(this Argument<T> target, T min, T max)
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            min.Require(nameof(min)).IsNotNull();
            max.Require(nameof(max)).IsNotNull();

            return target.IsNotLessThan(min).IsNotGreaterThan(max);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to <paramref name="min"/> and less
        /// than or equal to <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="min">The minimum disallowed value for <paramref name="target"/>.</param>
        /// <param name="max">The maximum disallowed value for <paramref name="target"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, <paramref name="min"/>, or <paramref name="max"/> is
        /// <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotInRange<T>(this Argument<T> target, T min, T max)
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            min.Require(nameof(min)).IsNotNull();
            max.Require(nameof(max)).IsNotNull();

            if (!(target.Value.IsLessThan(min) || target.Value.IsGreaterThan(max)))
                throw new ArgumentOutOfRangeException(
                    target.Name,
                    $"Must be less than {min} or greater than {max}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to <paramref name="a"/> or greater
        /// than or equal to <paramref name="b"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="a">The value that <paramref name="target"/> must be greater than.</param>
        /// <param name="b">The value that <paramref name="target"/> must be less than.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, <paramref name="a"/>, or <paramref name="b"/> is
        /// <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsBetween<T>(this Argument<T> target, T a, T b)
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            a.Require(nameof(a)).IsNotNull();
            b.Require(nameof(b)).IsNotNull();

            return target.IsGreaterThan(a).IsLessThan(b);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than <paramref name="a"/> and less than 
        /// <paramref name="b"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="a"
        /// >The value that <paramref name="target"/> must not be greater than.
        /// </param>
        /// <param name="b">The value that <paramref name="target"/> must not be less than.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, <paramref name="a"/>, or <paramref name="b"/> is
        /// <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotBetween<T>(this Argument<T> target, T a, T b)
            where T : IComparable<T>
        {
            target.Require(nameof(target)).IsNotNull();
            target.AssertArgumentIsComparable();
            a.Require(nameof(a)).IsNotNull();
            b.Require(nameof(b)).IsNotNull();

            if (target.Value.IsGreaterThan(a) && target.Value.IsLessThan(b))
                throw new ArgumentOutOfRangeException(
                    target.Name,
                    $"Must be less than or equal to {a} and greater than or equal to {b}.");

            return target;
        }

        private static bool IsLessThan<T>(this IComparable<T> target, T value)
        {
            return target.CompareTo(value) < 0;
        }

        private static bool IsGreaterThan<T>(this IComparable<T> target, T value)
        {
            return target.CompareTo(value) > 0;
        }

        private static void AssertArgumentIsComparable<T>(this Argument<T> target)
        {
            if (target.Value == null)
                throw new InvalidOperationException($"Cannot compare against null-valued Argument.");
        }
    }
}
