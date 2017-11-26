using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds an extension to create an <see cref="ISubject{T}"/> from any value.
    /// </summary>
    public static class RequireExtension
    {
        /// <summary>
        /// Gets an <see cref="ISubject{T}"/> for the value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="target">the target.</param>
        /// <param name="name">The name for the <see cref="ISubject{T}"/>.</param>
        /// <returns>An <see cref="ISubject{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> is <c>null</c>.
        /// </exception>
        public static ISubject<T> Require<T>(this T target, string name)
        {
            if (name == null) { throw new ArgumentNullException(nameof(name)); }
            return new Subject<T>(target, name);
        }
    }
}
