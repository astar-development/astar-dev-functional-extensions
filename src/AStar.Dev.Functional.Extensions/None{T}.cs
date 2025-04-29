namespace AStar.Dev.Functional.Extensions;

/// <summary>
///     The <see cref="None{T}" /> class replaces the object when there is no object available
/// </summary>
/// <typeparam name="T">The type of the original object</typeparam>
public sealed class None<T> : Option<T>
{
    /// <summary>
    ///     The ToString method is overridden to always return "None"
    /// </summary>
    /// <returns>"None" no matter what the original type was</returns>
    public override string ToString()
    {
        return "None";
    }
}
