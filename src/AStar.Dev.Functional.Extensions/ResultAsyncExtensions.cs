using System;
using System.Threading;
using System.Threading.Tasks;

namespace AStar.Dev.Functional.Extensions;

/// <summary>
/// </summary>
public static class ResultAsyncExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="task"></param>
    /// <param name="map"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TNew, TError>> MapAsync<T, TError, TNew>(
        this ValueTask<Result<T, TError>> task,
        Func<T, TNew>                     map,
        CancellationToken                 cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await task;

        return result.Map(map);
    }

    /// <summary>
    /// </summary>
    /// <param name="task"></param>
    /// <param name="bind"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TNew"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TNew, TError>> BindAsync<T, TError, TNew>(
        this ValueTask<Result<T, TError>>        task,
        Func<T, ValueTask<Result<TNew, TError>>> bind,
        CancellationToken                        cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await task;

        return result is Result<T, TError>.Ok ok
                   ? await bind(ok.Value)
                   : new Result<TNew, TError>.Error(((Result<T, TError>.Error)result).Reason);
    }

    /// <summary>
    /// </summary>
    /// <param name="task"></param>
    /// <param name="onSuccess"></param>
    /// <param name="onError"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static async ValueTask<TResult> MatchAsync<T, TError, TResult>(
        this ValueTask<Result<T, TError>> task,
        Func<T, TResult>                  onSuccess,
        Func<TError, TResult>             onError,
        CancellationToken                 cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await task;

        return result.Match(onSuccess, onError);
    }
}
