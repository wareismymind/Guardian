using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace wimm.Guardian
{
    /// <summary>
    /// Argument validation methods for enums
    /// </summary>
    public static class EnumArgumentExtensions
    {
        /// <summary>
        /// TODO:CN
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static Argument<T> IsDefined<T>(this Argument<T> argument) where T : struct, IComparable
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new TypeArgumentException(nameof(T), typeof(T));

            if (!Enum.IsDefined(argument.Value.GetType(), argument.Value))
                throw new EnumArgumentOutOfRangeException(
                   argument.Name, typeof(T), (int)(ValueType)argument.Value);

            return argument;

        }
    }
}
