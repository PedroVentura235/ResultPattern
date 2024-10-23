using Microsoft.AspNetCore.Http;

namespace ResultPattern;

public class Result<TValue, TError> : ICustomResult where TError : Error
{
    public readonly TValue? Value;
    public readonly TError? Error;

    private bool _isSuccess;

    private Result(TValue value)
    {
        _isSuccess = true;
        Value = value;
        Error = default;
    }

    private Result(TError error)
    {
        _isSuccess = false;
        Value = default;
        Error = error;
    }

    //happy path
    public static implicit operator Result<TValue, TError>(TValue value) => new Result<TValue, TError>(value);

    //error path
    public static implicit operator Result<TValue, TError>(TError error) => new Result<TValue, TError>(error);

    public IResult Match()
    {
        if (_isSuccess)
        {
            return Results.Ok(Value!);
        }
        return Results.Content(content: Error.Message, statusCode: (int)Error.StatusCode);
    }

    public IResult Match(Func<TValue, IResult> success, Func<TError, IResult> failure)
    {
        if (_isSuccess)
        {
            return success(Value!);
        }
        return failure(Error!);
    }
}