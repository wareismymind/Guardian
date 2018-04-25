using System;
using System.Reflection;

namespace wimm.Guardian
{
    /// <summary>
    /// Thrown when a generic method is invoked with an invalid type parameter.
    /// </summary>
    public class TypeArgumentException : Exception
    {
        /// <summary>
        /// The name of the type parameter for which a type was invalid.
        /// </summary>
        public string TypeParamName { get; }

        /// <summary>
        /// The value of the invalid type parameter.
        /// </summary>
        public Type Type { get; }

        internal TypeArgumentException(string typeParamName, Type type)
            : base($"{typeParamName} does not supported type {type.FullName}.")
        {
            TypeParamName = typeParamName.Require(nameof(typeParamName)).IsNotNull().Value;
            Type = type.Require(nameof(type)).IsNotNull().Value;
        }
    }
}
