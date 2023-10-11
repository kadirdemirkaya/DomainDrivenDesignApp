using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerWriteRepository<Customer, CustomerId> _customerWriteRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(ICustomerWriteRepository<Customer, CustomerId> customerWriteRepository, IMapper mapper)
    {
        _customerWriteRepository = customerWriteRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        bool result = _customerWriteRepository.UpdateAsync(Customer.Create(CustomerId.Create(request.id), request.FirstName, request.LastName, request.PhoneNumber
        , request.Gender, request.CreatedDate, request.Address, request.UserId));
        int dbResult = await _customerWriteRepository.SaveChangesAsync();
        if (dbResult <= 0)
            result = false;
        return result;
    }
}