﻿using System;
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

        /// <summary>
        /// Throws a <see cref="TypeArgumentException"/> if the provided type param 
        /// <typeparamref name="T"/> is not an <see cref="Enum"/>
        /// </summary>
        /// <typeparam name="T"> The type to be tested </typeparam>
        /// <param name="argument"> An argument containing a value of <typeparamref name="T"/></param>
        /// <returns> a copy of the input <paramref name="argument"/></returns>
        /// <exception cref="TypeArgumentException"> The <typeparamref name="T"/> is not
        /// an <see cref="Enum"/>
        /// </exception>
        public static Argument<T> IsEnum<T>(this Argument<T> argument) where T : struct, IComparable
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new TypeArgumentException(nameof(T), typeof(T));

            return argument;
        }
    }
}
