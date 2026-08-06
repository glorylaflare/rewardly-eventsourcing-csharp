namespace Rewardly.Domain.Exceptions;

public abstract class RewardlyException : Exception
{
    public string ErrorCode { get; }
    public RewardlyExceptionCategory Category { get; }

    protected RewardlyException(
        string message,
        string errorCode, 
        RewardlyExceptionCategory category) : base(message)
    {
        ErrorCode = errorCode;
        Category = category; 
    }

    protected RewardlyException(
        string message,
        string errorCode,
        RewardlyExceptionCategory category,
        Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
        Category = category;
    }
}
