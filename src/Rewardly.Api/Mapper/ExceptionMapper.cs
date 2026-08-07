using Rewardly.Domain.Exceptions;
using System.Net;

namespace Rewardly.Api.Mapper;

public sealed class ExceptionMapper : IExceptionMapper
{
    public ExceptionMapping Map(Exception exception)
    {
        if (exception is RewardlyException rewardlyException)
            return MapRewardlyException(rewardlyException);

        return MapUnknownException();
    }

    private static ExceptionMapping MapUnknownException()
        => new ExceptionMapping(HttpStatusCode.InternalServerError, "INTERNAL_SERVER_ERROR", "An unexpected error occurred.");

    private static ExceptionMapping MapRewardlyException(RewardlyException exception)
    {
        HttpStatusCode statusCode = exception switch
        {
            InvalidEventTypeException => HttpStatusCode.InternalServerError,
            ConcurrencyException => HttpStatusCode.Conflict,
            AggregateNotFoundException => HttpStatusCode.NotFound,
            DomainException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        return new ExceptionMapping(statusCode, exception.ErrorCode, exception.Message);
    }
}
