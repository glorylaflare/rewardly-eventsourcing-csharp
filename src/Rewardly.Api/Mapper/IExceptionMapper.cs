namespace Rewardly.Api.Mapper;

public interface IExceptionMapper
{
    ExceptionMapping Map(Exception exception);
}
