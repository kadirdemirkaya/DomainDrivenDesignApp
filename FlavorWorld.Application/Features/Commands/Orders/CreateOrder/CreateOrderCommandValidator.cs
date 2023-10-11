using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CreatedDate).NotNull().NotEmpty().WithErrorCode("CreatedDate is not empty !");
        RuleFor(x => x.Description).NotNull().NotEmpty().WithErrorCode("Description is not empty !");
        RuleFor(x => x.UserId).NotNull().NotEmpty().WithErrorCode("UserId is not empty !");
        RuleForEach(x => x.OrderItemCommand).NotNull().NotEmpty().WithErrorCode("OrderItemCommand is not empty !");
    }
}