using System;

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
            : this(typeParamName, type, null)
        {

        }

        internal TypeArgumentException(string typeParamName, Type type, string additionalMessage)
            : base($"{typeParamName} does not support type {type.FullName}.{additionalMessage ?? string.Empty}")
        {
            TypeParamName = typeParamName.Require(nameof(typeParamName)).IsNotNull().Value;
            Type = type.Require(nameof(type)).IsNotNull().Value;
        }
    }
}
