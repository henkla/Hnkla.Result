namespace Simple.Result;

/// <summary>
/// Represents an operation Result
/// </summary>
public class Result
{
    /// <summary>
    /// The outcome of the operation the Result represents
    /// </summary>
    public Status Status { get; init; }
    /// <summary>
    /// Might contain further information about the operation the Result represents
    /// </summary>
    public string? Message { get; init; }
    /// <summary>
    /// Might contain an exception if the operation the Result represents yielded in one
    /// </summary>
    public Exception? Exception { get; init; }
    
    /// <summary>
    /// Returns true if Status is any of the following:<br/>
    /// - Success<br/>
    /// - Created<br/>
    /// - NoOperation<br/>
    /// - FileStreamResult<br/><br/>
    ///
    /// Will return false for any ither status
    /// </summary>
    public bool IsSuccess => Status is
        Status.Success or
        Status.Created or
        Status.NoOperation or
        Status.FileStreamResult;
    
    /// <summary>
    /// Creates a Result with status Success
    /// </summary>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic success Result</returns>
    public static Result OfSuccess(string? message = null) => new()
    {
        Message = message ?? "Operation was successful",
        Exception = null,
        Status = Status.Success
    };
    
    /// <summary>
    /// Creates a Result with status NoOperation
    /// </summary>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic success Result</returns>
    public static Result OfNoOperation(string? message = null) => new()
    {
        Message = message ?? "No operation was performed",
        Exception = null,
        Status = Status.NoOperation
    };
    
    /// <summary>
    /// Creates a Result with status Created
    /// </summary>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic created Result</returns>
    public static Result OfCreated(string? message = null) => new()
    {
        Message = message ?? "Resource was successfully created",
        Exception = null,
        Status = Status.Created
    };
    
    /// <summary>
    /// Creates a Result with status Exception
    /// </summary>
    /// <param name="exception">The exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic exception Result</returns>
    public static Result OfException(Exception exception, string? message = null) => new()
    {
        Message = message ?? "Operation resulted in an exception",
        Exception = exception,
        Status = Status.Exception
    };
    
    /// <summary>
    /// Creates a Result with status NotFound
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic not found Result</returns>
    public static Result OfNotFound(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "The resource was not found",
        Exception = exception,
        Status = Status.NotFound
    };
    
    /// <summary>
    /// Creates a Result with status ServerError
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic server error Result</returns>
    public static Result OfServerError(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to server error",
        Exception = exception,
        Status = Status.ServerError
    };
    
    /// <summary>
    /// Creates a Result with status ClientError
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic client error Result</returns>
    public static Result OfClientError(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to client error",
        Exception = exception,
        Status = Status.ClientError
    };
    
    /// <summary>
    /// Creates a Result with status Conflict
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic conflict Result</returns>
    public static Result OfConflict(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to a conflict",
        Exception = exception,
        Status = Status.Conflict
    };
    
    /// <summary>
    /// Creates a Result with status AccessDenied
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic access denied Result</returns>
    public static Result OfAccessDenied(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to access denied",
        Exception = exception,
        Status = Status.AccessDenied
    };
    
    /// <summary>
    /// Creates a Result with status ContentTooLarge
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Non-generic content too large Result</returns>
    public static Result OfContentTooLarge(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to content being too large",
        Exception = exception,
        Status = Status.ContentTooLarge
    };
}

/// <summary>
/// Represents an operation Result that should yield a value
/// </summary>
/// <typeparam name="T">Represents the value type that the Result hold</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// The value yielded by the operation that the Result represents
    /// </summary>
    public T? Value { get; init; }
    /// <summary>
    /// The type of the value yielded from the operation
    /// </summary>
    public Type Type => typeof(T);

    /// <summary>
    /// Creates a Result with status Success
    /// </summary>
    /// <param name="value">The object yielded by the operation</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed success Result</returns>
    public static Result<T> OfSuccess(T value, string? message = null) => new()
    {
        Message = message ?? "Operation was successful",
        Value = value,
        Exception = null,
        Status = Status.Success
    };
    
    /// <summary>
    /// Creates a Result with status NoOperation
    /// </summary>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed success Result</returns>
    public new static Result<T> OfNoOperation(string? message = null) => new()
    {
        Message = message ?? "No operation was performed",
        Value = default,
        Exception = null,
        Status = Status.NoOperation
    };

    /// <summary>
    /// Creates a Result with status Created
    /// </summary>
    /// <param name="value">Optional object yielded by the operation</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed created Result</returns>
    public static Result<T> OfCreated(T? value = default, string? message = null) => new()
    {
        Message = message ?? "Resource was successfully created",
        Value = value,
        Exception = null,
        Status = Status.Created
    };
    
    /// <summary>
    /// Creates a Result with status Exception
    /// </summary>
    /// <param name="exception">The exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed exception Result</returns>
    public new static Result<T> OfException(Exception exception, string? message = null) => new()
    {
        Message = message ?? "Operation resulted in an exception",
        Value = default,
        Exception = exception,
        Status = Status.Exception
    };
    
    /// <summary>
    /// Creates a Result with status NotFound
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed not found Result</returns>
    public new static Result<T> OfNotFound(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "The resource was not found",
        Value = default,
        Exception = exception,
        Status = Status.NotFound
    };
    
    /// <summary>
    /// Creates a Result with status ServerError
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed server error Result</returns>
    public new static Result<T> OfServerError(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to server error",
        Value = default,
        Exception = exception,
        Status = Status.ServerError
    };
    
    /// <summary>
    /// Creates a Result with status ClientError
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed client error Result</returns>
    public new static Result<T> OfClientError(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to client error",
        Value = default,
        Exception = exception,
        Status = Status.ClientError
    };
    
    /// <summary>
    /// Creates a Result with status Conflict
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed conflict Result</returns>
    public new static Result<T> OfConflict(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to a conflict",
        Value = default,
        Exception = exception,
        Status = Status.Conflict
    };
    
    /// <summary>
    /// Creates a Result with status AccessDenied
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed access denied Result</returns>
    public new static Result<T> OfAccessDenied(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to access denied",
        Value = default,
        Exception = exception,
        Status = Status.AccessDenied
    };
    
    /// <summary>
    /// Creates a Result with status ContentTooLarge
    /// </summary>
    /// <param name="exception">Optional exception thrown</param>
    /// <param name="message">Optional custom message</param>
    /// <returns>Typed content too large Result</returns>
    public new static Result<T> OfContentTooLarge(Exception? exception, string? message = null) => new()
    {
        Message = message ?? "Operation was unsuccessful due to content being too large",
        Value = default,
        Exception = exception,
        Status = Status.ContentTooLarge
    };
}