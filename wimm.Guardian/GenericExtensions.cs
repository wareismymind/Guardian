namespace wimm.Guardian
{
    internal static class GenericExtensions
    {
        internal static void IsNotNullIfNullable<T>(this Argument<T> argument)
        {
            if (default(T) == null)
                argument.IsNotNull();
        }
    }
}
