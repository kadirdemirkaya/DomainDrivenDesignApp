using Microsoft.Extensions.Configuration;

namespace FlavorWorld.Infrastructure.Configurations;

public static class DatabaseConfiguration
{
    public static string ConnectionString
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string ValidAudience = configuration.GetValue<string>("DbConnection");
            return ValidAudience;
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