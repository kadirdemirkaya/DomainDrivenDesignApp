using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Abstractions.Repository.Product;

public interface ICustomerWriteRepository<T, TId> : IWriteRepository<T, TId>
    where T : Entity<TId>
    where TId : ValueObject
{

}