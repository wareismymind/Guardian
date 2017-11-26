using System;

namespace wimm.Guardian
{
    /// <summary>
    /// Adds 'IsNotNull' extensions to the <see cref="Argument{T}"/> type.
    /// </summary>
    public static class Argument_IsNotNullExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the value of
        /// <paramref name="argument"/> is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of the value of <paramref name="argument"/>.</typeparam>
        /// <param name="argument">The <see cref="Argument{T}"/> to evaluate.</param>
        /// <returns>The <see cref="Argument{T}"/>.</returns>
        public static Argument<T> IsNotNull<T>(this Argument<T> argument)
        {
            // This extension is available to non-nullable types because I couldn't find a generic
            // constraint that included reference types and nullables (int?, etc.).

            return 
                argument.IfNot(
                    v => v != null, 
                    a => throw new ArgumentNullException(a.Name)) as Argument<T>;
        }
    }
}
