using System;

namespace AStar.Dev.Functional.Extensions;

/// <summary>
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="map"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <returns></returns>
    public static Result<TNew, TError> Map<T, TError, TNew>(
        this Result<T, TError> result,
        Func<T, TNew>          map)
    {
        return result.Match<Result<TNew, TError>>(
                                                  ok => new Result<TNew, TError>.Ok(map(ok)),
                                                  err => new Result<TNew, TError>.Error(err)
                                                 );
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="bind"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <returns></returns>
    public static Result<TNew, TError> Bind<T, TError, TNew>(
        this Result<T, TError>        result,
        Func<T, Result<TNew, TError>> bind)
    {
        return result.Match(
                            bind,
                            err => new Result<TNew, TError>.Error(err)
                           );
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <returns></returns>
    public static Result<T, TError> Tap<T, TError>(
        this Result<T, TError> result,
        Action<T>              action)
    {
        if (result is Result<T, TError>.Ok ok)
            action(ok.Value);

        return result;
    }
}
