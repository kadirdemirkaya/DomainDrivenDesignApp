using System.Linq.Expressions;
using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.BaseTypes;

namespace FlavorWorld.Domain.Abstractions.Common;

public interface IReadReposiyory<T, TId>
    where T : Entity<TId>
    where TId : ValueObject
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity);

    Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity);

    Task<T> GetByGuidAsync(Guid id, bool tracking = true);

    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true);

    Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true);
}




public interface IReadReposiyory<T> where T : class
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity);

    Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity);

    Task<T> GetByGuidAsync(Guid id, bool tracking = true);

    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true);

    Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true);
}