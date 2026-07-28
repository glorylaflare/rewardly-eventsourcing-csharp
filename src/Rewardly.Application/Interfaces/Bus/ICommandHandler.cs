namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define o contrato para manipulação de comandos com retorno tipado.
/// </summary>
/// <typeparam name="TCommand">Tipo do comando processado pelo manipulador.</typeparam>
/// <typeparam name="TResponse">Tipo da resposta gerada pelo processamento do comando.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// Processa o comando informado e retorna a resposta correspondente.
    /// </summary>
    /// <param name="command">Comando a ser processado.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resposta resultante do processamento do comando.</returns>
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);
}