using FlavorWorld.Domain.Aggregates.CustomerAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Aggregates.CustomerAggregate;

public class Customer : AggregateRoot<CustomerId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public GenderStatus Gender { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public Address Address { get; private set; }

    public UserId UserId { get; private set; }
    public User User { get; private set; }


    public Customer()
    {

    }

    public Customer(CustomerId id) : base(id)
    {
        Id = id;
    }

    public Customer(CustomerId id, string firstName, string lastName, string phoneNumber, GenderStatus gender, DateTime createdDate,
    Address address, UserId userId) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Gender = gender;
        CreatedDate = createdDate;
        Address = address;
        UserId = userId;
    }

    public Customer(CustomerId id, string firstName, string lastName, string phoneNumber, GenderStatus gender, DateTime createdDate,
     Address address, User user) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Gender = gender;
        CreatedDate = createdDate;
        Address = address;
        User = user;
    }

    public static Customer Create(CustomerId id, string firstName, string lastName, string phoneNumber, GenderStatus gender, DateTime createdDate,
     Address address, User user)
    {
        return new(id, firstName, lastName, phoneNumber, gender, createdDate, address, user);
    }

    public static Customer Create(CustomerId id, string firstName, string lastName, string phoneNumber, GenderStatus gender, DateTime createdDate,
        Address address, UserId userId)
    {
        return new(id, firstName, lastName, phoneNumber, gender, createdDate, address, userId);
    }

    public static Customer Create(string firstName, string lastName, string phoneNumber, GenderStatus gender, DateTime createdDate,
    Address address, User user)
    {
        return new(CustomerId.CreateUnique(), firstName, lastName, phoneNumber, gender, createdDate, address, user);
    }

    public static Customer Create(string firstName, string lastName, string phoneNumber, GenderStatus gender, DateTime createdDate,
    Address address, UserId userId)
    {
        return new(CustomerId.CreateUnique(), firstName, lastName, phoneNumber, gender, createdDate, address, userId);
    }
    public static Customer Create(Guid id)
    {
        return new(CustomerId.Create(id));
    }
}