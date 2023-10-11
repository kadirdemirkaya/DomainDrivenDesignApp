using AutoMapper;
using FlavorWorld.Abstractions.Repository.Product;
using FlavorWorld.Application.Features.Commands.Products.DeleteCustomer;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using MediatR;

namespace FlavorWorld.Application.Features.Commands.Products.DeleteProduct;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerWriteRepository<Customer, CustomerId> _customerWriteRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerCommandHandler(ICustomerWriteRepository<Customer, CustomerId> customerWriteRepository, IMapper mapper)
    {
        _customerWriteRepository = customerWriteRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        bool result = await _customerWriteRepository.DeleteByIdAsync(Customer.Create(request.id));
        int dbResult = await _customerWriteRepository.SaveChangesAsync();
        if (dbResult <= 0)
            result = false;
        return result;
    }
}