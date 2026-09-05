namespace Rewardly.Application.Interfaces.Repositories.Read;

/// <summary>
/// Define operações de persistência para a projeção de transações no modelo de leitura.
/// </summary>
public interface IRewardTransactionRepository
{
    /// <summary>
    /// Adiciona uma transação projetada ao repositório de leitura.
    /// </summary>
    /// <param name="transaction">Transação projetada a ser persistida.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da persistência da transação.</returns>
    Task AddAsync(RewardTransaction transaction, CancellationToken cancellationToken);
}
