namespace Rewardly.Domain.Exceptions;

public class InvalidEventTypeException : Exception
{
    public InvalidEventTypeException() { }
    public InvalidEventTypeException(string? message) : base(message) { }
}
