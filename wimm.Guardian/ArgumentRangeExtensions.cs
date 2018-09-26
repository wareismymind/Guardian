using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Range validations for <see cref="IComparable{T}"/> <see cref="Argument{T}"/> types.
    /// </summary>
    public static class ArgumentRangeExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not less than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The <typeparamref name="T"/> to compare against.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsLessThan<T>(this Argument<T> target, T value) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            value.Require(nameof(value)).IsNotNullIfNullable();

            if (!target.Value.IsLessThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must be less than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The <typeparamref name="T"/> to compare against.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotLessThan<T>(this Argument<T> target, T value) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            value.Require(nameof(value)).IsNotNullIfNullable();

            if (target.Value.IsLessThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must not be less than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not greater than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The <typeparamref name="T"/> to compare against.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsGreaterThan<T>(this Argument<T> target, T value) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            value.Require(nameof(value)).IsNotNullIfNullable();

            if (!target.Value.IsGreaterThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must be greater than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="value">The <typeparamref name="T"/> to compare against.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotGreaterThan<T>(this Argument<T> target, T value) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            value.Require(nameof(value)).IsNotNullIfNullable();

            if (target.Value.IsGreaterThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must not be greater than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> not in the range specified by <paramref name="min"/> and
        /// <paramref name="max"/> inclusive.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="min"/> or <paramref name="max"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsInRange<T>(this Argument<T> target, T min, T max) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            min.Require(nameof(min)).IsNotNullIfNullable();
            max.Require(nameof(max)).IsNotNullIfNullable();

            if (target.Value.IsLessThan(min) || target.Value.IsGreaterThan(max))
                throw new ArgumentOutOfRangeException(
                    target.Name, $"Must be in the range of {min} to {max} inclusive.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> in the range specified by <paramref name="min"/> and
        /// <paramref name="max"/> inclusive.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="min"/> or <paramref name="max"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotInRange<T>(this Argument<T> target, T min, T max) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            min.Require(nameof(min)).IsNotNullIfNullable();
            max.Require(nameof(max)).IsNotNullIfNullable();

            if (!(target.Value.IsLessThan(min) || target.Value.IsGreaterThan(max)))
                throw new ArgumentOutOfRangeException(
                    target.Name, $"Must be outside the range of {min} to {max} inclusive.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is not between <paramref name="floor"/> and
        /// <paramref name="ceiling"/> exclusive.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="floor">The minimum value of the range.</param>
        /// <param name="ceiling">The maximum value of the range.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="floor"/> or <paramref name="ceiling"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsBetween<T>(this Argument<T> target, T floor, T ceiling) where T : IComparable<T>
        {
            target.RequireValueToCompare();
            floor.Require(nameof(floor)).IsNotNullIfNullable();
            ceiling.Require(nameof(ceiling)).IsNotNullIfNullable();

            if (!(target.Value.IsGreaterThan(floor) && target.Value.IsLessThan(ceiling)))
                throw new ArgumentOutOfRangeException(
                    target.Name, $"Must be between {floor} and {ceiling} exclusive.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is between <paramref name="floor"/> and
        /// <paramref name="ceiling"/> exclusive.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="floor">The minimum value of the range.</param>
        /// <param name="ceiling">The maximum value of the range.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="floor"/> or <paramref name="ceiling"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotBetween<T>(this Argument<T> target, T floor, T ceiling) where T : IComparable<T>
        {
            target.RequireValueToCompare();

            floor.Require(nameof(floor)).IsNotNullIfNullable();
            ceiling.Require(nameof(ceiling)).IsNotNullIfNullable();

            if (target.Value.IsGreaterThan(floor) && target.Value.IsLessThan(ceiling))
                throw new ArgumentOutOfRangeException(
                    target.Name, $"Must not be between {floor} and {ceiling} exclusive.");

            return target;
        }

        private static bool IsLessThan<T>(this IComparable<T> target, T value) =>
            target.CompareTo(value) < 0;

        private static bool IsGreaterThan<T>(this IComparable<T> target, T value) =>
            target.CompareTo(value) > 0;

        private static void RequireValueToCompare<T>(this Argument<T> target)
        {
            if (target.Value == null)
                throw new InvalidOperationException("A non-null value is required to perform range comparisons.");
        }
    }
}
