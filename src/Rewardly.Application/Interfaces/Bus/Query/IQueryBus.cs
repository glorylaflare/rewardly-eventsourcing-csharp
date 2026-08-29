namespace Rewardly.Application.Interfaces.Bus.Query;

/// <summary>
/// Define o barramento responsável por encaminhar consultas aos respectivos manipuladores.
/// </summary>
public interface IQueryBus
{
    /// <summary>
    /// Envia uma consulta com retorno tipado para o manipulador apropriado.
    /// </summary>
    /// <typeparam name="TResponse">Tipo da resposta esperada após o processamento da consulta.</typeparam>
    /// <param name="query">Consulta a ser processada.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resultado do processamento da consulta.</returns>
    Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken);
}
