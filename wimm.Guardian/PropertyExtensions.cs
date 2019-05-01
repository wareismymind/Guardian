using System;
using System.Linq.Expressions;

namespace wimm.Guardian
{
    /// <summary>
    /// Extensions related to validating properties of existing arguments
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// Selects a property from an <see cref="Argument{T}"/> and returns an <see cref="Argument{T}"/> 
        /// that is named after the property and the owning class
        /// </summary>
        /// <typeparam name="T"> The type of value that owns the property to be validated </typeparam>
        /// <typeparam name="U"> The type of the property to be extracted and validated </typeparam>
        /// <param name="argument"> The <see cref="Argument{T}"/> that owns the property </param>
        /// <param name="selector"> A lambda expression selector that returns the property in question. </param>
        /// <returns>
        /// An <see cref="Argument{T}"/> containing the value of the property and a name in the form of 
        /// 'Owner.PropertyName' 
        /// </returns>
        /// <exception cref="InvalidProgramException">
        /// The expression in <paramref name="selector"/> is not a <see cref="LambdaExpression"/> that accesses a 
        /// member of <typeparamref name="T"/>
        /// </exception>
        public static Argument<U> Property<T, U>(this Argument<T> argument, Expression<Func<T, U>> selector)
        {
            if (selector.Body is MemberExpression body && body.NodeType == ExpressionType.MemberAccess)
                return new Argument<U>($"{argument.Name}.{body.Member.Name}", selector.Compile()(argument.Value));

            throw new InvalidProgramException($"{nameof(selector)} must be a {nameof(MemberExpression)}. Was {typeof(U)}");
        }
    }
}
