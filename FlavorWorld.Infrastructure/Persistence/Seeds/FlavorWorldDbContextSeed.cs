using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.CustomerAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate.Enums;
using FlavorWorld.Infrastructure.Persistence.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace FlavorWorld.Infrastructure.Persistence.Seeds;

public class FlavorWorldDbContextSeed
{
    public async Task SeedAsync(FlavorWorldDbContext context, ILogger<FlavorWorldDbContext> logger)
    {
        var policy = CreatePolicy(logger, nameof(FlavorWorldDbContext));

        await policy.ExecuteAsync(async () =>
        {
            var useCustomizationData = false;

            var contentRootPath = "Seeding/Setup";

            using (context)
            {
                context.Database.Migrate();

                if (!context.Product.Any())
                {
                    await context.Product.AddRangeAsync(GetSeedProductDatas());
                }
                if (!context.Users.Any())
                {
                    await context.Users.AddRangeAsync(GetSeedUserDatas());
                }

                if (!context.Customer.Any())
                {
                    await context.Customer.AddRangeAsync(GetSeedCustomerDatas());
                }

                int dbResult = await context.SaveChangesAsync();
                logger.LogInformation("SEED WORK SAVE CHANGES RESULT -=> " + dbResult);
            }
        });
    }

    private List<Customer> GetSeedCustomerDatas()
    {
        List<Customer> customers = new();
        customers.Add(Customer.Create("mehmet", "kaskas", "054456575", GenderStatus.Male, DateTime.Now, Address.Create("asd", "asd", "asd", "asd"),
                UserId.Create(Guid.Parse("E244A9CF-C6CB-413E-9D22-D8B588FE433C"))));

        return customers;
    }

    private List<Domain.Aggregates.UserAggregate.User> GetSeedUserDatas()
    {
        List<Domain.Aggregates.UserAggregate.User> users = new();
        users.Add(Domain.Aggregates.UserAggregate.User.Create(Guid.Parse("E244A9CF-C6CB-413E-9D22-D8B588FE433C"), "mehmet", "maskas", "mehmet123", DateTime.Now, UserStatus.Avaible));
        users.Add(Domain.Aggregates.UserAggregate.User.Create(Guid.Parse("ED1A140A-F24E-4E03-8ACF-4E7B839E02D0"), "harun", "badem", "harun123", DateTime.Now, UserStatus.Online));
        users.Add(Domain.Aggregates.UserAggregate.User.Create(Guid.Parse("B2B438A1-231C-4320-908A-668C242716ED"), "omer", "arabaci", "omer123", DateTime.Now, UserStatus.Bussy));
        users.Add(Domain.Aggregates.UserAggregate.User.Create(Guid.Parse("C86E6306-A2E4-484D-A49B-797E0B224720"), "han", "notknow", "han123", DateTime.Now, UserStatus.Offline));
        return users;
    }

    private List<Product> GetSeedProductDatas()
    {
        List<Product> products = new();
        products.Add(Product.Create("watermelon", 15, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("plum", 43.5m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("apricot", 44.9m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("pear", 12.90m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("computer", 12.32m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("chair", 34.7m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("armchair", 12.5m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("table", 45.0m, DateTime.Now, ProductStatus.InStock));
        products.Add(Product.Create("cup", 12.4m, DateTime.Now, ProductStatus.InStock));

        return products;
    }


    private AsyncRetryPolicy CreatePolicy(ILogger<FlavorWorldDbContext> logger, string prefix, int retries = 3)
    {
        return Policy.Handle<SqlException>().
            WaitAndRetryAsync(
                retryCount: retries,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                }
            );
    }
}