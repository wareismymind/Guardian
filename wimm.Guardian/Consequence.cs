namespace wimm.Guardian
{
    /// <summary>
    /// The consequence for an <see cref="Argument{T}"/> whose value fails validation.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Argument{T}"/>'s value.</typeparam>
    /// <param name="argument">The <see cref="Argument{T}"/> whose value failed validation.</param>
    public delegate void Consequence<T>(Argument<T> argument);
}
