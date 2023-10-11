using ElasticSearchCommon.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Infrastructure.Registrations;

public static class ElasticsearchSettingRegistration
{
    public static IServiceCollection ElasticsearchRegistration(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddElasticSearch(conf =>
        {
            conf.ApplicationName = configuration["ElasticSearch:ApplicationName"];
            conf.DefaultIndex = configuration["ElasticSearch:DefaultIndex"];
            conf.ElasticUrl = configuration["ElasticSearch:ElasticUrl"]!;
            conf.Password = configuration["ElasticSearch:Password"];
            conf.UserName = configuration["ElasticSearch:UserName"];
        });

        return services;
    }



    public static WebApplication ElasticsearchRegistrationApp(this WebApplication app, Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
        app.AddElasticSearchApp(configuration);
        return app;
    }

    public static WebApplicationBuilder ElasticsearchRegistrationBuilder(this WebApplicationBuilder builder)
    {
        builder.AddElasticSearchBuilder(conf =>
        {
            conf.ApplicationName = builder.Configuration["ElasticSearch:ApplicationName"];
            conf.DefaultIndex = builder.Configuration["ElasticSearch:DefaultIndex"];
            conf.ElasticUrl = builder.Configuration["ElasticSearch:ElasticUrl"]!;
            conf.Password = builder.Configuration["ElasticSearch:Password"];
            conf.UserName = builder.Configuration["ElasticSearch:UserName"];
        }, builder.Configuration);
        return builder;
    }
}