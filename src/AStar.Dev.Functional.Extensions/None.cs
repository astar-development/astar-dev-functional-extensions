namespace AStar.Dev.Functional.Extensions;

/// <summary>
///     The <see cref="None" /> class that exists for when we have no object
/// </summary>
public sealed class None
{
    /// <summary>
    ///     The Value will always return an instance of <see cref="None" />, it can never return an actual value
    /// </summary>
    public static None Value { get; } = new();

    /// <summary>
    ///     The Of{T} method can be used to return an instance of the generic <see cref="None{T}" /> when there is no actual value to return
    /// </summary>
    /// <typeparam name="T">The type of the original object that this instance of <see cref="None" /> is replacing</typeparam>
    /// <returns>The appropriate type of <see cref="None{T}" /></returns>
    public static None<T> Of<T>()
    {
        return new();
    }
}
