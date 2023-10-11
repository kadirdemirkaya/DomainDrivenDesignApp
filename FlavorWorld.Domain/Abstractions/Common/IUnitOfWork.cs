namespace FlavorWorld.Domain.Abstractions.Common;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}