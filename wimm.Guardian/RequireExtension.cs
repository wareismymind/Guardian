using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Methods to create an <see cref="Argument{T}"/> from a value.
    /// </summary>
    public static class RequireExtension
    {
        /// <summary>
        /// Gets an <see cref="Argument{T}"/> for <paramref name="target"/>.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="target">The argument value.</param>
        /// <param name="name">The argument name.</param>
        /// <returns>An <see cref="Argument{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> is <c>null</c>.
        /// </exception>
        public static Argument<T> Require<T>(this T target, string name)
        {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            return new Argument<T>(target, name);
        }
    }
}
