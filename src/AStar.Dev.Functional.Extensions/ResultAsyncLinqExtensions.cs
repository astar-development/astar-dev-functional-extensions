using System;
using System.Threading;
using System.Threading.Tasks;

namespace AStar.Dev.Functional.Extensions;

/// <summary>
/// </summary>
public static class ResultAsyncLinqExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="source"></param>
    /// <param name="bind"></param>
    /// <param name="project"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TError"></typeparam>
    /// <typeparam name="TCollection"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Result<TResult, TError>> SelectMany<TSource, TError, TCollection, TResult>(
        this ValueTask<Result<TSource, TError>>               source,
        Func<TSource, ValueTask<Result<TCollection, TError>>> bind,
        Func<TSource, TCollection, TResult>                   project,
        CancellationToken                                     cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var result = await source;

        return result is Result<TSource, TError>.Ok ok
                   ? await bind(ok.Value).MapAsync(
                                                   inner => project(ok.Value, inner),
                                                   cancellationToken)
                   : new Result<TResult, TError>.Error(((Result<TSource, TError>.Error)result).Reason);
    }
}
