using Simple.Result;

var nonGenericSuccessResult = Result.OfSuccess("Some non-generic message");
var nonGenericCustomSuccessResult = new Result
{
    Message = "Some custom non-generic message",
    Status = Status.Success
};

var resultValue = Guid.NewGuid();
var genericSuccessResult = Result<Guid>.OfSuccess(resultValue, "Some generic message");
var genericCustomSuccessResult = new Result<Guid>
{
    Message = "Some custom generic message",
    Status = Status.Success,
    Value = resultValue
};

var exception = new Exception("Some exception");
var nonGenericExceptionResult = Result.OfException(exception, "some non-generic message");
var nonGenericCustomExceptionResult = new Result
{
    Message = "Some custom non-generic message",
    Status = Status.Exception,
    Exception = exception
};

var genericExceptionResult = Result<Guid>.OfException(exception, "Some generic message");
var genericCustomExceptionResult = new Result<Guid>
{
    Message = "Some custom generic message",
    Status = Status.Success,
    Exception = exception
};