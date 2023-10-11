using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Services;
using FlavorWorld.Infrastructure.Persistence.Data;

namespace FlavorWorld.Infrastructure.Persistence.Services;

public class OrderService : IOrderService
{
    private readonly FlavorWorldDbContext _context;

    public OrderService(FlavorWorldDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateOrderWithOrderItemAsync(Order order)
    {
        var response = await _context.Set<Order>().AddAsync(order);
        int dbResult = await _context.SaveChangesAsync();
        if (dbResult < 0)
            return false;
        return true;
    }
}