using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Infrastructure.Health;

public class LogHealthCheck : IHealthCheck
{
    private readonly ILogger<LogHealthCheck> _logger;

    public LogHealthCheck(ILogger<LogHealthCheck> logger)
    {
        _logger = logger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealthy = IsSerilogHealthy();


        var healthCheckResult = isHealthy.success ?
                    HealthCheckResult.Healthy() :
                    HealthCheckResult.Unhealthy(isHealthy.errorMessage);

        return await Task.FromResult(healthCheckResult);
    }

    private (bool success, string errorMessage) IsSerilogHealthy()
    {
        try
        {
            _logger.LogInformation("Serilog health check.");
            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Serilog health check failed.");
            return (false, ex.Message);
        }
    }
}