using System;
using System.Collections.Generic;

namespace wimm.Guardian
{
    /// <summary>
    /// Represents a method argument.
    /// </summary>
    /// <typeparam name="T">The type of the value of the <see cref="Argument{T}"/>.</typeparam>
    public class Argument<T>
    {
        /// <summary>
        /// The name of the <see cref="Argument{T}"/>.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The value of the <see cref="Argument{T}"/>.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Creates a <see cref="Argument{T}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> is <c>null</c>.
        /// </exception>
        public Argument(T value, string name)
        {
            Value = value;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the value of the
        /// <see cref="Argument{T}"/> is null.
        /// </summary>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        public Argument<T> IsNotNull()
        {
            if (Value == null) throw new ArgumentNullException(Name);
            return this;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public override bool Equals(object obj)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            var subject = obj as Argument<T>;
            return subject != null &&
                   Name == subject.Name &&
                   EqualityComparer<T>.Default.Equals(Value, subject.Value);
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
