using Rewardly.Application.Commands.v1.CreditPoints;
using Rewardly.Application.Requests;

namespace Rewardly.Application.Mappers;

internal static class CreditPointsMapper
{
    public static CreditPointsRequest ToRequest(CreditPointsCommand source)
        => new CreditPointsRequest(source.AggregateId, source.Points, source.Reason);
}
