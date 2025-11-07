namespace Simple.Result;

public sealed class Result<T>
{
    public Status Status { get; init; }
    public string? Message { get; init; }
    public T? Value { get; init; }
    public Exception? Exception { get; init; }
    public Type Type => typeof(T);
    
    public bool IsSuccess => Status is
        Status.Success or
        Status.Created or
        Status.NoOperation or
        Status.FileStreamResult;

    public static Result<T> OfSuccess(T value, string? message = null) => new()
    {
        Message = message ?? "Operation was successful",
        Value = value,
        Exception = null,
        Status = Status.Success
    };
    
    public static Result<T> OfNoOperation(string? message = null) => new()
    {
        Message = message ?? "Operation was successful",
        Value = default,
        Exception = null,
        Status = Status.NoOperation
    };
    
    public static Result<T> OfCreated(T value, string? message = null) => new()
    {
        Message = message ?? "Resource was successfully created",
        Value = value,
        Exception = null,
        Status = Status.Created
    };
    
    public static Result<T> OfException(Exception exception, string? message = null) => new()
    {
        Message = message ?? "Operation resulted in an exception",
        Value = default,
        Exception = exception,
        Status = Status.Exception
    };
    
    public static Result<T> OfNotFound(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "The resource was not found",
        Value = default,
        Exception = exception,
        Status = Status.NotFound
    };
    
    public static Result<T> OfServerError(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to server error",
        Value = default,
        Exception = exception,
        Status = Status.ServerError
    };
    
    public static Result<T> OfClientError(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to client error",
        Value = default,
        Exception = exception,
        Status = Status.ClientError
    };
    
    public static Result<T> OfConflict(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to conflict",
        Value = default,
        Exception = exception,
        Status = Status.Conflict
    };
    
    public static Result<T> OfAccessDenied(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to access denied",
        Value = default,
        Exception = exception,
        Status = Status.AccessDenied
    };
    
    public static Result<T> OfContentTooLarge(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to content too large",
        Value = default,
        Exception = exception,
        Status = Status.ContentTooLarge
    };
}