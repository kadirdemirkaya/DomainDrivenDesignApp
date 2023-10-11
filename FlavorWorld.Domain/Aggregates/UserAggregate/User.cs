using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate.Enums;
using FlavorWorld.Domain.BaseTypes;
using FlavorWorld.Domain.Enumerations;

namespace FlavorWorld.Domain.Aggregates.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public UserStatus UserStatus { get; private set; }

    private readonly List<Role> _roles = new();
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();


    public User()
    {

    }

    public User(UserId id, string username, string email, string password, DateTime createdDate, UserStatus userStatus) : base(id)
    {
        Username = username;
        Email = email;
        Password = password;
        CreatedDate = createdDate;
        UserStatus = userStatus;
    }


    public static User Create(string username, string email, string password, DateTime createdDate, UserStatus userStatus)
    {
        return new(UserId.CreateUnique(), username, email, password, createdDate, userStatus);
    }

    public static User Create(Guid id, string username, string email, string password, DateTime createdDate, UserStatus userStatus)
    {
        return new(UserId.Create(id), username, email, password, createdDate, userStatus);
    }

    public void AddUserDomainEvent(IDomainEvent @event)
    {
        AddDomainEvent(@event);
    }

}