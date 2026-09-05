using Microsoft.Extensions.Logging;
using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Exceptions;

namespace Rewardly.Application.Services.v1;

public class RewardlyAccountService : IRewardlyAccountService
{
    private readonly IRepository<RewardlyAccount> _repository;
    private readonly IProjectionDispatcher _dispatcher;
    private readonly ILogger<RewardlyAccountService> _logger;

    public RewardlyAccountService(
        IRepository<RewardlyAccount> repository,
        ILogger<RewardlyAccountService> logger,
        IProjectionDispatcher dispatcher)
    {
        _repository = repository;
        _logger = logger;
        _dispatcher = dispatcher;
    }

    public async Task BlockAsync(BlockAccountRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processo de bloqueio de uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

        await LoadAndSaveAggregateAsync(request.AggregateId, aggregate => aggregate.Block(request.Reason), cancellationToken);

        _logger.LogInformation("Processo de bloqueio de uma conta foi concluído com sucesso. AggregateId: {AggregateId}", request.AggregateId);
    }

    public async Task CancelAsync(CancelAccountRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processo de cancelamento de uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

        await LoadAndSaveAggregateAsync(request.AggregateId, aggregate => aggregate.Cancel(request.Reason), cancellationToken);

        _logger.LogInformation("Processo de cancelamento de uma conta foi concluído com sucesso. AggregateId: {AggregateId}", request.AggregateId);
    }

    public async Task CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processo de criação da conta foi iniciado.");

        RewardlyAccount? aggregate = RewardlyAccount.Create(Guid.NewGuid(), request.UserId);

        await SaveAndProjectAsync(aggregate, cancellationToken);

        _logger.LogInformation("Processo de criação de conta foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
    }

    public async Task CreditAsync(CreditPointsRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processo de adição de pontos a uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

        await LoadAndSaveAggregateAsync(request.AggregateId, aggregate => aggregate.CreditPoint(request.Points, request.Reason), cancellationToken);

        _logger.LogInformation("Processo de adição de pontos a uma conta foi concluído com sucesso. AggregateId: {AggregateId}", request.AggregateId);
    }

    public async Task DebitAsync(DebitPointsRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processo de debitação de pontos a uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

        await LoadAndSaveAggregateAsync(request.AggregateId, aggregate => aggregate.DebitPoints(request.Points, request.Reason), cancellationToken);

        _logger.LogInformation("Processo de debitação de pontos a uma conta foi concluído com sucesso. AggregateId: {AggregateId}", request.AggregateId);
    }

    public async Task RedeemAsync(RedeemRewardRequest request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Processo de resgate de recompensa foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

        await LoadAndSaveAggregateAsync(request.AggregateId, aggregate => aggregate.RewardRedeem(request.RewardId, request.Points), cancellationToken);

        _logger.LogInformation("Processo de resgate de recompensa foi concluído com sucesso. AggregateId: {AggregateId}", request.AggregateId);
    }

    private async Task LoadAndSaveAggregateAsync(Guid aggregateId, Action<RewardlyAccount> aggregateAction, CancellationToken cancellationToken)
    {
        RewardlyAccount? aggregate = await _repository.FindOneAsync(aggregateId, cancellationToken);

        if (aggregate is null)
            throw new AggregateNotFoundException($"Nenhum aggregate foi encontrado com esse id {aggregateId}");

        aggregateAction(aggregate);

        await SaveAndProjectAsync(aggregate, cancellationToken);
    }

    private async Task SaveAndProjectAsync(RewardlyAccount aggregate, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IEvent> events = aggregate.GetUncommittedEvents()
            .ToList()
            .AsReadOnly();

        await _repository.SaveAsync(aggregate, cancellationToken);

        await _dispatcher.DispatchAsync(events, cancellationToken);
    }
}
