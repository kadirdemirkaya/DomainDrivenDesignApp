using Microsoft.Extensions.Configuration;

namespace FlavorWorld.Infrastructure.Configurations;

public static class RedisConfiguration
{
    public static string ConnectionString
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string constring = configuration.GetValue<string>("RedisConfig:ConnectionString");
            return constring;
        }
    }
    private static IConfiguration BuildConfiguration(string jsonFileName = "appsettings.json")
    {
        IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile(jsonFileName, optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
        return configuration;
    }
}