using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Rewardly.Infra.Persistence.Connection;

public sealed class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("SqlServer") ?? throw new InvalidOperationException("SQL Server connection string was not configured.");
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}
