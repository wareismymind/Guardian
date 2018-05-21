using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian
{

    /// <summary>
    /// TODO:CN
    /// </summary>
    public static class StringArgumentExtensions
    {
        
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of <paramref name="target"/>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Argument<string> IsNotNullOrWhitespace(this Argument<string> target)
        {
            target.IsNotNull();

            if (target.Value.IsWhiteSpace())
                throw new ArgumentException(
                    $"{target.Name} must contain at least one non whitespace character");

            return target;
                
        }
        
        /// <summary>
        /// TODO:CN
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Argument<string> IsNotWhitespace(this Argument<string> target)
        {
            if (target.Value == null)
                return target;

            if (target.Value.IsWhiteSpace())
                throw new ArgumentException(
                    $"{target.Name} must contain at least one non whitespace character");

            return target;
        }

        /// <summary>
        /// TODO:CN
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Argument<string> IsNotEmpty(this Argument<string> target)
        {
            if (target.Value == string.Empty)
                throw new ArgumentException($"{target.Name} must not be empty.");

            return target;
        }


        private static bool IsWhiteSpace(this string s)
        {
            return s.All(x => char.IsWhiteSpace(x));
        }

    }
}
