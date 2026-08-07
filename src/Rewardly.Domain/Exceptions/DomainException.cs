namespace Rewardly.Domain.Exceptions;

public class DomainException : RewardlyException
{
    public DomainException(string message, string errorCode) : base(
        message, 
        errorCode, 
        RewardlyExceptionCategory.Domain) { }
}
