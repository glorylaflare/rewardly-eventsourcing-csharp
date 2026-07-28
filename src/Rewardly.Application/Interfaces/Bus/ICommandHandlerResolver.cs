using Rewardly.Application.Bus;

namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Define a resolução de contexto de execução para comandos e respectivos manipuladores.
/// </summary>
public interface ICommandHandlerResolver
{
    /// <summary>
    /// Resolve o contexto de execução de um comando sem retorno explícito.
    /// </summary>
    /// <param name="command">Comando para o qual o contexto deverá ser resolvido.</param>
    /// <returns>Contexto com informações necessárias para a execução do comando.</returns>
    CommandExecutionContext Resolve(ICommand command);

    /// <summary>
    /// Resolve o contexto de execução de um comando com retorno tipado.
    /// </summary>
    /// <typeparam name="TResponse">Tipo de resposta associada ao comando.</typeparam>
    /// <param name="command">Comando para o qual o contexto deverá ser resolvido.</param>
    /// <returns>Contexto com informações necessárias para a execução do comando.</returns>
    CommandExecutionContext Resolve<TResponse>(ICommand<TResponse> command);
}
