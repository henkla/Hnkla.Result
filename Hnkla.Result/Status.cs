namespace Hnkla.Result;

public enum Status
{
    Success = 0,
    FileStreamResult,
    NoOperation,
    Created,
    ClientError,
    ServerError,
    NotFound,
    Conflict,
    AccessDenied,
    ContentTooLarge,
    Exception
}