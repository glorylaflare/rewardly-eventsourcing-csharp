namespace Rewardly.Application.Interfaces.Pipeline;

/// <summary>
/// Define o executor responsável por orquestrar o pipeline de comportamentos e o manipulador final do comando.
/// </summary>
public interface IPipelineExecutor
{
    /// <summary>
    /// Executa um comando tipado através da cadeia de pipeline e retorna a resposta processada.
    /// </summary>
    /// <typeparam name="TResponse">Tipo da resposta esperada ao final da execução do comando.</typeparam>
    /// <param name="command">Comando a ser processado no pipeline de aplicação.</param>
    /// <param name="cancellationToken">Token para cancelamento cooperativo da operação assíncrona.</param>
    /// <returns>Resposta resultante do processamento completo do pipeline.</returns>
    Task<TResponse> ExecuteAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken);
}
