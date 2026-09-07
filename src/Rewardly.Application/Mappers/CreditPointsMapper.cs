using Rewardly.Application.Commands.v1.CreditPoints;

namespace Rewardly.Application.Mappers;

internal static class CreditPointsMapper
{
    public static CreditPointsRequest ToRequest(CreditPointsCommand source)
        => new CreditPointsRequest(source.AggregateId, source.Points, source.Reason);
}
