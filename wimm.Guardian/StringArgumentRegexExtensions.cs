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
        /// TODO:CN
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Argument<string> IsMatch(this Argument<string> target, string pattern)
        {
            var regexArg = pattern.Require(nameof(pattern)).IsNotNull();

            try
            {
                var reg = new Regex(pattern);
                target.IsMatch(pattern);
                return target;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"{pattern} must be a valid regular expression", regexArg.Name, ex);
            }
        }

        /// <summary>
        /// TODO:CN
        /// </summary>
        /// <param name="target"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Argument<string> IsMatch(this Argument<string> target, Regex regex)
        {
            target.IsNotNull();

            if (regex.IsMatch(target.Value))
                throw new ArgumentException($"{target.Name} must match pattern {regex}", target.Name);


            return target;
        }

    }
}
