using System;

namespace wimm.Guardian
{
    /// <summary>
    /// A target for data validation within a program.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <remarks>
    /// The model example of an <see cref="ISubject{T}"/> is a method parameter. In this example
    /// the value of <see cref="Name"/> would be the identifier of the parameter and the value of
    /// <see cref="Value"/> would be the value of in the incoming argument.
    /// </remarks>
    public interface ISubject<T>
    {
        /// <summary>
        /// The name of the <see cref="ISubject{T}"/>.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The value of the <see cref="ISubject{T}"/>.
        /// </summary>
        T Value { get; }
    }

    /// <summary>
    /// Adds common extensions to the <see cref="ISubject{T}"/> interface.
    /// </summary>
    public static class ISubjectExtensions
    {
        /// <summary>
        /// Executes <paramref name="consequence"/> if <paramref name="condition"/> is <c>true</c>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="consequence">The action to perform.</param>
        /// <returns>The <see cref="ISubject{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, <paramref name="condition"/>, or
        /// <paramref name="consequence"/> is <c>null</c>.
        /// </exception>
        public static ISubject<T> If<T>(
            this ISubject<T> target, Func<T, bool> condition, Action<ISubject<T>> consequence)
        {
            if (target == null) { throw new ArgumentNullException(nameof(target)); }
            if (condition == null) { throw new ArgumentNullException(nameof(condition)); }
            if (consequence == null) { throw new ArgumentNullException(nameof(consequence)); }
            if (condition(target.Value)) { consequence(target); }
            return target;
        }

        /// <summary>
        /// Executes <paramref name="consequence"/> if <paramref name="condition"/> is
        /// <c>false</c>.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="consequence">The action to perform.</param>
        /// <returns>The <see cref="ISubject{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="target"/>, <paramref name="condition"/>, or
        /// <paramref name="consequence"/> is <c>null</c>.
        /// </exception>
        public static ISubject<T> IfNot<T>(
            this ISubject<T> target, Func<T, bool> condition, Action<ISubject<T>> consequence)
        {
            if (target == null) { throw new ArgumentNullException(nameof(target)); }
            if (condition == null) { throw new ArgumentNullException(nameof(condition)); }
            if (consequence == null) { throw new ArgumentNullException(nameof(consequence)); }
            return target.If(t => !condition(t), consequence);
        }
    }
}
