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
        /// Throws an <see cref="EnumArgumentOutOfRangeException"/> if the enum argument does not
        /// correspond with the enum's predefined values
        /// </summary>
        /// <typeparam name="T"> The enum type to be tested </typeparam>
        /// <param name="argument"> An argument containing the value to be checked </param>
        /// <returns> A copy of the input <see cref="Argument{T}"/> </returns>
        /// <exception cref="TypeArgumentException"> 
        /// The input type <typeparamref name="T"/> is not an enum type
        /// </exception>
        /// <exception cref="EnumArgumentOutOfRangeException">
        /// The value of <paramref name="argument"/> does not match the value of any defined value 
        /// of <typeparamref name="T"/>
        /// </exception>
        public static Argument<T> IsDefinedEnum<T>(this Argument<T> argument) 
            where T : struct, IComparable
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new TypeArgumentException(nameof(T), typeof(T));

            if (!Enum.IsDefined(typeof(T), argument.Value))
                throw new EnumArgumentOutOfRangeException(
                   argument.Name, typeof(T), (int)(ValueType)argument.Value);

            return argument;

        }
    }
}
