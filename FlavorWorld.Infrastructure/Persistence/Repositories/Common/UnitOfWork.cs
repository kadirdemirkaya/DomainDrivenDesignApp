using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Infrastructure.Persistence.Data;
using MediatR;

namespace FlavorWorld.Infrastructure.Persistence.Repositories.Common;
public class UnitOfWork : IUnitOfWork
{
    private readonly FlavorWorldDbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(FlavorWorldDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<int> SaveChangesAsync()
    {
        int result = await _context.SaveChangesAsync();
        return result;
    }
}