using FlavorWorld.Abstractions.BaseTypes;
using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.BaseTypes;
using FlavorWorld.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FlavorWorld.Infrastructure.Persistence.Repositories.Common;

public class WriteRepositoy<T, TId> : IWriteRepository<T, TId>
    where T : Entity<TId>
    where TId : ValueObject
{
    private readonly FlavorWorldDbContext _context;

    public WriteRepositoy(FlavorWorldDbContext context)
    {
        _context = context;
    }

    private DbSet<T> _table => _context.Set<T>();

    public async Task<bool> CreateAsync(T entity)
    {
        try
        {
            await _table.AddAsync(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            _table.Remove(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteByIdAsync(T entityId)
    {
        try
        {
            var entity = await _table.SingleOrDefaultAsync(t => t.Id == entityId.Id);
            _table.Remove(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public bool UpdateAsync(T entity)
    {
        try
        {
            _table.Update(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}




public class WriteRepositoy<T> : IWriteRepository<T> where T : class
{
    private readonly FlavorWorldDbContext _context;

    public WriteRepositoy(FlavorWorldDbContext context)
    {
        _context = context;
    }

    private DbSet<T> _table => _context.Set<T>();

    public async Task<bool> CreateAsync(T entity)
    {
        try
        {
            await _table.AddAsync(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            _table.Remove(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteByIdAsync(T entityId)
    {
        try
        {
            _table.Remove(entityId);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return default;
        }
    }

    public bool UpdateAsync(T entity)
    {
        try
        {
            _table.Update(entity);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}