using System;
using System.Collections.Generic;
using System.Linq;

namespace wimm.Guardian
{
    /// <summary>
    /// Validation methods for numeric arguments.
    /// </summary>
    /// <remarks>
    /// Supported types are; <see cref="sbyte"/>, <see cref="short"/>, <see cref="int"/>,
    /// <see cref="long"/>, <see cref="float"/>, and <see cref="double"/>.
    /// </remarks>
    public static class NumericArgumentExtensions
    {
        private static IReadOnlyCollection<Type> _supportedTypes { get; } =
            new List<Type>
            {
                typeof(sbyte), typeof(short), typeof(int), typeof(long),
                typeof(float), typeof(double)
            };

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to zero.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="TypeArgumentException">
        /// <typeparamref name="T"/> is not a valid numeric type.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsPositive<T>(this Argument<T> target) where T : IComparable<T>
        {
            typeof(T).Require(nameof(T)).IsSupportedTypeParam();
            return target.IsGreaterThan(default(T));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to zero.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="TypeArgumentException">
        /// <typeparamref name="T"/> is not a valid numeric type.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNegative<T>(this Argument<T> target) where T : IComparable<T>
        {
            typeof(T).Require(nameof(T)).IsSupportedTypeParam();
            return target.IsLessThan(default(T));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than zero.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="TypeArgumentException">
        /// <typeparamref name="T"/> is not a valid numeric type.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotPositive<T>(this Argument<T> target)
            where T : IComparable<T>
        {
            typeof(T).Require(nameof(T)).IsSupportedTypeParam();
            return target.IsNotGreaterThan(default(T));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than zero.
        /// </summary>
        /// <typeparam name="T">The type of the arugment.</typeparam>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="TypeArgumentException">
        /// <typeparamref name="T"/> is not a valid numeric type.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNotNegative<T>(this Argument<T> target)
            where T : IComparable<T>
        {
            typeof(T).Require(nameof(T)).IsSupportedTypeParam();
            return target.IsNotLessThan(default(T));
        }

        private static Argument<Type> IsSupportedTypeParam(this Argument<Type> target)
        {
            if (!_supportedTypes.Contains(target.Value))
                throw new TypeArgumentException(target.Name, target.Value);
            return target;
        }
    }
}
