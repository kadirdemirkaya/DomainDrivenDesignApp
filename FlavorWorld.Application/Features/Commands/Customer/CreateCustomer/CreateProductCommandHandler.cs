using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Commands.Products.CreateCustomer;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Orders.CreateCustomer;

public class CreateProductCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
{
    private readonly ICustomerWriteRepository<Customer, CustomerId> _customerWriteRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IMapper mapper, ICustomerWriteRepository<Customer, CustomerId> customerWriteRepository)
    {
        _mapper = mapper;
        _customerWriteRepository = customerWriteRepository;
    }

    public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        bool result = await _customerWriteRepository.CreateAsync(Customer.Create(request.FirstName, request.LastName, request.PhoneNumber, request.Gender, request.CreatedDate,
                            request.Address, request.UserId));
        int dbresult = await _customerWriteRepository.SaveChangesAsync();
        if (dbresult <= 0)
            result = false;
        return result;
    }
}