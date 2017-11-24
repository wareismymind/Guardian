using System;

namespace wimm.Guardian
{
    /// <summary>
    /// A target for validation.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class Subject<T> : ISubject<T>
    {
        /// <summary>
        /// The name of the <see cref="ISubject{T}"/>.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The value of the <see cref="ISubject{T}"/>.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Creates a <see cref="Subject{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> is <c>null</c>.
        /// </exception>
        public Subject(T value, string name)
        {
            Value = value;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
