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
        public static Argument<T> IsLessThan<T>(this Argument<T> target, T value)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
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
        public static Argument<T> IsNotLessThan<T>(this Argument<T> target, T value)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
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
        public static Argument<T> IsGreaterThan<T>(this Argument<T> target, T value)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
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
        public static Argument<T> IsNotGreaterThan<T>(this Argument<T> target, T value)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
            value.Require(nameof(value)).IsNotNullIfNullable();

            if (target.Value.IsGreaterThan(value))
                throw new ArgumentOutOfRangeException(target.Name, $"Must not be greater than {value}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than <paramref name="min"/> or greater than
        /// <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="min">The minimum allowed value for <paramref name="target"/>.</param>
        /// <param name="max">The maximum allowed value for <paramref name="target"/>.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsInRange<T>(this Argument<T> target, T min, T max)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
            min.Require(nameof(min)).IsNotNullIfNullable();
            max.Require(nameof(max)).IsNotNullIfNullable();

            return target.IsNotLessThan(min).IsNotGreaterThan(max);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to <paramref name="min"/> and less
        /// than or equal to <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="min">The minimum allowed value for <paramref name="target"/>.</param>
        /// <param name="max">The maximum allowed value for <paramref name="target"/>.</param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotInRange<T>(this Argument<T> target, T min, T max)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
            min.Require(nameof(min)).IsNotNullIfNullable();
            max.Require(nameof(max)).IsNotNullIfNullable();

            if (!(target.Value.IsLessThan(min) || target.Value.IsGreaterThan(max)))
                throw new ArgumentOutOfRangeException(
                    target.Name,
                    $"Must be less than {min} or greater than {max}.");

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to <paramref name="floor"/>, or greater
        /// than or equal to <paramref name="ceiling"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="floor">
        /// The value that <paramref name="target"/> must be greater than.
        /// </param>
        /// <param name="ceiling">
        /// The value that <paramref name="target"/> must be less than.
        /// </param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsBetween<T>(this Argument<T> target, T floor, T ceiling)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();
            floor.Require(nameof(floor)).IsNotNullIfNullable();
            ceiling.Require(nameof(ceiling)).IsNotNullIfNullable(); 

            return target.IsGreaterThan(floor).IsLessThan(ceiling);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than <paramref name="floor"/> and less than
        /// <paramref name="ceiling"/>.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="floor">
        /// The floor of the range that <paramref name="target"/>'s value must not be in.
        /// </param>
        /// <param name="ceiling">
        /// The ceiling of the range that <paramref name="target"/>'s value must not be in.
        /// </param>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotBetween<T>(this Argument<T> target, T floor, T ceiling)
            where T : IComparable<T>
        {
            target.AssertArgumentIsComparable();

            floor.Require(nameof(floor)).IsNotNullIfNullable();
            ceiling.Require(nameof(ceiling)).IsNotNullIfNullable();

            if (target.Value.IsGreaterThan(floor) && target.Value.IsLessThan(ceiling))
                throw new ArgumentOutOfRangeException(
                    target.Name,
                    $"Must be less than or equal to {floor} or greater than or equal to {ceiling}.");

            return target;
        }

        private static bool IsLessThan<T>(this IComparable<T> target, T value) =>
            target.CompareTo(value) < 0;

        private static bool IsGreaterThan<T>(this IComparable<T> target, T value) =>
            target.CompareTo(value) > 0;

        private static void AssertArgumentIsComparable<T>(this Argument<T> target)
        {
            if (target.Value == null)
                throw new InvalidOperationException(
                    $"Cannot compare against null-valued Argument.");
        }


    }
}
