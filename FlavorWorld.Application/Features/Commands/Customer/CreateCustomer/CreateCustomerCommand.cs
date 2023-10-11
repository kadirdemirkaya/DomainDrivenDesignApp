using FlavorWorld.Domain.Aggregates.CustomerAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.CreateCustomer;

public record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string PhoneNumber,
    GenderStatus Gender,
    DateTime CreatedDate,
    Address Address,
    UserId UserId
) : IRequest<bool>;
