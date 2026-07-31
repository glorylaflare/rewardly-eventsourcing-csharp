namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// Define a fábrica responsável por resolver os comportamentos de pipeline aplicáveis a um comando.
/// </summary>
public interface IPipelineBehaviorFactory
{
    /// <summary>
    /// Cria a coleção de comportamentos de pipeline registrados para o tipo do comando informado.
    /// </summary>
    /// <param name="command">Comando utilizado como referência para descoberta dos comportamentos do pipeline.</param>
    /// <returns>Coleção somente leitura com os comportamentos que serão executados na cadeia do pipeline.</returns>
    IReadOnlyCollection<object> Create(ICommandBase command);
}
