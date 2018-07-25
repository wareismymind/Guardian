using System;
using System.Reflection;
using System.Linq;

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
            argument.IsEnum();

            if (!Enum.IsDefined(typeof(T), argument.Value))
                throw new EnumArgumentOutOfRangeException(
                   argument.Name, typeof(T), (int)(ValueType)argument.Value);

            return argument;

        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value of <paramref name="argument"/> cannot
        /// be composed of values of the <see cref="FlagsAttribute"/> tagged <see cref="Enum"/> 
        /// <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">A <see cref="FlagsAttribute"/> tagged <see cref="Enum"/></typeparam>
        /// <param name="argument"> An argument containing the value to be checked </param>
        /// <returns> A copy of the input <see cref="Argument{T}"/></returns>
        /// <exception cref="TypeArgumentException"> 
        /// <typeparamref name="T"/> does not possess the <see cref="FlagsAttribute"/>
        /// </exception>
        /// <exception cref="TypeArgumentException">
        /// The flag values of <typeparamref name="T"/> are not individual bits
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The value <paramref name="argument"/> is not composable from individual flags of the input type
        /// <typeparamref name="T"/>
        /// </exception>
        public static Argument<T> IsFlagCombo<T>(this Argument<T> argument) where T : struct, IComparable
        {
            var type = typeof(T);

            argument.HasAttribute(typeof(FlagsAttribute));

            var values = FlagsToArray(type);

            var asLong = Convert.ToInt64(argument.Value);

            if (!IsComposableFromFlags(asLong, values))
                throw new ArgumentException(
                    $"Argument was not a combination of the flags of type: {type.Name}", argument.Name);

            return argument;
        }


        //TODO:I47 Next PR -> Make public
        private static Argument<T> IsEnum<T>(this Argument<T> argument) where T : struct, IComparable
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new TypeArgumentException(nameof(T), typeof(T));

            return argument;
        }

        private static bool IsComposableFromFlags(long toTest, long[] flags)
        {
            var composed = 0L;

            foreach (var item in flags)
            {
                composed |= item;
            }

            return (toTest & composed) == toTest;

        }

        private static long[] FlagsToArray(Type enumType)
        {
            var values = Enum.GetValues(enumType);
            var arr = new long[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                arr[i] = ((IConvertible)values.GetValue(i)).ToInt64(null);
            }

            return arr;
        }
    }
}
