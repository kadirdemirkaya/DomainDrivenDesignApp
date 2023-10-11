using FlavorWorld.Contracts.Models.Orders;

namespace FlavorWorld.Contracts.Models.Products;

public class CreateOrderCommandDto
{
    public string Description { get; init; }
    public DateTime CreatedDate { get; init; }
    public Guid UserId { get; init; }

    public List<OrderItemCommandDto> OrderItemCommand { get; init; }
}