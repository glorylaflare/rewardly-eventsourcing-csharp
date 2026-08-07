namespace Rewardly.Domain.Exceptions;

public class InvalidEventTypeException : RewardlyException
{
    public InvalidEventTypeException(string message) : base(
        message, 
        ValidationErrorCodes.InvalidEvent, 
        RewardlyExceptionCategory.Infrastructure) { }
}
