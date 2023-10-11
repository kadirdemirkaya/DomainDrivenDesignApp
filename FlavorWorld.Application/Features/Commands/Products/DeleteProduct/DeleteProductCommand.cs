using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.DeleteProduct;

public record DeleteProductCommand(
    Guid id
) : IRequest<bool>;
