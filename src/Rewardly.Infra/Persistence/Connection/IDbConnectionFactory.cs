using System.Data;

namespace Rewardly.Infra.Persistence.Connection;

/// <summary>
/// Define a fábrica responsável por criar conexões com o banco de dados.
/// </summary>
public interface IDbConnectionFactory
{
    /// <summary>
    /// Cria uma nova conexão de banco de dados pronta para uso.
    /// </summary>
    /// <returns>Instância de conexão de banco de dados.</returns>
    IDbConnection CreateConnection();
}
