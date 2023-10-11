using FlavorWorld.Infrastructure.Configurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using Nest;
using Elasticsearch.Net;

namespace FlavorWorld.Infrastructure.Health;

public class ElasticSearchCheck : IHealthCheck
{
    private readonly ILogger<ElasticSearchCheck> _logger;

    public ElasticSearchCheck(ILogger<ElasticSearchCheck> logger)
    {
        _logger = logger;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var settings = new Nest.ConnectionSettings(new Uri(ElasticSearchConfiguration.ElasticUrl));
        var client = new ElasticClient(settings);

        var healthRequest = new ClusterHealthRequest();

        try
        {
            var retryPolicy = Polly.Policy
            .Handle<ElasticsearchClientException>()
            .Retry(3, (exception, retryCount) =>
            {
                _logger.LogWarning("Elastic Search Connection WARNING to Retry Count : " + retryCount);
                _logger.LogWarning("Elastic Search Connection WARNING : " + exception.Message);
            });

            var healthResponse = await retryPolicy.Execute(async () => await client.Cluster.HealthAsync());
            //var healthResponse = await client.Cluster.HealthAsync(healthRequest);

            if (healthResponse.IsValid)
            {
                _logger.LogInformation($"Elastic Search Healt Check : {healthResponse.Status}");
                return HealthCheckResult.Healthy();
            }
            else
            {
                _logger.LogError($"Elastic Search Healt Check unsuccesfully: {healthResponse.ServerError?.Error}");
                return HealthCheckResult.Unhealthy();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Elastic Search Healt Error: {ex.Message}");
            return HealthCheckResult.Healthy();
        }
    }
}