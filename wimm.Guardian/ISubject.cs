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
        /// Executes <paramref name="consequence"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="subject">The target <see cref="ISubject{T}"/>.</param>
        /// <param name="condition">The condition to check.</param>
        /// <param name="consequence">The action to perform.</param>
        /// <returns>The <see cref="ISubject{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="subject"/>, <paramref name="condition"/>, or
        /// <paramref name="consequence"/> is <c>null</c>.
        /// </exception>
        public static ISubject<T> IfNot<T>(
            this ISubject<T> subject, Func<T, bool> condition, Action<ISubject<T>> consequence)
        {
            if (subject == null) { throw new ArgumentNullException(nameof(subject)); }
            if (condition == null) { throw new ArgumentNullException(nameof(condition)); }
            if (consequence == null) { throw new ArgumentNullException(nameof(consequence)); }
            if (!condition(subject.Value)) { consequence(subject); }
            return subject;
        }
    }
}
