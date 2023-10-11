using Microsoft.Extensions.Configuration;

namespace FlavorWorld.Infrastructure.Configurations;

public static class jwtConfiguration
{
    public static string ValidAudience
    {

        get
        {
            IConfiguration configuration = BuildConfiguration();
            string ValidAudience = configuration.GetValue<string>("JwtSettings:Audience");
            return ValidAudience;
        }
    }

    public static string ExpiryMinutes
    {
        get
        {
            IConfiguration configuration = BuildConfiguration();
            string expiryMinutes = configuration.GetValue<string>("JwtSettings:ExpiryMinutes");
            return expiryMinutes;
        }
    }

    public static string ValidIssuer
    {
        get
        {
            IConfiguration configuration = BuildConfiguration();
            string ValidIssuer = configuration.GetValue<string>("JwtSettings:Issuer");
            return ValidIssuer;
        }
    }

    public static string Secret
    {
        get
        {
            IConfiguration configuration = BuildConfiguration();
            string Secret = configuration.GetValue<string>("JwtSettings:Secret");
            return Secret;
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