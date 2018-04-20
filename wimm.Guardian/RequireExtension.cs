using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds an extension to create an <see cref="Argument{T}"/> from any value.
    /// </summary>
    public static class RequireExtension
    {
        /// <summary>
        /// Gets an <see cref="Argument{T}"/> for the value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">the target.</param>
        /// <param name="name">The name for the <see cref="Argument{T}"/>.</param>
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
