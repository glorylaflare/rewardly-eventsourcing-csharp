using Rewardly.Application.Commands.v1.DebitPoints;
using Rewardly.Application.Requests;

namespace Rewardly.Application.Mappers;

internal static class DebitPointsMapper
{
    public static DebitPointsRequest ToRequest(DebitPointsCommand source)
        => new DebitPointsRequest(source.AggregateId, source.Points, source.Reason);
}
