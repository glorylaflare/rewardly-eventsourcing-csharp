namespace Rewardly.Application.Interfaces.Services.v1;

/// <summary>
/// Define operações de aplicação para gerenciamento do ciclo de vida e saldo de pontos de contas.
/// </summary>
public interface IRewardlyAccountService
{
    /// <summary>
    /// Bloqueia uma conta, impedindo novas operações até liberação.
    /// </summary>
    /// <param name="request">Dados necessários para bloquear a conta.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da operação de bloqueio.</returns>
    Task BlockAsync(BlockAccountRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Cancela uma conta e finaliza sua disponibilidade para uso.
    /// </summary>
    /// <param name="request">Dados necessários para cancelar a conta.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da operação de cancelamento.</returns>
    Task CancelAsync(CancelAccountRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Cria uma nova conta no sistema com os dados informados.
    /// </summary>
    /// <param name="request">Dados de entrada para criação da conta.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da operação de criação.</returns>
    Task CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Credita pontos na conta de acordo com os dados da requisição.
    /// </summary>
    /// <param name="request">Dados necessários para crédito de pontos na conta.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da operação de crédito.</returns>
    Task CreditAsync(CreditPointsRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Debita pontos da conta conforme os critérios informados.
    /// </summary>
    /// <param name="request">Dados necessários para débito de pontos na conta.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da operação de débito.</returns>
    Task DebitAsync(DebitPointsRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Resgata uma recompensa utilizando os pontos disponíveis da conta.
    /// </summary>
    /// <param name="request">Dados necessários para execução do resgate da recompensa.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa que representa a conclusão da operação de resgate.</returns>
    Task RedeemAsync(RedeemRewardRequest request, CancellationToken cancellationToken);
}