namespace Rewardly.Application.Bus;

/// <summary>
/// Define a fábrica responsável por resolver o invocador adequado para cada comando.
/// </summary>
public interface ICommandInvokerFactory
{
    /// <summary>
    /// Cria o invocador que executará o comando informado.
    /// </summary>
    /// <param name="command">Comando utilizado como referência para seleção do invocador correspondente.</param>
    /// <returns>Instância de invocador preparada para processar o comando.</returns>
    ICommandInvoker Create(ICommandBase command);
}
