using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Abstractions.Common;

public interface IWriteRepository<T, TId> : IUnitOfWork
    where T : Entity<TId>
    where TId : ValueObject
{
    public Task<bool> CreateAsync(T entity);
    public bool Delete(T entity);
    public Task<bool> DeleteByIdAsync(T entityId);
    public bool UpdateAsync(T entity);
}


public interface IWriteRepository<T> where T : class
{
    public Task<bool> CreateAsync(T entity);
    public bool Delete(T entity);
    public Task<bool> DeleteByIdAsync(T entityId);
    public bool UpdateAsync(T entity);
}