namespace Simple.Result.Tests;

public class ResultGenericTests
{
    [Fact]
    public void OfSuccess_ShouldReturnExpectedTypedResult()
    {
        var result = Result<string>.OfSuccess("hello", "done");
        Assert.Equal(Status.Success, result.Status);
        Assert.Equal("done", result.Message);
        Assert.Equal("hello", result.Value);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void Type_ShouldReturnGenericType()
    {
        var result = Result<int>.OfSuccess(42);
        Assert.Equal(typeof(int), result.Type);
    }

    [Fact]
    public void OfNoOperation_ShouldReturnExpectedTypedResult()
    {
        var result = Result<string>.OfNoOperation();
        Assert.Equal(Status.NoOperation, result.Status);
        Assert.Null(result.Value);
        Assert.Null(result.Exception);
        Assert.Equal("No operation was performed", result.Message);
    }

    [Fact]
    public void OfCreated_ShouldReturnExpectedTypedResult()
    {
        var result = Result<int>.OfCreated(10);
        Assert.Equal(Status.Created, result.Status);
        Assert.Equal(10, result.Value);
        Assert.Null(result.Exception);
    }

    [Fact]
    public void OfException_ShouldReturnExpectedTypedResult()
    {
        var ex = new Exception("fail");
        var result = Result<object>.OfException(ex);
        Assert.Equal(Status.Exception, result.Status);
        Assert.Null(result.Value);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfNotFound_ShouldReturnExpectedTypedResult()
    {
        var ex = new Exception("missing");
        var result = Result<string>.OfNotFound(ex);
        Assert.Equal(Status.NotFound, result.Status);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfServerError_ShouldReturnExpectedTypedResult()
    {
        var ex = new Exception("server down");
        var result = Result<string>.OfServerError(ex);
        Assert.Equal(Status.ServerError, result.Status);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfClientError_ShouldReturnExpectedTypedResult()
    {
        var ex = new Exception("bad input");
        var result = Result<string>.OfClientError(ex);
        Assert.Equal(Status.ClientError, result.Status);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfConflict_ShouldReturnExpectedTypedResult()
    {
        var ex = new Exception("conflict");
        var result = Result<string>.OfConflict(ex);
        Assert.Equal(Status.Conflict, result.Status);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfAccessDenied_ShouldReturnExpectedTypedResult()
    {
        var result = Result<string>.OfAccessDenied(null);
        Assert.Equal(Status.AccessDenied, result.Status);
        Assert.Equal("Operation was unsuccessful due to access denied", result.Message);
    }

    [Fact]
    public void OfContentTooLarge_ShouldReturnExpectedTypedResult()
    {
        var result = Result<string>.OfContentTooLarge(null);
        Assert.Equal(Status.ContentTooLarge, result.Status);
        Assert.Equal("Operation was unsuccessful due to content being too large", result.Message);
    }
}