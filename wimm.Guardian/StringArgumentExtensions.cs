using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian
{
    public static class StringArgumentExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static Argument<string> IsNotNullOrWhitespace(this Argument<string> target)
        {
            target.Require(nameof(target)).IsNotNull();
            target.IsNotNull();

            return target.IsNotNullOrWhitespaceUnsafe();
        }

        public static Argument<string> IsNotWhitespace(this Argument<string> target)
        {
            target.Require(nameof(target)).IsNotNull();

            if (target.Value == null)
                return target;

            return target.IsNotNullOrWhitespaceUnsafe();
        }

        public static Argument<string> IsNotEmpty(this Argument<string> target)
        {
            target.Require(nameof(target)).IsNotNull();

            if (target.Value == string.Empty)
                throw new ArgumentException($"{target.Name} must not be whitespace.");

            return target;
        }



        //CN: Unsafe because we're not allowing for target to be null;
        private static Argument<string> IsNotNullOrWhitespaceUnsafe(this Argument<string> target)
        {
            if (string.IsNullOrWhiteSpace(target.Value))
                throw new ArgumentException($"{target.Name} Must contain one or more non-whitespace characters");

            return target;
        }

    }
}
