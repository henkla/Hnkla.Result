namespace Simple.Result.Tests;

public class NonGenericResultTests
{
    [Theory]
    [InlineData(Status.Success, true)]
    [InlineData(Status.Created, true)]
    [InlineData(Status.NoOperation, true)]
    [InlineData(Status.FileStreamResult, true)]
    [InlineData(Status.ClientError, false)]
    [InlineData(Status.ServerError, false)]
    [InlineData(Status.Exception, false)]
    [InlineData(Status.Conflict, false)]
    [InlineData(Status.AccessDenied, false)]
    [InlineData(Status.ContentTooLarge, false)]
    [InlineData(Status.NotFound, false)]
    public void IsSuccess_ShouldReturnExpectedValue(Status status, bool expected)
    {
        var result = new Result { Status = status };
        Assert.Equal(expected, result.IsSuccess);
    }

    [Fact]
    public void OfSuccess_ShouldReturnExpectedResult()
    {
        var result = Result.OfSuccess("ok");
        Assert.Equal(Status.Success, result.Status);
        Assert.Equal("ok", result.Message);
        Assert.Null(result.Exception);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void OfNoOperation_ShouldReturnExpectedResult()
    {
        var result = Result.OfNoOperation();
        Assert.Equal(Status.NoOperation, result.Status);
        Assert.Null(result.Exception);
        Assert.Equal("No operation was performed", result.Message);
    }

    [Fact]
    public void OfCreated_ShouldReturnExpectedResult()
    {
        var result = Result.OfCreated();
        Assert.Equal(Status.Created, result.Status);
        Assert.Null(result.Exception);
        Assert.Equal("Resource was successfully created", result.Message);
    }

    [Fact]
    public void OfException_ShouldReturnExpectedResult()
    {
        var ex = new InvalidOperationException("fail");
        var result = Result.OfException(ex, "custom");
        Assert.Equal(Status.Exception, result.Status);
        Assert.Equal("custom", result.Message);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfNotFound_ShouldReturnExpectedResult()
    {
        var ex = new Exception("not found");
        var result = Result.OfNotFound(ex);
        Assert.Equal(Status.NotFound, result.Status);
        Assert.Equal("The resource was not found", result.Message);
        Assert.Equal(ex, result.Exception);
    }

    [Fact]
    public void OfServerError_ShouldReturnExpectedResult()
    {
        var result = Result.OfServerError(null, "server failed");
        Assert.Equal(Status.ServerError, result.Status);
        Assert.Equal("server failed", result.Message);
    }

    [Fact]
    public void OfClientError_ShouldReturnExpectedResult()
    {
        var result = Result.OfClientError(null);
        Assert.Equal(Status.ClientError, result.Status);
        Assert.Equal("Operation was unsuccessful due to client error", result.Message);
    }

    [Fact]
    public void OfConflict_ShouldReturnExpectedResult()
    {
        var result = Result.OfConflict(null);
        Assert.Equal(Status.Conflict, result.Status);
        Assert.Equal("Operation was unsuccessful due to a conflict", result.Message);
    }

    [Fact]
    public void OfAccessDenied_ShouldReturnExpectedResult()
    {
        var result = Result.OfAccessDenied(null);
        Assert.Equal(Status.AccessDenied, result.Status);
        Assert.Equal("Operation was unsuccessful due to access denied", result.Message);
    }

    [Fact]
    public void OfContentTooLarge_ShouldReturnExpectedResult()
    {
        var result = Result.OfContentTooLarge(null);
        Assert.Equal(Status.ContentTooLarge, result.Status);
        Assert.Equal("Operation was unsuccessful due to content being too large", result.Message);
    }
}