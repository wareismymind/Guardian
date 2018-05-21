using System;
using System.Collections.Generic;

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
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        public Argument<T> IsNotNull()
        {
            if (default(T) != null)
                throw new InvalidOperationException($"{nameof(T)} must be nullable to check for null");

            // TODO: Find a way to constrain this to nullables or throw for non-nullable types.
            if (Value == null) throw new ArgumentNullException(Name);
            return this;
        }

        // TODO: Remove equality overloads. 
        // Tests should just verify the member values, 2 arguments with the same name and value
        // aren't neccessarily the same argument.

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override bool Equals(object obj)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {

            if (obj is Argument<T> subject)
            {
                return Name == subject.Name &&
                   EqualityComparer<T>.Default.Equals(Value, subject.Value);
            }

            return false;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override int GetHashCode()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            var hashCode = -244751520;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Value);
            return hashCode;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator ==(Argument<T> argument1, Argument<T> argument2) =>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            EqualityComparer<Argument<T>>.Default.Equals(argument1, argument2);

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static bool operator !=(Argument<T> argument1, Argument<T> argument2) =>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
             !(argument1 == argument2);
    }
}
