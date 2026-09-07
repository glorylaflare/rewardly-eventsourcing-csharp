using Rewardly.Application.Responses;

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

    /// <summary>
    /// Recupera transações projetadas de uma conta com suporte a paginação.
    /// </summary>
    /// <param name="accountId">Identificador da conta cujas transações serão consultadas.</param>
    /// <param name="page">Número da página a ser retornada.</param>
    /// <param name="pageSize">Quantidade máxima de itens por página.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resultado paginado contendo as transações da conta no modelo de leitura.</returns>
    Task<PagedResult<RewardTransaction>> FindAsync(Guid accountId, int page, int pageSize, CancellationToken cancellationToken);
}
