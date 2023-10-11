using FlavorWorld.Domain.Aggregates.UserAggregate.Enums;

namespace FlavorWorld.Contracts.Dtos.Authentication;

public class RegisterCommandDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDate { get; set; }
    public UserStatus UserStatus { get; set; }
    public Guid CustomerId { get; set; }
    public List<RoleCommandDto> Roles { get; set; }
}