namespace AStar.Dev.Functional.Extensions;


/// <summary>
///
/// </summary>
/// <typeparam name="TError"></typeparam>
/// <typeparam name="TSuccess"></typeparam>
public readonly struct Result<TError, TSuccess>
{
    /// <summary>
    ///
    /// </summary>
    public readonly TSuccess? Value { get; }

    /// <summary>
    ///
    /// </summary>
    public readonly TError?   Error { get; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="successObject"></param>
    /// <param name="errorObject"></param>
    /// <param name="isSuccess"></param>
    private Result(TSuccess? successObject, TError? errorObject, bool isSuccess)
    {
        Value          = successObject;
        Error          = errorObject;
        this.IsSuccess = isSuccess;
    }

    /// <summary>
    ///
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    ///
    /// </summary>
    public bool IsFailure => !IsSuccess;

#pragma warning disable CA1000
    /// <summary>
    ///
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Result<TError, TSuccess> Success(TSuccess value) => new(value, default, true);

    /// <summary>
    ///
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static Result<TError, TSuccess?> Failure(TError error) => new(default, error, false);
#pragma warning restore CA1000

    /// <summary>
    ///
    /// </summary>
    /// <param name="success"></param>
    /// <returns></returns>
    public static implicit operator Result<TError, TSuccess>(TSuccess success) => new(success, default, true);

    /// <summary>
    ///
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static implicit operator Result<TError, TSuccess>(TError error) => new(default, error, false);
}
