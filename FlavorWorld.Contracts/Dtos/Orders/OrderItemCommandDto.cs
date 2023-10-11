namespace FlavorWorld.Contracts.Models.Orders;

public class OrderItemCommandDto
{
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Quantity { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

}