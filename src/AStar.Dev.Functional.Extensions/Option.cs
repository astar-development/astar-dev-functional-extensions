namespace AStar.Dev.Functional.Extensions;

/// <summary>
///     The <see cref="Option" /> class that contains the original object
/// </summary>
#pragma warning disable CA1716 // Rename type Option so that it no longer conflicts with the reserved language keyword 'Option'
public static class Option
#pragma warning restore CA1716
{
    /// <summary>
    ///     The Optional method will convert the 'raw' object to an <see cref="Option{T}" />
    /// </summary>
    /// <typeparam name="T">The type of the original object</typeparam>
    /// <param name="obj">The object to return as an option</param>
    /// <returns>The original object as an option (and implemented as an instance of <see cref="Some{T}" /></returns>
    public static Option<T> Optional<T>(this T obj)
    {
        return new Some<T>(obj);
    }
}
