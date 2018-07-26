using System;
using System.Reflection;
using System.Runtime.CompilerServices;

//TODO:I47 -> Remove eventually, or not
[assembly:InternalsVisibleTo("wimm.Guardian.UnitTests")]

namespace wimm.Guardian
{
    internal static class GenericExtensions
    {
        internal static void IsNotNullIfNullable<T>(this Argument<T> argument)
        {
            if (default(T) == null)
                argument.IsNotNull();
        }

        //TODO:I47 -> Internal for now until tested and doc'd
        internal static Argument<T> HasAttribute<T>(this Argument<T> argument, Type attributeType)
        {
            var attribute = typeof(T).GetTypeInfo().GetCustomAttribute(attributeType)
                ?? throw new TypeArgumentException(argument.Name, typeof(T));

            return argument;
        }


        public static Argument<T> IsEnum<T>(this Argument<T> argument) where T : struct, IComparable
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new TypeArgumentException(nameof(T), typeof(T));

            return argument;
        }
    }
}
