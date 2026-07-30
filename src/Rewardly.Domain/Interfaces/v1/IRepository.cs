namespace Rewardly.Domain.Interfaces.v1;

/// <summary>
/// Define operações de acesso e persistência para agregados de domínio.
/// </summary>
/// <typeparam name="TAggregate">Tipo da raiz de agregado manipulada pelo repositório.</typeparam>
public interface IRepository<TAggregate> where TAggregate : IAggregateRoot
{
    /// <summary>
    /// Localiza um agregado pelo identificador informado.
    /// </summary>
    /// <param name="aggregateId">Identificador único do agregado.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Instância do agregado correspondente ao identificador fornecido.</returns>
    Task<TAggregate> FindOneAsync(Guid aggregateId, CancellationToken cancellationToken);
    /// <summary>
    /// Persiste o estado atual do agregado e seus eventos pendentes.
    /// </summary>
    /// <param name="aggregate">Agregado a ser persistido.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Tarefa assíncrona que representa a conclusão da persistência.</returns>
    Task SaveAsync(TAggregate aggregate, CancellationToken cancellationToken);
}
