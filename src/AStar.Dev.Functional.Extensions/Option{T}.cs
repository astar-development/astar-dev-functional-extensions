namespace AStar.Dev.Functional.Extensions;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
#pragma warning disable CA1716 // Rename type Option so that it no longer conflicts with the reserved language keyword 'Option'
public abstract class Option<T>
#pragma warning restore CA1716
{
    /// <summary>
    /// </summary>
    /// <param name="_"></param>
    public static implicit operator Option<T>(None _)
    {
        return new None<T>();
    }

    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator Option<T>(T value)
    {
        return new Some<T>(value);
    }
}
