namespace AStar.Dev.Functional.Extensions;

/// <summary>
///     The generic <see cref="Some{T}" /> class contains the result for a successful method
/// </summary>
/// <typeparam name="T">The type of the return object</typeparam>
/// <remarks>
/// </remarks>
/// <param name="content">The content (actual result) object</param>
public sealed class Some<T>(T content) : Option<T>
{
    /// <summary>
    ///     The content (actual result) object
    /// </summary>
    public T Content { get; } = content;

    /// <summary>
    ///     Overrides the default ToString to return the object type or &lt;null&gt;
    /// </summary>
    /// <remarks>
    ///     Once the ToJson method (in AStar.Dev.Utilities) respects the 'Mask', 'Ignore' etc. attributes, we can reconsider whether this method returns the actual object
    /// </remarks>
    /// <returns>The object type name or null.</returns>
    public override string ToString()
    {
        return Content?.ToString() ?? "<null>";
    }
}
