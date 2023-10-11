using FlavorWorld.Abstractions.Repository;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Abstractions.Repository.ProductReview;
using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;
using FlavorWorld.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Infrastructure.Registrations;

public static class RepositorySettingRegistration
{
    public static IServiceCollection RepositoryRegistration(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped(typeof(IReadReposiyory<,>), typeof(ReadRepository<,>));
        services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepositoy<,>));

        services.AddScoped(typeof(IReadReposiyory<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepositoy<>));

        services.AddScoped<IProductWriteRepository<Product, ProductId>, ProductWriteRepository>();
        services.AddScoped<IProductReadRepository<Product, ProductId>, ProductReadRepository>();

        services.AddScoped<IProductReviewWriteRepository<ProductReview, ProductReviewId>, ProductReviewWriteRepository>();
        services.AddScoped<IProductReviewReadRepository<ProductReview, ProductReviewId>, ProductReviewReadRepository>();

        services.AddScoped<IOrderWriteRepository<Order, OrderId>, OrderWriteRepository>();
        services.AddScoped<IOrderReadRepository<Order, OrderId>, OrderReadRepository>();

        services.AddScoped<ICustomerWriteRepository<Customer, CustomerId>, CustomerWriteRepository>();
        services.AddScoped<ICustomerReadRepository<Customer, CustomerId>, CustomerReadRepository>();

        services.AddScoped<IUserWriteRepository<User, UserId>, UserWriteRepository>();
        services.AddScoped<IUserReadRepository<User, UserId>, UserReadRepository>();

        services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
        services.AddScoped<IRoleReadRepository, RoleReadRepository>();

        return services;
    }
}