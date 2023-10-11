using System.Linq.Expressions;
using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.BaseTypes;
using FlavorWorld.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FlavorWorld.Infrastructure.Persistence.Repositories.Common;

public class ReadRepository<T, TId> : IReadReposiyory<T, TId>
    where T : Entity<TId>
    where TId : ValueObject
{
    private readonly FlavorWorldDbContext _context;

    public ReadRepository(FlavorWorldDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (expression is not null)
                return await query.AnyAsync(expression);

            if (expression != null)
                query = query.Where(expression);

            return await query.AnyAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (expression is not null)
                return await query.CountAsync(expression);

            if (expression != null)
                query = query.Where(expression);

            return await query.CountAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeEntity.Any())
                foreach (var include in includeEntity)
                    query = query.Include(include);

            if (expression != null)
                query = query.Where(expression);

            return await query.ToListAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeEntity.Any())
                foreach (var include in includeEntity)
                    query = query.Include(include);

            if (expression != null)
                query = query.Where(expression);

            return await query.SingleOrDefaultAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public async Task<T> GetByGuidAsync(Guid id, bool tracking = true)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await Table.FindAsync(id);
        }
        catch (System.Exception)
        {
            return default;
        }
    }
}




public class ReadRepository<T> : IReadReposiyory<T> where T : class
{
    private readonly FlavorWorldDbContext _context;

    public ReadRepository(FlavorWorldDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (expression is not null)
                return await query.AnyAsync(expression);

            if (expression != null)
                query = query.Where(expression);

            return await query.AnyAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (expression is not null)
                return await query.CountAsync(expression);

            if (expression != null)
                query = query.Where(expression);

            return await query.CountAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeEntity.Any())
                foreach (var include in includeEntity)
                    query = query.Include(include);

            if (expression != null)
                query = query.Where(expression);

            return await query.ToListAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            if (includeEntity.Any())
                foreach (var include in includeEntity)
                    query = query.Include(include);

            if (expression != null)
                query = query.Where(expression);

            return await query.SingleOrDefaultAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public async Task<T> GetByGuidAsync(Guid id, bool tracking = true)
    {
        try
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await Table.FindAsync(id);
        }
        catch (System.Exception)
        {
            return default;
        }
    }
}