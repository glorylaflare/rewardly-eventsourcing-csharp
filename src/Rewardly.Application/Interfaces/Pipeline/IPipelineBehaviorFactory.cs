namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// Define a fábrica responsável por resolver os comportamentos de pipeline aplicáveis a uma requisição.
/// </summary>
public interface IPipelineBehaviorFactory
{
    /// <summary>
    /// Resolve os comportamentos registrados para o tipo concreto da requisição informada.
    /// </summary>
    /// <param name="request">Requisição para a qual os comportamentos devem ser obtidos.</param>
    /// <returns>Coleção de comportamentos de pipeline aplicáveis à requisição.</returns>
    IReadOnlyCollection<object> Create(IRequest request);
}
