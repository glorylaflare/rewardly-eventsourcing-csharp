namespace Rewardly.Application.Interfaces.Bus.Query;

/// <summary>
/// Representa uma consulta de aplicação que retorna dados sem alterar estado.
/// </summary>
/// <typeparam name="TResponse">Tipo de resposta retornada pela consulta.</typeparam>
public interface IQuery<out TResponse> : IRequest<TResponse> { }
