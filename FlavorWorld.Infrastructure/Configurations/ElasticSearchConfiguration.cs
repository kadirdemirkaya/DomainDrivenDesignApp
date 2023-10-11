using Microsoft.Extensions.Configuration;

namespace FlavorWorld.Infrastructure.Configurations;

public static class ElasticSearchConfiguration
{
    public static string ApplicationName
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string constring = configuration.GetValue<string>("ElasticSearch:ApplicationName");
            return constring;
        }
    }
    public static string DefaultIndex
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string constring = configuration.GetValue<string>("ElasticSearch:DefaultIndex");
            return constring;
        }
    }
    public static string ElasticUrl
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string constring = configuration.GetValue<string>("ElasticSearch:ElasticUrl");
            return constring;
        }
    }
    public static string Password
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string constring = configuration.GetValue<string>("ElasticSearch:Password");
            return constring;
        }
    }
    public static string UserName
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string constring = configuration.GetValue<string>("ElasticSearch:UserName");
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