namespace Rewardly.Application.Interfaces.Bus.Query;

/// <summary>
/// Define o contrato de manipulação para consultas de aplicação.
/// </summary>
/// <typeparam name="TQuery">Tipo de consulta processada pelo manipulador.</typeparam>
/// <typeparam name="TResponse">Tipo de resposta retornada após a execução da consulta.</typeparam>
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> 
    where TQuery : IQuery<TResponse> { }
