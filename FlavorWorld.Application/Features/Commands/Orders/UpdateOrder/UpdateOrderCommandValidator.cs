using FluentValidation;

namespace FlavorWorld.Application.Features.Commands.Orders.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.orderId).NotNull().NotEmpty().WithErrorCode("orderId is not empty !");
        RuleFor(x => x.CreatedDate).NotNull().NotEmpty().WithErrorCode("CreatedDate is not empty !");
        RuleFor(x => x.Description).NotNull().NotEmpty().WithErrorCode("Description is not empty !");
        RuleFor(x => x.UserId).NotNull().NotEmpty().WithErrorCode("UserId is not empty !");
    }
}