using System;

namespace wimm.Guardian
{
    /// <summary>
    /// A method argument.
    /// </summary>
    /// <typeparam name="T">The type of the arugment.</typeparam>
    public struct Argument<T>
    {
        /// <summary>
        /// The argument name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The argument value.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new a <see cref="Argument{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> is <c>null</c>.
        /// </exception>
        public Argument(string name, T value)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Value = value;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <see cref="Value"/> is <c>null</c>.
        /// </summary>
        /// <exception cref="InvalidOperationException"> 
        /// The default value of <typeparamref name="T"/> is not null.
        /// </exception>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        public Argument<T> IsNotNull()
        {
            if (default(T) != null)
                throw new InvalidOperationException($"{nameof(T)} must be nullable to check for null");
            
            if (Value == null) throw new ArgumentNullException(Name);
            return this;
        }
    }
}
