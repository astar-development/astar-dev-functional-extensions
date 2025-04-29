namespace AStar.Dev.Functional.Extensions;

/// <summary>
///     The <see cref="OptionExtensions" /> class contains a basic set of extension methods to help map, filter, etc. the original object
/// </summary>
public static class OptionExtensions
{
    /// <summary>
    ///     The Map{T,TResult} method will either map the Some{T} to a new Some or return a new None of the specified result type
    /// </summary>
    /// <typeparam name="T">The type of the source object</typeparam>
    /// <typeparam name="TResult">The type of object expected from the map</typeparam>
    /// <param name="obj">The object to map</param>
    /// <param name="map">The Map function</param>
    /// <returns>Either a new Some or a new None of the specified type</returns>
    public static Option<TResult> Map<T, TResult>(this Option<T> obj, Func<T, TResult> map)
    {
        return obj is Some<T> some ? new Some<TResult>(map(some.Content)) : new None<TResult>();
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static Option<T> Filter<T>(this Option<T> obj, Func<T, bool> predicate)
    {
        return obj is Some<T> some && !predicate(some.Content) ? new None<T>() : obj;
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="substitute"></param>
    /// <returns></returns>
    public static T Reduce<T>(this Option<T> obj, T substitute)
    {
        return obj is Some<T> some ? some.Content : substitute;
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="substitute"></param>
    /// <returns></returns>
    public static T Reduce<T>(this Option<T> obj, Func<T> substitute)
    {
        return obj is Some<T> some ? some.Content : substitute();
    }
}
