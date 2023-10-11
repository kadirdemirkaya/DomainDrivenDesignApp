using System.Data;
using FlavorWorld.Infrastructure.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Polly;

namespace FlavorWorld.Infrastructure.Health;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly IDbConnection _dbConnection = new SqlConnection(DatabaseConfiguration.ConnectionString);
    private readonly ILogger<DatabaseHealthCheck> _logger;

    public DatabaseHealthCheck(ILogger<DatabaseHealthCheck> logger)
    {
        _logger = logger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var retryPolicy = Polly.Policy
            .Handle<SqlException>() // Handle SQL exceptions
            .Retry(3, (exception, retryCount) =>
            {
                _logger.LogWarning("Database Connection WARNING to Retry Count : " + retryCount);
                _logger.LogWarning("Database Connection WARNING : " + exception.Message);
            });

            retryPolicy.Execute(() =>
            {
                _dbConnection.Open();
                string sqlQuery = "SELECT 1";

                IDbCommand command = _dbConnection.CreateCommand();
                command.CommandText = sqlQuery;

                command.ExecuteNonQuery();
            });

            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            _logger.LogError("Hata: " + ex.Message);
            return HealthCheckResult.Unhealthy(ex.Message);
        }
        finally
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
    }
}