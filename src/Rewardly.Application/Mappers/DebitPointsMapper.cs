using Rewardly.Application.Commands.v1.DebitPoints;

namespace Rewardly.Application.Mappers;

internal static class DebitPointsMapper
{
    public static DebitPointsRequest ToRequest(DebitPointsCommand source)
        => new DebitPointsRequest(source.AggregateId, source.Points, source.Reason);
}
