namespace Hnkla.Result;

/// <summary>
/// Represents the outcome status of an operation.
/// </summary>
public enum Status
{
    /// <summary>
    /// The operation completed successfully.
    /// </summary>
    Success = 0,

    /// <summary>
    /// The operation resulted in a file stream response.
    /// </summary>
    FileStreamResult,

    /// <summary>
    /// The operation completed without performing any action.
    /// </summary>
    NoOperation,

    /// <summary>
    /// The operation successfully created a new resource.
    /// </summary>
    Created,

    /// <summary>
    /// The operation failed due to a client-side error.
    /// </summary>
    ClientError,

    /// <summary>
    /// The operation failed due to a server-side error.
    /// </summary>
    ServerError,

    /// <summary>
    /// The requested resource was not found.
    /// </summary>
    NotFound,

    /// <summary>
    /// The operation could not be completed due to a conflict.
    /// </summary>
    Conflict,

    /// <summary>
    /// The operation was denied due to insufficient permissions.
    /// </summary>
    AccessDenied,

    /// <summary>
    /// The request content exceeded the allowed size.
    /// </summary>
    ContentTooLarge,

    /// <summary>
    /// The operation failed due to an unhandled exception.
    /// </summary>
    Exception
}