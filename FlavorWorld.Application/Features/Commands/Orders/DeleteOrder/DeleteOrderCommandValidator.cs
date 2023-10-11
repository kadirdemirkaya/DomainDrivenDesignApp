using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Orders.DeleteOrder;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.id).NotNull().NotEmpty().WithErrorCode("Id is not empty !");
    }
}