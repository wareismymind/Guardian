using System;
using System.Text.RegularExpressions;

namespace wimm.Guardian
{
    /// <summary>
    /// TODO:CN
    /// </summary>
    public static class StringArgumentRegexExtensions
    {

        /// <summary>
        /// Throws an exception if the <see cref="Argument{T}.Value"/> member of 
        /// <paramref name="pattern"/> does not match the regex <paramref name="pattern"/>
        /// </summary>
        /// <param name="target"> The target to be evaluated </param>
        /// <param name="pattern"> A valid .Net regex </param>
        /// <returns> 
        /// An <see cref="Argument{T}"/> equivalent to <paramref name="target"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="pattern"/> is <c>null</c>
        /// </exception>
        /// <exception cref="ArgumentException"> 
        /// <paramref name="pattern"/> is not a valid .Net regex 
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> does not match
        /// the regex given by <paramref name="pattern"/>
        /// </exception>
        public static Argument<string> IsMatch(this Argument<string> target, string pattern)
        {
            var regexArg = pattern.Require(nameof(pattern)).IsNotNull();
            Regex reg = null;

            try
            {
               reg = new Regex(pattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{pattern} must be a valid regular expression", regexArg.Name, ex);
            }

            target.IsMatch(reg);
            return target;
        }

        /// <summary>
        /// Throws an exception if the <see cref="Argument{T}.Value"/> member of 
        /// <paramref name="regex"/> does not match <paramref name="regex"/>
        /// </summary>
        /// <param name="target"> The target to be evaluated </param>
        /// <param name="regex"> The regex against which <paramref name="target"/> is to be 
        /// compared </param>
        /// <returns> 
        /// An <see cref="Argument{T}"/> equivalent to <paramref name="target"/>
        /// </returns>
        /// <exception cref="ArgumentNullException"> 
        /// <paramref name="regex"/> is <c>null</c></exception>
        /// <exception cref="ArgumentException">
        /// The <see cref="Argument{T}.Value"/> member of <paramref name="target"/> does not match
        /// the regex given by <paramref name="regex"/>
        /// </exception>
        public static Argument<string> IsMatch(this Argument<string> target, Regex regex)
        {
            regex.Require(nameof(regex)).IsNotNull();
            target.IsNotNull();

            if (!regex.IsMatch(target.Value))
                throw new ArgumentException($"{target.Name} must match pattern {regex}", target.Name);

            return target;
        }
    }
}
