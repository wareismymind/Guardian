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
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new TypeArgumentException(nameof(T), typeof(T));

            if (!Enum.IsDefined(typeof(T), argument.Value))
                throw new EnumArgumentOutOfRangeException(
                   argument.Name, typeof(T), (int)(ValueType)argument.Value);

            return argument;

        }

        /// <summary>
        /// TODO:I47
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <returns></returns>
        public static Argument<T> IsFlagCombo<T>(this Argument<T> argument) where T : struct, IComparable
        {
            var type = typeof(T);

            argument.HasAttribute(typeof(FlagsAttribute));

            var underlyingType = Enum.GetUnderlyingType(type);

            if (underlyingType != typeof(int) && underlyingType != typeof(long))
                throw new TypeArgumentException(argument.Name, type, "The underlying type must be int or long");

            long[] values = FlagsToArray(type, underlyingType);


            if (values.Any(x => BitHelpers.PopCount(x) != 1))
                throw new TypeArgumentException(argument.Name, type, "Each flag must only have a single bit set");

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
            //Naive
            var count = 0;

            foreach (var value in flags)
            {
                count += (toTest & value) > 0 ? 1 : 0;
            }

            return count == BitHelpers.PopCount(toTest);
        }

        private static long[] FlagsToArray(Type enumType, Type underlyingType)
        {
            if (underlyingType == typeof(int))
                return ((int[])Enum.GetValues(enumType)).Distinct().Select(x => (long)x).ToArray();
            else
                return ((long[])Enum.GetValues(enumType)).Distinct().ToArray();
        }

    }
}
