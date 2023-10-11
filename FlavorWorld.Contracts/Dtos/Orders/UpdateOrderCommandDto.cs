namespace FlavorWorld.Contracts.Models.Orders;

public class UpdateOrderCommandDto
{
    public Guid orderId { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid UserId { get; set; }
}