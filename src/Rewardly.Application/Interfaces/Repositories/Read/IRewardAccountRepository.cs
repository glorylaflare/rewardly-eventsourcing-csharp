namespace Rewardly.Application.Interfaces.Repositories.Read;

/// <summary>
/// Define operações de persistência para a projeção de contas no modelo de leitura.
/// </summary>
public interface IRewardAccountRepository
{
    /// <summary>
    /// Adiciona uma conta projetada ao repositório de leitura.
    /// </summary>
    /// <param name="account">Conta projetada a ser persistida.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da persistência da conta.</returns>
    Task AddAsync(RewardAccount account, CancellationToken cancellationToken);

    /// <summary>
    /// Recupera uma conta projetada pelo seu identificador.
    /// </summary>
    /// <param name="userId">Identificador da conta a ser localizada.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Conta projetada encontrada ou nulo quando inexistente.</returns>
    Task<RewardAccount?> FindAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Atualiza os dados de uma conta já existente no modelo de leitura.
    /// </summary>
    /// <param name="account">Conta projetada com os dados atualizados.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da atualização da conta.</returns>
    Task UpdateAsync(RewardAccount account, CancellationToken cancellationToken);
}
