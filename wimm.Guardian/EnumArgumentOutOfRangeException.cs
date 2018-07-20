using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian
{
    /// <summary>
    /// An exception to indicate that an enum arguments values fall outside the set values for that enum
    /// </summary>
    public class EnumArgumentOutOfRangeException : ArgumentException
    {
        private const string _defaultMessage = "An enum value was provided as an argument but the value" +
            "was not a value of the enumeration";

        /// <summary>
        /// The enum type the value was tested against
        /// </summary>
        public Type EnumType { get; }
        
        /// <summary>
        /// The name of the argument
        /// </summary>
        public string ArgumentName { get; }

        /// <summary>
        /// Creates a new <see cref="EnumArgumentOutOfRangeException"/> with no message
        /// </summary>
        public EnumArgumentOutOfRangeException() : base() { }

        /// <summary>
        /// Creates a new <see cref="EnumArgumentOutOfRangeException"/> with the specified message
        /// </summary>
        /// <param name="message"> A message to be included in the exception </param>
        public EnumArgumentOutOfRangeException(string message) : base(message) { }

        /// <summary>
        /// Creates a new <see cref="EnumArgumentOutOfRangeException"/> with a formatted message indicating
        /// the name, type and offending value
        /// </summary>
        /// <param name="argument">The name of the argument that was tested </param>
        /// <param name="enumType"> 
        /// The type of enum that <paramref name="value"/> was supposed to represent
        /// </param>
        /// <param name="value"> 
        /// The boxed value that fell outside of the range of values for <paramref name="enumType"/>
        /// </param>
        public EnumArgumentOutOfRangeException(string argument, Type enumType, object  value) 
            : base(FormatMessage(argument,enumType,value))
        {
            ArgumentName = argument;
            EnumType = enumType;
        }

        private static string FormatMessage(string parameter, Type enumType, object value)
        {
            return $"The value '{value}' was provided as the argument '{parameter}' but the" +
                $" value was not a value of the enumeration '{enumType.GetTypeInfo().Name}'";
        }

    }
}
