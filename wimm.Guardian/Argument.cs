using System;

namespace wimm.Guardian
{
    /// <summary>
    /// An <see cref="ISubject{T}"/> that is known to be a argument.
    /// </summary>
    /// <typeparam name="T">The type of the value of the <see cref="Argument{T}"/>.</typeparam>
    /// <remarks>
    /// This type exists simply to allow argument specific methods to be defined on instances of
    /// <see cref="ISubject{T}"/> that are known to be arguments.
    /// </remarks>
    public class Argument<T> : ISubject<T>
    {
        private readonly ISubject<T> _subject;

        /// <summary>
        /// The name of the <see cref="Argument{T}"/>.
        /// </summary>
        public string Name => _subject.Name;

        /// <summary>
        /// The value of the <see cref="Argument{T}"/>.
        /// </summary>
        public T Value => _subject.Value;

        /// <summary>
        /// Creates an <see cref="Argument{T}"/>.
        /// </summary>
        /// <param name="subject">The underlying <see cref="ISubject{T}"/>.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="subject"/> is <c>null</c>.
        /// </exception>
        public Argument(ISubject<T> subject)
        {
            _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the value of the
        /// <see cref="Argument{T}"/> is null.
        /// </summary>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        public Argument<T> IsNotNull()
        {
            // This method was added directly to the type (instead of as an extension targeting
            // only nullable tyoes) because I couldn't find a generic constraint that included
            // reference types and nullable primative type (int?, etc.).

            return IfNot(v => v != null, a => throw new ArgumentNullException(a.Name));
        }

        /// <summary>
        /// Executes <paramref name="consequence"/> if <paramref name="condition"/> is false.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="consequence">The action to perform.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="condition"/>, or <paramref name="consequence"/> is <c>null</c>.
        /// </exception>
        public Argument<T> IfNot(Func<T, bool> condition, Action<ISubject<T>> consequence)
        {
            if (condition == null) { throw new ArgumentNullException(nameof(condition)); }
            if (consequence == null) { throw new ArgumentNullException(nameof(consequence)); }
            return (this as ISubject<T>).IfNot(condition, consequence) as Argument<T>;
        }
    }

    /// <summary>
    /// Adds an extension method to <see cref="ISubject{T}"/> to turn the instance into an
    /// <see cref="Guardian.Argument{T}"/>.
    /// </summary>
    public static class ArgumentExtension
    {
        /// <summary>
        /// Gets an <see cref="wimm.Guardian.Argument{T}"/> from an <see cref="ISubject{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the </typeparam>
        /// <param name="subject"></param>
        /// <returns>An <see cref="Guardian.Argument{T}"/>.</returns>
        public static Argument<T> Argument<T>(this ISubject<T> subject)
        {
            return new Argument<T>(subject);
        }
    }
}
