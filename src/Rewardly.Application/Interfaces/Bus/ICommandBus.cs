namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define o barramento responsável por encaminhar comandos aos respectivos manipuladores.
/// </summary>
public interface ICommandBus
{
    /// <summary>
    /// Envia um comando sem retorno para o manipulador apropriado.
    /// </summary>
    /// <param name="command">Comando a ser processado.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa assíncrona que representa a conclusão do processamento.</returns>
    Task SendAsync(ICommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Envia um comando com retorno tipado para o manipulador apropriado.
    /// </summary>
    /// <typeparam name="TResponse">Tipo da resposta esperada após o processamento do comando.</typeparam>
    /// <param name="command">Comando a ser processado.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resultado do processamento do comando.</returns>
    Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken);
}
