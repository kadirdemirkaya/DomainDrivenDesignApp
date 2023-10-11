using BuberDinner.Infrastructure.Authentication;
using FlavorWorld.Application.Common.Interfaces;
using FlavorWorld.Domain.Models;
using FlavorWorld.Domain.Services;
using FlavorWorld.Infrastructure.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Infrastructure.Registrations;

public static class ServiceSettingRegistration
{
    public static IServiceCollection ServiceRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductReviewService, ProductReviewService>();
        services.AddScoped(typeof(IRedisService<>), typeof(RedisService<>));
        services.AddScoped(typeof(IElasticsearchService<>), typeof(ElasticSearchService<>));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IEmailQueueService, EmailQueueService>();
        services.AddSingleton<Queue<EmailSetting>>();


        return services;
    }
}