namespace Logic.Exceptions;

public class AlreadyExistsException(string message) : Exception
{
    public int Code { get; } = 409;
    public override string Message { get; } = message;
}