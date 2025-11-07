using Simple.Result;

var successResult = CreateGuid();
Console.WriteLine($"Result: Status='{successResult.Status}', " +
                  $"Message='{successResult.Message}', " +
                  $"Type='{successResult.Type}', " +
                  $"Value='{successResult.Value}', " +
                  $"Exception='{successResult.Exception}'");

// Result: Status='Created', Message='Resource was successfully created', Type='System.Guid', Value='ebbcfe53-bbe8-4fcd-b5fa-c558bef084e8', Exception=''

var exceptionResult = CreateGuidAndThrow();
Console.WriteLine($"Result: Status='{exceptionResult.Status}', " +
                  $"Message='{exceptionResult.Message}', " +
                  $"Type='{exceptionResult.Type}', " +
                  $"Value='{exceptionResult.Value}', " +
                  $"Exception='{exceptionResult.Exception}'");

// Result: Status='Exception', Message='Operation resulted in an exception', Type='System.Guid', Value='00000000-0000-0000-0000-000000000000', Exception='System.Exception: An example exception
// at Program.<<Main>$>g__CreateGuidAndThrow|0_1() in <path>\Simple.Result\Simple.Result.Example\Program.cs:line 48'

var customResult = new Result<Guid>
{
    Status = Status.NotFound,
    Message = "A custom not found result"
};

Console.WriteLine($"Result: Status='{customResult.Status}', " +
                  $"Message='{customResult.Message}', " +
                  $"Type='{customResult.Type}', " +
                  $"Value='{customResult.Value}', " +
                  $"Exception='{customResult.Exception}'");

// Result: Status='NotFound', Message='A custom not found result', Type='System.Guid', Value='00000000-0000-0000-0000-000000000000', Exception=''
return;


static Result<Guid> CreateGuid()
{
    var guid = Guid.NewGuid();
    return Result<Guid>.OfCreated(guid);
}

static Result<Guid> CreateGuidAndThrow()
{
    try
    {
        // simulate an exception
        throw new Exception("An example exception");
    }
    catch (Exception e)
    {
        return Result<Guid>.OfException(e);
    }
}