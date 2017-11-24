using System;

namespace wimm.Guardian
{
    /// <summary>
    /// An <see cref="ISubject{T}"/> that is known to be a argument.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    /// This type exists simply to allow argument specific methods to be defined 
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
    }

    /// <summary>
    /// Adds an extension method to <see cref="ISubject{T}"/> to turn the instance into an
    /// <see cref="wimm.Guardian.Argument{T}"/>.
    /// </summary>
    public static class ArgumentExtension
    {
        public static Argument<T> Argument<T>(this ISubject<T> subject)
        {
            return new Argument<T>(subject);
        }
    }
}
