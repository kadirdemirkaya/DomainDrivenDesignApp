using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.DeleteCustomer;

public record DeleteCustomerCommand(
    Guid id
) : IRequest<bool>;
