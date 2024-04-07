namespace Logic.Exceptions;

public class NotFoundException(string message) : Exception
{
    public int Code { get; } = 404;
    public override string Message { get; } = message;
}