
using FlavorWorld.Domain.Aggregates.CustomerAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

namespace FlavorWorld.Contracts.Models.Customers;

public class CreateCustomerCommandDto
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public GenderStatus Gender { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public Address Address { get; private set; }
    public UserId UserId { get; private set; }
}