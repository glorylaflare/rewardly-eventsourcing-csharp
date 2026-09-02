using System.Data;

namespace Rewardly.Infra.Persistence.Connection;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
