using Microsoft.Extensions.Logging;
using Rewardly.Domain.Aggregates;
using Rewardly.Domain.Exceptions;
using Rewardly.Domain.Interfaces.v1;

namespace Rewardly.Application.Services.v1;

public class RewardlyAccountService : IRewardlyAccountService
{
    private readonly IRepository<RewardlyAccount> _repository;
    private readonly ILogger<RewardlyAccountService> _logger;

    public RewardlyAccountService(
        IRepository<RewardlyAccount> repository, 
        ILogger<RewardlyAccountService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task BlockAsync(BlockAccountRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processo de bloqueio de uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

            RewardlyAccount? aggregate = await _repository.FindOneAsync(request.AggregateId, cancellationToken);
            if (aggregate is null)
                throw new AggregateNotFoundException($"Nenhum aggregate foi encontrado com esse id {request.AggregateId}");

            aggregate.Block(request.Reason);

            await _repository.SaveAsync(aggregate, cancellationToken);

            _logger.LogInformation("Processo de bloqueio de uma conta foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Um erro aconteceu durante o processo. Exception: {Message}", ex.Message);
            throw;
        }
    }

    public async Task CancelAsync(CancelAccountRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processo de cancelamento de uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

            RewardlyAccount? aggregate = await _repository.FindOneAsync(request.AggregateId, cancellationToken);
            if (aggregate is null)
                throw new AggregateNotFoundException($"Nenhum aggregate foi encontrado com esse id {request.AggregateId}");

            aggregate.Cancel(request.Reason);

            await _repository.SaveAsync(aggregate, cancellationToken);

            _logger.LogInformation("Processo de cancelamento de uma conta foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,"Um erro aconteceu durante o processo. Exception: {Message}", ex.Message);
            throw;
        }
    }

    public async Task CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processo de criação da conta foi iniciado.");

            RewardlyAccount? aggregate = RewardlyAccount.Create(Guid.NewGuid(), request.UserId);
            await _repository.SaveAsync(aggregate, cancellationToken);

            _logger.LogInformation("Processo de criação de conta foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Um erro aconteceu durante o processo. Exception: {Message}", ex.Message);
            throw;
        }
    }

    public async Task CreditAsync(CreditPointsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processo de adição de pontos a uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

            RewardlyAccount? aggregate = await _repository.FindOneAsync(request.AggregateId, cancellationToken);
            if (aggregate is null)
                throw new AggregateNotFoundException($"Nenhum aggregate foi encontrado com esse id {request.AggregateId}");

            aggregate.CreditPoint(request.Points, request.Reason);

            await _repository.SaveAsync(aggregate, cancellationToken);

            _logger.LogInformation("Processo de adição de pontos a uma conta foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Um erro aconteceu durante o processo. Exception: {Message}", ex.Message);
            throw;
        }
    }

    public async Task DebitAsync(DebitPointsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processo de debitação de pontos a uma conta foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

            RewardlyAccount? aggregate = await _repository.FindOneAsync(request.AggregateId, cancellationToken);
            if (aggregate is null)
                throw new AggregateNotFoundException($"Nenhum aggregate foi encontrado com esse id {request.AggregateId}");

            aggregate.DebitPoints(request.Points, request.Reason);

            await _repository.SaveAsync(aggregate, cancellationToken);

            _logger.LogInformation("Processo de debitação de pontos a uma conta foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Um erro aconteceu durante o processo. Exception: {Message}", ex.Message);
            throw;
        }
    }

    public async Task RedeemAsync(RedeemRewardRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogDebug("Processo de resgate de recompensa foi iniciado. Aggregate: {Aggregate}", request.AggregateId);

            RewardlyAccount? aggregate = await _repository.FindOneAsync(request.AggregateId, cancellationToken);
            if (aggregate is null)
                throw new AggregateNotFoundException($"Nenhum aggregate foi encontrado com esse id {request.AggregateId}");

            aggregate.RewardRedeem(request.RewardId, request.Points);

            await _repository.SaveAsync(aggregate, cancellationToken);

            _logger.LogInformation("Processo de resgate de recompensa foi concluído com sucesso. AggregateId: {AggregateId}", aggregate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Um erro aconteceu durante o processo. Exception: {Message}", ex.Message);
            throw;
        }
    }
}
