namespace Rewardly.Application.Pipeline;

/// <summary>
/// Representa o próximo manipulador na cadeia de execução do pipeline.
/// </summary>
/// <typeparam name="TResponse">Tipo da resposta produzida pelo manipulador.</typeparam>
/// <returns>Tarefa assíncrona que retorna a resposta do próximo passo do pipeline.</returns>
public delegate Task<TResponse> RequestHandlerDelegate<TResponse>();
