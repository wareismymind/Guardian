namespace wimm.Guardian
{
    /// <summary>
    /// A validation action for an <see cref="Argument{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value to validate.</typeparam>
    /// <param name="value">The value to validate.</param>
    /// <returns><c>true</c> is the value is valid, otherwise <c>false</c>.</returns>
    public delegate bool Validation<T>(T value);
}
