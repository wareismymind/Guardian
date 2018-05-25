using System;

namespace wimm.Guardian
{

    /// <summary>
    /// Argument validation methods for strings
    /// </summary>
    public static class StringArgumentExtensions
    {

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the value of <paramref name="target"/>
        /// is null
        /// <see cref="ArgumentException"/> if the value of <paramref name="target"/>
        /// is <c> null </c> or all whitespace.
        /// </summary>
        /// <param name="target"> The target to be evaluated </param>
        /// <returns>
        /// An instance of <see cref="Argument{T}"/> identical to <paramref name="target"/>
        /// </returns>
        /// <exception cref="ArgumentNullException"> 
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is whitespace
        /// </exception>
        public static Argument<string> IsNotNullOrWhitespace(this Argument<string> target)
        {
            target.IsNotNull();

            if (target.Value.IsWhiteSpace())
                throw new ArgumentException(
                    $"{target.Name} must contain at least one non whitespace character",
                    target.Name);

            return target;
                
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of <paramref name="target"/>
        /// is all whitespace
        /// </summary>
        /// <param name="target"> The target to be evaluated </param>
        /// <returns>
        /// An instance of <see cref="Argument{T}"/> identical to <paramref name="target"/>
        /// </returns>
        /// <exception cref="ArgumentException"> 
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is whitespace
        /// </exception>
        public static Argument<string> IsNotWhitespace(this Argument<string> target)
        {
            if (target.Value == null)
                return target;

            if (target.Value.IsWhiteSpace())
                throw new ArgumentException(
                    $"{target.Name} must contain at least one non whitespace character",
                    target.Name);

            return target;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of <paramref name="target"/>
        /// is <see cref="String.Empty"/>
        /// </summary>
        /// <param name="target">The target to be evaluated</param>
        /// <returns>
        /// An instance of <see cref="Argument{T}"/> identical to <paramref name="target"/>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> is equal
        /// to <see cref="String.Empty"/>
        /// </exception>
        public static Argument<string> IsNotEmpty(this Argument<string> target)
        {
            if (target.Value == string.Empty)
                throw new ArgumentException($"{target.Name} must not be empty.",
                    target.Name);

            return target;
        }


        // [NetStandardCompliance - Version 1.0 - Missing IEnumerable<T>.Any()]
        private static bool IsWhiteSpace(this string s)
        {
            foreach (var character in s)
            {
                if (!char.IsWhiteSpace(character))
                    return false;
            }

            return true;
        }

    }
}
