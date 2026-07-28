namespace Rewardly.Domain.Interfaces.v1;

/// <summary>
/// Representa um evento de domínio imutável, contendo dados de identificação,
/// rastreabilidade temporal, versionamento e metadados de contexto.
/// </summary>
public interface IEvent
{
    /// <summary>
    /// Obtém o identificador único do evento.
    /// </summary>
    Guid EventId { get; }
    /// <summary>
    /// Obtém o identificador da raiz de agregado associada ao evento.
    /// </summary>
    Guid AggregateId { get; }
    /// <summary>
    /// Obtém a data e hora de ocorrência do evento.
    /// </summary>
    DateTime OccurredAt { get; }
    /// <summary>
    /// Obtém a versão do agregado correspondente ao momento de geração do evento.
    /// </summary>
    int Version { get; }
    /// <summary>
    /// Obtém metadados adicionais do evento, como correlação, causalidade e origem.
    /// </summary>
    IReadOnlyDictionary<string, object> Metadata { get; }
}
