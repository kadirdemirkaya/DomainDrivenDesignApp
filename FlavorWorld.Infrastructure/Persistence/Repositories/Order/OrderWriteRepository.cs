using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Repositories.Common;

namespace FlavorWorld.Infrastructure.Repositories;

public class OrderWriteRepository : WriteRepositoy<Order, OrderId>, IOrderWriteRepository<Order, OrderId>
{
    public OrderWriteRepository(FlavorWorldDbContext context) : base(context)
    {
    }
}