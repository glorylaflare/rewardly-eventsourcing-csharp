using Rewardly.Application.Interfaces.Bus.Query;

namespace Rewardly.Application.Bus;

public sealed class QueryBus : IQueryBus
{
    private readonly IPipelineExecutor _pipeline;

    public QueryBus(IPipelineExecutor pipeline)
    {
        _pipeline = pipeline;
    }

    public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken)
    {
        return await _pipeline.ExecuteAsync(query, cancellationToken);
    }
}
