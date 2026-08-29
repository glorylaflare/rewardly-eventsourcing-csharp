namespace Rewardly.Application.Interfaces.Bus;

/// <summary>
/// Representa uma requisição de aplicação que produz uma resposta tipada.
/// </summary>
/// <typeparam name="TResponse">Tipo retornado após o processamento da requisição.</typeparam>
public interface IRequest<out TResponse> : IRequest { }

/// <summary>
/// Representa uma requisição de aplicação sem expor o tipo de resposta.
/// </summary>
public interface IRequest { }