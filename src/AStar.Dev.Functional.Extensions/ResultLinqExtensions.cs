using System;

namespace AStar.Dev.Functional.Extensions;

/// <summary>
/// </summary>
public static class ResultLinqExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="bind"></param>
    /// <param name="project"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Result<TResult, TError> SelectMany<TSource, TError, TCollection, TResult>(this Result<TSource, TError>        source, Func<TSource, Result<TCollection, TError>> bind,
                                                                                            Func<TSource, TCollection, TResult> project)
    {
        return source.Match(
                            ok => bind(ok).Match<Result<TResult, TError>>(
                                                                          inner => new Result<TResult, TError>.Ok(project(ok, inner)),
                                                                          err => new Result<TResult, TError>.Error(err)
                                                                         ),
                            err => new Result<TResult, TError>.Error(err)
                           );
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="binder"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <returns></returns>
    public static Result<TNew, TError> SelectMany<T, TError, TNew>(this Result<T, TError> result, Func<T, Result<TNew, TError>> binder)
    {
        return result.Bind(binder);
    }

    /// <summary>
    /// </summary>
    /// <param name="result"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <returns></returns>
    public static Result<TNew, TError> Select<T, TError, TNew>(this Result<T, TError> result, Func<T, TNew> selector)
    {
        return result.Map(selector);
    }
}
