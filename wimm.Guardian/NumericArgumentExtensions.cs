using System;
using System.Collections.Generic;
using System.Linq;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds validation methods for <see cref="IComparable{T}"/> <see cref="Argument{T}"/> types
    /// whose values are numeric types.
    /// </summary>
    /// <remarks>
    /// Supported <see cref="IComparable{T}"/> types are;
    /// </remarks>
    public static class NumericArgumentExtensions
    {
        /// <summary>
        /// The supported type-parameter <see cref="Type"/> values for the extension methods.
        /// </summary>
        public static IReadOnlyCollection<Type> SupportedTypes { get; } =
            new List<Type>
            {
                typeof(SByte), typeof(Int16), typeof(Int32), typeof(Int64),
                typeof(Single), typeof(Double),
            };

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than or equal to the zero value for
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="TypeArgumentException">
        /// <typeparamref name="T"/> is not a valid numeric type.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsPositive<T>(this Argument<T> target)
            where T : IComparable<T>
        {
            typeof(T).Require(nameof(T)).IsSupportedTypeParam();
            target.Require(nameof(target)).IsNotNull();
            return target.IsGreaterThan(Zero<T>());
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than or equal to the zero value for
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns><paramref name="target"/>.</returns>
        /// <exception cref="TypeArgumentException">
        /// <typeparamref name="T"/> is not a valid numeric type.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> IsNegative<T>(this Argument<T> target)
            where T : IComparable<T>
        {
            typeof(T).Require(nameof(T)).IsSupportedTypeParam();
            target.Require(nameof(target)).IsNotNull();
            return target.IsLessThan(Zero<T>());
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is greater than the zero value for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
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
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotGreaterThan(Zero<T>());
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value of
        /// <paramref name="target"/> is less than the zero value for <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
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
            target.Require(nameof(target)).IsNotNull();
            return target.IsNotLessThan(Zero<T>());
        }

        private static T Zero<T>() => default(T);
        private static bool TypeIsSupported<T>() => SupportedTypes.Contains(typeof(T));

        private static Argument<Type> IsSupportedTypeParam(this Argument<Type> target)
        {
            target.Require(nameof(target)).IsNotNull();
            if (!SupportedTypes.Contains(target.Value))
                throw new TypeArgumentException(target.Name, target.Value);
            return target;
        }
    }
}
